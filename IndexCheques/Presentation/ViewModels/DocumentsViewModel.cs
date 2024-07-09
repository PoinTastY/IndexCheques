using ApplicationCore.DTOs;
using ApplicationCore.UseCases;
using IndexCheques.Presentation.ViewModels.Base;

namespace IndexCheques.Presentation.ViewModels
{
    public class DocumentsViewModel : ViewModelBase
    {
        private readonly GetDocumentsByFechaConceptoSerieUseCase _getDocumentsByFechaConceptoSerieUseCase;

        public DocumentsViewModel(GetDocumentsByFechaConceptoSerieUseCase getDocumentsByFechaConceptoSerieUseCase)
        {
            _getDocumentsByFechaConceptoSerieUseCase = getDocumentsByFechaConceptoSerieUseCase;
        }

        private List<DocumentDTO>? _documents;
        
        public List<DocumentDTO>? Documents
        {
            get => _documents;
            set
            {
                _documents = value;
                OnCollectionChanged(nameof(Documents));
            }
        }

        public async Task LoadDocumentsAsync(DateTime fechaInicio, DateTime fechaFin, string codigoConcepto, string serie)
        {
            Documents = await _getDocumentsByFechaConceptoSerieUseCase.GetDocumentsByFechaConceptoSerieAsync(fechaInicio, fechaFin, codigoConcepto, serie);
        }
    }
}
