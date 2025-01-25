using Tema4Exercici1BIEN.ViewModels;

namespace Tema4Exercici1BIEN.Views;

public partial class AddItemNewWindow : ContentPage
{
    
    public AddItemNewWindow()
	{
		InitializeComponent();

        BindingContext = new AddItemNewWindowViewModel();

    }


}