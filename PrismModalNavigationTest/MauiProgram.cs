using Microsoft.Extensions.Logging;

namespace PrismModalNavigationTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UsePrism(prismBuilder =>
			{
				prismBuilder.RegisterTypes(containerRegistry =>
				{
					containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
					containerRegistry.RegisterForNavigation<ModalPage, ModalViewModel>();
				})
				.CreateWindow(navigationService => navigationService.CreateBuilder()
					.AddNavigationPage()
					.AddSegment<MainViewModel>()
					.NavigateAsync(HandleNavigationError)
				);
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void HandleNavigationError(Exception ex)
    {
        Console.WriteLine(ex);
        System.Diagnostics.Debugger.Break();
    }
}

