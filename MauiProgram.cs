﻿using Login1.ViewModels;
using Microsoft.Extensions.Logging;

namespace Login1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Lato-Bold.ttf","bold");
                    fonts.AddFont("Lato-Regular.ttf", "medium");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "Awesome");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ProductosViewModel>();
            return builder.Build();
        }
    }
}
