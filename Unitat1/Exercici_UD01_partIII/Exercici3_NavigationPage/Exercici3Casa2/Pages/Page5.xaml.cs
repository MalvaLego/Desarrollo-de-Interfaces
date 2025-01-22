namespace Exercici3Casa2.Pages;

public partial class Page5 : ContentPage
{
	public Page5(string producto,string units,string direccion)
	{
		InitializeComponent();

        tvResumen.Text = "Entrada: " + producto + "\n" +
            "Número de entradas: " + units + "\n" +
            "Método de pago: Tarjeta " + direccion;

    }


    private async void btnGoBack(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}