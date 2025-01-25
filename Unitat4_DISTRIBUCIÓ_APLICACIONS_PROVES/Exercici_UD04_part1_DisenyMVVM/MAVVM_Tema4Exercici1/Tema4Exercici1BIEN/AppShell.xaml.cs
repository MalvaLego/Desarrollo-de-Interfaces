using Tema4Exercici1BIEN.Views;

namespace Tema4Exercici1BIEN
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(Tema4Exercici1BIEN.Views.MainPage));
            Routing.RegisterRoute(nameof(AddItemNewWindow), typeof(Tema4Exercici1BIEN.Views.AddItemNewWindow));          
        }
    }
}
