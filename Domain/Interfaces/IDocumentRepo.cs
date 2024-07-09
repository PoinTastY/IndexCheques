using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDocumentRepo
    {
        Task<List<Document>> GetDocumentsByFechaConceptoSerieAsync(DateTime fechaInicio, DateTime fechaFin, string codigoConcepto, string serie);
    }
}
