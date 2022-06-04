namespace Microsoft.UI.Xaml.Controls
{
    public static class ExpanderExtensions
    {
        // Enables or disables the Header.
        public static void IsLocked(this Expander expander, bool locked)
        {
            ((expander.Header as FrameworkElement).Parent as Control).IsEnabled = locked;
        }

        // Sets the desired Height for content when expanded.
        public static void SetContentHeight(this Expander expander, double contentHeight)
        {
            (expander.Content as FrameworkElement).Height = contentHeight;
        }
    }
}
