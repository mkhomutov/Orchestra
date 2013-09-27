namespace Orchestra.Modules.TextEditor.TestShell
{
    using System;
    using System.Windows;

    using Catel;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.MVVM.ViewModels;
    using Catel.Windows;

    using Orchestra;
    using Orchestra.Services;
    using Orchestra.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            
/*
            StyleHelper.CreateStyleForwardersForDefaultStyles(Current.Resources.MergedDictionaries[1]);

            var serviceLocator = ServiceLocator.Instance;
            Environment.RegisterDefaultViewModelServices();

            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.Register(typeof(ProgressNotifyableViewModel), typeof(Orchestra.Views.SplashScreen));

            var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            viewModelLocator.Register(typeof(Orchestra.Views.SplashScreen), typeof(ProgressNotifyableViewModel));

            var bootstrapper = new OrchestraBootstrapper();
            bootstrapper.RunWithSplashScreen<ProgressNotifyableViewModel>();*/

            // Example of best performance options for Catel (but at the cost of validation features)
            Catel.Windows.Controls.UserControl.DefaultCreateWarningAndErrorValidatorForViewModelValue = false;
            Catel.Windows.Controls.UserControl.DefaultSkipSearchingForInfoBarMessageControlValue = true;
            Catel.Data.ModelBase.SuspendValidationForAllModels = true;

            var serviceLocator = ServiceLocator.Default;
            Catel.Environment.RegisterDefaultViewModelServices();

            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.Register(typeof(SplashScreenViewModel), typeof(Views.SplashScreen));

            var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            viewModelLocator.Register(typeof(Views.SplashScreen), typeof(SplashScreenViewModel));

            var bootstrapper = new OrchestraBootstrapper();

            StyleHelper.CreateStyleForwardersForDefaultStyles(Current.Resources.MergedDictionaries[1]);

/*            bootstrapper.CreatedShell += (sender, e2) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Configure shell when it's created
                    var configurationService = ServiceLocator.Default.ResolveType<IConfigurationService>();

                    // Disable debugging window
                    var orchestraService = ServiceLocator.Default.ResolveType<IOrchestraService>();
                    orchestraService.ShowDebuggingWindow = false;
                });
            };*/

            bootstrapper.RunWithSplashScreen<SplashScreenViewModel>();

            base.OnStartup(e);
        }
    }
}