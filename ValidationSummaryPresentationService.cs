using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ifp.Validation.WPF.MousePointer;

namespace Ifp.Validation.WPF
{
    public class ValidationSummaryPresentationService : IValidationSummaryPresentationService
    {
        public bool ShowValidationSummary(ValidationSummary validationSummary)
        {
            return ShowValidationSummary(validationSummary, false);
        }

        public bool ShowValidationSummary(ValidationSummary validationSummary, bool showOnlyOnFailures)
        {
            return ShowValidationSummary(validationSummary, showOnlyOnFailures, null);
        }

        public bool ShowValidationSummary(ValidationSummary validationSummary, bool showOnlyOnFailures, string headerText)
        {
            return ShowValidationSummary(validationSummary, showOnlyOnFailures, headerText, null);
        }

        public bool ShowValidationSummary(ValidationSummary validationSummary, bool showOnlyOnFailures, string headerText, string howToProceedMessage)
        {
            if (showOnlyOnFailures && !validationSummary.Severity.IsAnError) return true;
            return DoShowValidationSummary(validationSummary, headerText, howToProceedMessage);
        }

        private bool DoShowValidationSummary(ValidationSummary validationSummary, string headerText, string howToProceedMessage)
        {
            using (new StandardMousePointer())
            {

                var sw = new ValidationSummaryWindow();
                sw.ValidationSummary = validationSummary;
                if (!String.IsNullOrWhiteSpace(headerText))
                    sw.Header = headerText;
                if (!String.IsNullOrWhiteSpace(howToProceedMessage))
                    sw.HowToProceedMessage = howToProceedMessage;
                var res = sw.ShowDialog();
                return res ?? false;
            }
        }
    }
}
