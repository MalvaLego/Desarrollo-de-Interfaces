namespace Exercici5;

[QueryProperty(nameof(FormaPago), "formaPago")]
public partial class SeleccionCurso : ContentPage
{
    string nombre;
    int precio;
    private string _formaPago;
    public string FormaPago
    {
        get => _formaPago;
        set => _formaPago=value;
        
    }

    public SeleccionCurso()
	{
		InitializeComponent();
    }

	public async void GSAgua(object sender, EventArgs e)
	{
        nombre = "Gestión del Agua";
        precio = 21;

        await Shell.Current.GoToAsync($"//MainPage?nom={nombre}&precio={precio}&formaPago={_formaPago}");
    }
    public async void GSDAM(object sender, EventArgs e)
    {
        nombre = "Desarrollo de Aplicaciones Multiplataforma";
        precio = 101;

        await Shell.Current.GoToAsync($"//MainPage?nom={nombre}&precio={precio}&formaPago={_formaPago}");
    }

}