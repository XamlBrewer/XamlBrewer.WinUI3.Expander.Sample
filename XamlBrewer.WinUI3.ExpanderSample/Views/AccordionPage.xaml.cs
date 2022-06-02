using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace XamlBrewer.WinUI3.ExpanderSample.Views
{
    public sealed partial class AccordionPage : Page
    {
        List<Expander> _expanders = new List<Expander>();

        public AccordionPage()
        {
            InitializeComponent();

            Loaded += AccordionPage_Loaded;
        }

        private void AccordionPage_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Expander expander in Accordion.Items)
            {
                _expanders.Add(expander);
                expander.Expanding += Expander_Expanding;
            }

            // Open the first one.
            _expanders[0].IsExpanded = true;
        }

        private void Expander_Expanding(Expander sender, ExpanderExpandingEventArgs args)
        {
            foreach (var expander in _expanders)
            {
                // Close the others.
                expander.IsExpanded = sender == expander;

                // Force current to remain open by disabling the header.
                ((expander.Header as FrameworkElement).Parent as Control).IsEnabled = sender != expander;
            }
        }
    }
}
