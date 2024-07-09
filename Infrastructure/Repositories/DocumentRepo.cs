using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly ContpaqiSQLContext _context;

        public DocumentRepo(ContpaqiSQLContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetDocumentsByFechaConceptoSerieAsync(DateTime fechaInicio, DateTime fechaFin, string codigoConcepto, string serie)
        {
            try
            {
                var concepto = _context.concepts.Where(c => c.CCODIGOCONCEPTO == codigoConcepto).Select(c => c.CIDCONCEPTODOCUMENTO)
                .FirstOrDefault();
                if (concepto == 0)
                {
                    throw new NotFoundArgumentException($"Parece que el concepto con codigo: {codigoConcepto}, no existe :c");
                }

                return await _context.documents.Where(d =>
                d.CFECHA >= fechaInicio &&  d.CFECHA <= fechaFin &&
                d.CIDCONCEPTODOCUMENTO == concepto && d.CSERIEDOCUMENTO == serie).ToListAsync();
            }
            catch (NotFoundArgumentException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error inesperado al conseguir los documentos; " + e.Message);
            }
        }
    }
}
