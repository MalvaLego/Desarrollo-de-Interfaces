namespace Exercici3Casa2.Pages;

public partial class Page5 : ContentPage
{
	public Page5(string producto,string units,string direccion)
	{
		InitializeComponent();

        tvResumen.Text = "Entrada: " + producto + "\n" +
            "N�mero de entradas: " + units + "\n" +
            "M�todo de pago: Tarjeta " + direccion;

    }


    private async void btnGoBack(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}