using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlBrewer.WinUI3.ExpanderSample.Views
{
    public sealed partial class AccordionPage : Page
    {
        readonly List<Expander> _expanders = new();
        double _closedAccordionHeight;
        readonly double _minimumContentHeight = 48;
        double _contentPadding;

        public AccordionPage()
        {
            InitializeComponent();
            Loaded += AccordionPage_Loaded;
        }

        private Expander Current => _expanders.Where(e => e.IsExpanded).First();

        private void AccordionPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Remember the height with all expanders collapsed.
            _closedAccordionHeight = Accordion.ActualHeight;

            foreach (Expander expander in Accordion.Items)
            {
                _expanders.Add(expander);
                expander.Expanding += Expander_Expanding;
            }

            // Remember the Content Padding
            _contentPadding = _expanders[0].Padding.Top + _expanders[0].Padding.Bottom + 2; // Border?

            // Open the first one.
            ApplyScrollBar();
            _expanders[0].IsExpanded = true;

            Host.SizeChanged += Host_SizeChanged;
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

            FillHeight(sender);
        }

        private void Host_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ApplyScrollBar();
            FillHeight(Current);
        }

        private void FillHeight(Expander expander)
        {
            // Stretch the height of the expanded content.
            expander.SetContentHeight(Math.Max(_minimumContentHeight, Host.ActualHeight - _closedAccordionHeight - _contentPadding));
        }

        // Avoids flashing the vertical scrollbar during expanding.
        private void ApplyScrollBar()
        {
            if (Host.ActualHeight >= _closedAccordionHeight + _minimumContentHeight + _contentPadding)
            {
                ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
            else
            {
                ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }
    }
}
