namespace PrismModalNavigationTest;

public class MainViewModel : BindableBase
{
	public AsyncDelegateCommand NavigateToModalCommand { get; }

	public MainViewModel(INavigationService navigationService)
	{
		NavigationService = navigationService;

		NavigateToModalCommand = new AsyncDelegateCommand(NavigateToModalAsync);
	}

	private INavigationService NavigationService { get; }

    private async Task NavigateToModalAsync()
    {
		var navParams = new NavigationParameters()
		{
			{ KnownNavigationParameters.UseModalNavigation, true }
		};

		await NavigationService.NavigateAsync(nameof(ModalPage), navParams);
    }
}

