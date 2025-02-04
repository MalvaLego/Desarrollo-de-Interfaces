using Testing.Views;

namespace Testing
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(Testing.Views.MainPage));
        }
    }
}
