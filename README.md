This project demonstrates unexpected behavior for modal navigation using Prism.DryIoc.Maui v9.0.349-pre.

Sample Video that shows project running available at https://github.com/tbaggett/PrismMauiModalNavTest/raw/main/PrismMauiModalNavigationTest.mp4

The MauiProgram in the project defines the initial navigation with the following code:

    CreateWindow(navigationService => navigationService.CreateBuilder()
    					.AddNavigationPage()
    					.AddSegment<MainViewModel>()
    					.NavigateAsync(HandleNavigationError)

The MainPage contains two buttons labeled "Navigate to Modal Page with Prism" and "Navigate to Modal Page with MAUI". 

The Prism button's Command property is bound to a "NavigateToModalCommand" defined in MainViewModel. The command action is defined like so:

    private async Task NavigateToModalAsync()
    {
		var navParams = new NavigationParameters()
		{
			{ KnownNavigationParameters.UseModalNavigation, true }
		};

		await NavigationService.NavigateAsync(nameof(ModalPage), navParams);
    }

When the Prism button is tapped, we are taken to the ModalPage screen, however it doesn't use modal navigation to present it.

The MAUI button's Clicked property is bound to a method in the code-behind that uses Application.MainPage.Navigation to navigate to the modal page. It navigates as expected.

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (Application.Current?.MainPage != null)
		{
            Application.Current.MainPage.Navigation.PushModalAsync(new ModalPage()).Await();
        }
    }
