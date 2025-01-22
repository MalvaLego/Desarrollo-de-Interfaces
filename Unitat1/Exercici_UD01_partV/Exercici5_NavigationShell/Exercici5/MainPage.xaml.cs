
namespace Exercici5
{
    [QueryProperty(nameof(NombreCurso), "nom")]
    [QueryProperty(nameof(Precio), "precio")]
    [QueryProperty(nameof(FormaPago), "formaPago")]
    public partial class MainPage : ContentPage
    {
        private string _nombre;
        private int _precio;
        private string _formaPago;    
        public string NombreCurso
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }
        public int Precio
        {
            get => _precio;
            set
            {
                _precio = value;
                OnPropertyChanged();
            }
        }
        public string FormaPago
        {
            get => _formaPago;
            set
            {
                _formaPago = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            //_viewModel = new MainViewModel();
            BindingContext = this;
        }
        private async void GoPage2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"SeleccionCurso?formaPago={FormaPago}");

        }
        private async void GoPage3(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"FormaDePago?nom={NombreCurso}&precio={Precio}");
        }

        private async void CalcularPrecio(object sender, EventArgs e)
        {
            if ((_nombre!=null) && (_precio != null) && (_formaPago != null))
            {
                if (tvFormaPago.Text.Equals("Efectivo"))
                {
                    tvCalcularPrecio.Text = tvPrecio.Text.ToString();
                }
                else
                {
                    double precioFinal = _precio*0.1;
                    precioFinal = _precio - precioFinal;
                    tvCalcularPrecio.Text = precioFinal.ToString();
                }
            }
            else
            {
                tvCalcularPrecio.Text = "fallo";
            }
        }
    }
}
