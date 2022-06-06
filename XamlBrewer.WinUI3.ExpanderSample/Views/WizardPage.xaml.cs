using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace XamlBrewer.WinUI3.ExpanderSample.Views
{
    public sealed partial class WizardPage : Page
    {
        public WizardPage()
        {
            InitializeComponent();

            Host.SizeChanged += Host_SizeChanged;
            Loaded += WizardPage_Loaded;
        }

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
