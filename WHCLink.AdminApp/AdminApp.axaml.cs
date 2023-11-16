using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using WHC.CommonLibrary;
using WHC.CommonLibrary.DataConn;
using WHC.CommonLibrary.Logging;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Services;
using WHCLink.AdminApp.Models;
using WHCLink.AdminApp.ViewModels;
using WHCLink.AdminApp.Views;

namespace WHCLink.AdminApp;

public partial class AdminApp : Application
{
    private readonly IHost m_appHost;
        
    public AdminApp()
    {
        var commonFilesService = new CommonFilesService();
        m_appHost = Host.CreateDefaultBuilder()
            // ReSharper disable once UnusedParameter.Local
            .ConfigureLogging((p_context, p_builder) =>
                                          {
                                              var configuredLogLevel = LogLevelUtilities.GetLogLevel("DEBUG");
                                              p_builder.ClearProviders();
                                              p_builder.AddDebug();
                                              p_builder.AddFile(commonFilesService.LogsPath,
                                                                configuredLogLevel,
                                                                retainedFileCountLimit: 31,
                                                                fileSizeLimitBytes: 1024 * 1024 * 10,
                                                                isJson: true);
                                              Log.Logger = new LoggerConfiguration()
                                                          .MinimumLevel
                                                          .Is(LogLevelUtilities.GetSerilogLogLevel(configuredLogLevel))
                                                          .WriteTo.Sink(new CollectionSink())
                                                          .CreateLogger();
                                              p_builder.AddSerilog(Log.Logger);
                                          })
            .ConfigureServices(ConfigureServices).Build();

    }

    private void ConfigureServices(IServiceCollection p_services)
    {
        p_services.AddSingleton<CommonFilesService>();
        p_services.AddSingleton<DatabaseUtilities>();
        p_services.AddSingleton<EncryptionService>();
        p_services.AddSingleton<ClientConfiguration>();
        p_services.AddSingleton<ClientConfigurationService>();

        p_services.AddSingleton<MainWindowModel>();
        p_services.AddSingleton<MainWindowView>();
        p_services.AddSingleton<MainWindowViewModel>();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        await m_appHost.StartAsync();

        var configurationService = m_appHost.Services.GetService<ClientConfigurationService>();
        configurationService!.Read();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.ShutdownRequested += DesktopOnShutdownRequested;
            desktop.MainWindow = m_appHost.Services.GetService<MainWindowView>();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private async void DesktopOnShutdownRequested(object? p_sender, ShutdownRequestedEventArgs p_e)
    {
        await m_appHost.StopAsync();
    }
}