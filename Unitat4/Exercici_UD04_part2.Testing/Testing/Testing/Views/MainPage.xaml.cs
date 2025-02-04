using Testing.ViewModels;

namespace Testing.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

    }

}
