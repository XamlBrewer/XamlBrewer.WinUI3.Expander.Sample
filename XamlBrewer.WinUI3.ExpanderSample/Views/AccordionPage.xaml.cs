using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace XamlBrewer.WinUI3.ExpanderSample.Views
{
    public sealed partial class AccordionPage : Page
    {
        List<Expander> _expanders = new List<Expander>();
        double _closedAccordionHeight;

        public AccordionPage()
        {
            InitializeComponent();

            Loaded += AccordionPage_Loaded;
        }

        private void AccordionPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Remember the height with all expanders collapsed.
            _closedAccordionHeight = Accordion.ActualHeight;

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
                expander.IsLocked(sender != expander);
            }

            // Stretch the height of the expanded content.
            sender.SetContentHeight(Math.Max(0, Host.ActualHeight - _closedAccordionHeight - 34));
        }
    }
}
