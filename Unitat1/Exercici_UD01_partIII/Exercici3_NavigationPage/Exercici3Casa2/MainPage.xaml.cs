namespace Exercici3Casa2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGoPage2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Page2());
        }
    }

}
