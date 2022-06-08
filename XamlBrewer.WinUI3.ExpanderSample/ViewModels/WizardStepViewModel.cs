using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace XamlBrewer.WinUI3.ExpanderSample.ViewModels
{
    internal partial class WizardStepViewModel : ObservableObject
    {
        [ObservableProperty]
        private WizardViewModel _wizard;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private bool _allowReturn = true;

        [ObservableProperty]
        private bool _isFinal;

        [ObservableProperty]
        private bool _isFirst;

        public WizardStepViewModel(WizardViewModel wizard)
        {
            _wizard = wizard;
        }

        public ICommand PreviousCommand { get; set; }

        public ICommand NextCommand { get; set; }

        public void Enter()
        { }


    }
}
