using IndexCheques.Presentation.ViewModels;

namespace IndexCheques
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly DocumentsViewModel _viewModel;

        public MainPage(DocumentsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadDocumentsAsync(new DateTime(2024, 02, 19), DateTime.Now, "4", "F");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
