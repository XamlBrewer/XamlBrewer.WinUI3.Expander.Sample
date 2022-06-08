﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace XamlBrewer.WinUI3.ExpanderSample.ViewModels
{
    internal partial class WizardViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<WizardStepViewModel> _steps = new();

        [ObservableProperty]
        private WizardStepViewModel _current;

        internal WizardStepViewModel PreviousStep(WizardStepViewModel step)
        {
            var stepIndex = _steps.IndexOf(step);
            if (stepIndex < _steps.Count)
            {
                return _steps[stepIndex + 1];
            }

            return null;
        }

        internal WizardStepViewModel NextStep(WizardStepViewModel step)
        {
            var stepIndex = _steps.IndexOf(step);
            if (stepIndex > 0)
            {
                return _steps[stepIndex - 1];
            }

            return null;
        }
    }
}
