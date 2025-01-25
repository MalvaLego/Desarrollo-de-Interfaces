using Tema4Exercici1BIEN.ViewModels;

namespace Tema4Exercici1BIEN.Views;



    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();         
        }
       

    }


