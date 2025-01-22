namespace Exercici3Casa2.Pages;

public partial class Page2 : ContentPage
{
    string tipoEntrada = "";
    int selectedItem=0;

    public Page2()
	{
		InitializeComponent();
	}

    private async void btnGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnGoPage3(object sender, EventArgs e)
    {

        if (selectedItem == 0)
        {
            return;
        }
        

        await Navigation.PushAsync(new Pages.Page3(tipoEntrada));
    }

    private void pTipoEntrada(object sender, EventArgs e) 
    {
        var picker = (Picker)sender;
        selectedItem = picker.SelectedIndex;

        if (selectedItem!=-1)
        {
            tipoEntrada = (string)picker.ItemsSource[selectedItem];
        }
       

    }


}