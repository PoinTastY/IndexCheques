using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;

namespace ApplicationCore.UseCases
{
    public class GetDocumentsByFechaConceptoSerieUseCase
    {
        private readonly IDocumentService _documentService;

        public GetDocumentsByFechaConceptoSerieUseCase(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<List<DocumentDTO>> GetDocumentsByFechaConceptoSerieAsync(DateTime fechaInicio, DateTime fechaFin, string codigoConcepto, string serie)
        {
            return await _documentService.GetDocumentsByFechaConceptoSerieAsync(fechaInicio, fechaFin, codigoConcepto, serie);
        }
    }
}
