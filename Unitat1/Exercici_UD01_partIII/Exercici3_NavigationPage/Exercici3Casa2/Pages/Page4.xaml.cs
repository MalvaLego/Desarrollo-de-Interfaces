namespace Exercici3Casa2.Pages;

public partial class Page4 : ContentPage
{
    private string producto;
    private string units;

    public Page4(string producto,string units)
	{
		InitializeComponent();

        this.producto= producto;
        this.units= units;
	}

    private async void btnGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnGoPage5(object sender, EventArgs e)
    {
        string direccion = etDireccion.Text;

        if (string.IsNullOrEmpty(direccion))
        {
            return;
        }
        if (!int.TryParse(direccion, out _))
        {
            return;
        }

        await Navigation.PushAsync(new Pages.Page5(producto, units, direccion));
    }
}