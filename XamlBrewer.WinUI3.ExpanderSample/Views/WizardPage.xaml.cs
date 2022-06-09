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
                    AllowReturn = true,
                    Name = "Movie",
                    Description = "Select a movie and a time"
                },
                new WizardStepViewModel(viewModel)
                {
                    AllowReturn = true,
                    Name = "Seat",
                    Description = "Select a row and a seat"
                },
                new WizardStepViewModel(viewModel)
                {
                    AllowReturn = false,
                    Name = "Customer",
                    Description = "Provide contact information"
                },
                new WizardStepViewModel(viewModel)
                {
                    AllowReturn = false,
                    Name = "Payment",
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
