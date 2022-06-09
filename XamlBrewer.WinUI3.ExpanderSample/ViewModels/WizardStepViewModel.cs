using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
        private string _description;

        [ObservableProperty]
        private bool _allowReturn = true;

        public WizardStepViewModel(WizardViewModel wizard)
        {
            _wizard = wizard;

            PreviousCommand = new RelayCommand(Previous_Executed, Previous_CanExecute);
            NextCommand = new RelayCommand(Next_Executed, Next_CanExecute);
        }

        public string Test => "Hello There";

        public ICommand PreviousCommand { get; private set; }

        public ICommand NextCommand { get; private set; }

        public void Enter()
        { }

        private void Previous_Executed()
        { }

        private bool Previous_CanExecute()
        {
            var previous = _wizard.PreviousStep(this);

            if (previous is null)
            {
                return false;
            }

            if (!previous.AllowReturn)
            {
                return false;
            }

            return true;
        }

        private void Next_Executed()
        { }

        private bool Next_CanExecute()
        {
            var next = _wizard.NextStep(this);

            if (next is null)
            {
                return false;
            }

            return true;
        }
    }
}
