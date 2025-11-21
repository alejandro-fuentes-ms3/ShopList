
using shopList.Gui.ViewModels;


namespace shopList.Gui.Views;

public partial class ShopListpage : ContentPage
{
	public ShopListpage()
	{
		InitializeComponent();
        BindingContext = new ShopListViewModels();  
    
        
    }
}
