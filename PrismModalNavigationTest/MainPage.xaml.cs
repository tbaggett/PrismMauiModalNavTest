namespace PrismModalNavigationTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (Application.Current?.MainPage != null)
		{
            Application.Current.MainPage.Navigation.PushModalAsync(new ModalPage()).Await();
        }
    }
}
