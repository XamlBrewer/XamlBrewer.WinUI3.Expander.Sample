using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using XamlBrewer.WinUI3.ExpanderSample.ViewModels;

namespace XamlBrewer.WinUI3.ExpanderSample.Views
{
    public sealed partial class WizardPage : Page
    {
        public WizardPage()
        {
            var viewModel = new WizardViewModel();
            viewModel.Steps = new List<WizardStepViewModel>()
                {
                new WizardStepViewModel(viewModel)
                {
                    IsActive = true,
                    AllowReturn = true,
                    Name = "Your movie",
                    Description = "Select a movie and a time"
                },
                new WizardStepViewModel(viewModel)
                {
                    AllowReturn = true,
                    Name = "Your seat",
                    Description = "Select a row and a seat"
                },
                new WizardStepViewModel(viewModel)
                {
                    AllowReturn = false,
                    Name = "Yourself",
                    Description = "Provide contact information"
                },
                new WizardStepViewModel(viewModel)
                {
                    AllowReturn = false,
                    Name = "Your money",
                    Description = "Select a payment method and ... pay"
                }
            };
            DataContext = viewModel;

            InitializeComponent();

            Host.SizeChanged += Host_SizeChanged;
            Loaded += WizardPage_Loaded;
        }

        internal WizardViewModel ViewModel => DataContext as WizardViewModel;

        private void WizardPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Host_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Did not seem to work through Binding.
            ScrollViewer.Width = Host.ActualWidth;
        }
    }
}
