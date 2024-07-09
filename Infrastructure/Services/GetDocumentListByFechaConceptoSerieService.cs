using Domain.Interfaces;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;

namespace Infrastructure.Services
{
    public class GetDocumentListByFechaConceptoSerieService : IDocumentService
    {
        private readonly IDocumentRepo _documentRepo;

        public GetDocumentListByFechaConceptoSerieService(IDocumentRepo documentRepo)
        {
            _documentRepo = documentRepo;
        }

        /// <summary>
        ///     Gets a list of documents by fecha, concepto and serie
        /// </summary>
        /// <param name="fechaInicio">
        ///     Date start range
        /// </param>
        /// <param name="fechaFin">
        ///     Date end range
        /// </param>
        /// <param name="codigoConcepto">
        ///     Concept Code (string)
        /// </param>
        /// <param name="serie">
        ///     Serie
        /// </param>
        /// <returns>List of Documents</returns>
        public async Task<List<DocumentDTO>> GetDocumentsByFechaConceptoSerieAsync(DateTime fechaInicio, DateTime fechaFin, string codigoConcepto, string serie)
        {
            List<DocumentDTO> result = new List<DocumentDTO>();

            var documents = await _documentRepo.GetDocumentsByFechaConceptoSerieAsync(fechaInicio, fechaFin, codigoConcepto, serie);

            foreach (var document in documents)
            {
                result.Add(new DocumentDTO(document));
            }

            return result;
        }
    }
}
