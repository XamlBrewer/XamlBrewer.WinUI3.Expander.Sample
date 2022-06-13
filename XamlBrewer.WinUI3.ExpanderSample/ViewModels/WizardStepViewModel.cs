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
        private string _status;

        [ObservableProperty]
        private bool _allowReturn = true;

        [ObservableProperty]
        private bool _isActive;

        public WizardStepViewModel(WizardViewModel wizard)
        {
            _wizard = wizard;

            PreviousCommand = new RelayCommand(Previous_Executed, Previous_CanExecute);
            NextCommand = new RelayCommand(Next_Executed, Next_CanExecute);
        }

        public ICommand PreviousCommand { get; private set; }

        public ICommand NextCommand { get; private set; }

        public bool Commit()
        {
            // Validate and persist Model
            // ...

            // Update Status - Mockup
            Status = "Succes";

            // Return result
            return true;
        }

        private void Previous_Executed()
        {
            var previous = _wizard.PreviousStep(this);

            if (previous is null)
            {
                return;
            }

            if (!previous.AllowReturn)
            {
                return;
            }

            IsActive = false;
            previous.IsActive = true;
        }

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
        {
            if (!Commit())
            {
                return;
            }

            var next = _wizard.NextStep(this);

            if (next is null)
            {
                return;
            }

            IsActive = false;
            next.IsActive = true;
        }

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
