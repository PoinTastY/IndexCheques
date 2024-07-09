using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IDocumentService
    {
            Task<List<DocumentDTO>> GetDocumentsByFechaConceptoSerieAsync(DateTime fechaInicio, DateTime fechaFin, string codigoConcepto, string serie);
    }
}
