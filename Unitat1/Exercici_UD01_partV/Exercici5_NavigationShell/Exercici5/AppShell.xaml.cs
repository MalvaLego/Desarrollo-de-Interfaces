namespace Exercici5
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SeleccionCurso), typeof(SeleccionCurso));
            Routing.RegisterRoute(nameof(FormaDePago), typeof(FormaDePago));
        }
    }
}
