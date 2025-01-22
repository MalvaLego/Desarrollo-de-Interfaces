namespace Exercici3Casa2.Pages;

public partial class Page3 : ContentPage
{
    private string producto;

    public Page3(String producto)
	{
		InitializeComponent();

        this.producto = producto;
	}


    private async void btnGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnGoPage4(object sender, EventArgs e)
    {
        string units = etUnidades.Text;
        
        if (string.IsNullOrEmpty(units))
        {
            return;
        }
        if (!int.TryParse(units, out _))
        {
            return;
        }

        await Navigation.PushAsync(new Pages.Page4(producto,units));
    }
}