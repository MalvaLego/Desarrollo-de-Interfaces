namespace Exercici5;

[QueryProperty(nameof(NombreCurso), "nom")]
[QueryProperty(nameof(Precio), "precio")]
public partial class FormaDePago : ContentPage
{
    string _nombre;
    int _precio;
    public string NombreCurso
    {
        get => _nombre;
        set => _nombre = value;
    }
    public int Precio
    {
        get => _precio;
        set => _precio = value;
    }

    public FormaDePago()
	{
		InitializeComponent();
	}

    public async void Efectivo(object sender, EventArgs e)
    {
        string pago = "Efectivo";

        await Shell.Current.GoToAsync($"//MainPage?formaPago={pago}&nom={_nombre}&precio={_precio}");
    }

    public async void Tarjeta(object sender, EventArgs e)
    {
        string pago = "Con tarjeta";

        await Shell.Current.GoToAsync($"//MainPage?formaPago={pago}&nom={_nombre}&precio={_precio}");
    }
}