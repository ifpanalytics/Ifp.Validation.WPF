using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ifp.Validation.WPF.MousePointer;
using System.Globalization;
using Ifp.Validation.WPF.Localization;

namespace Ifp.Validation.WPF
{
    public class ValidationSummaryPresentationService : IValidationSummaryPresentationService
    {
        public ValidationSummaryPresentationService(IValidationWPFL8nService validationWPFL8nService)
        {
            ValidationWPFL8nService = validationWPFL8nService;
        }

        protected IValidationWPFL8nService ValidationWPFL8nService { get; }

        public bool ShowValidationSummary(ValidationSummary validationSummary) => ShowValidationSummary(validationSummary, false);

        public bool ShowValidationSummary(ValidationSummary validationSummary, bool showOnlyOnFailures) => ShowValidationSummary(validationSummary, showOnlyOnFailures, null);

        public bool ShowValidationSummary(ValidationSummary validationSummary, bool showOnlyOnFailures, string headerText) => ShowValidationSummary(validationSummary, showOnlyOnFailures, headerText, null);

        public bool ShowValidationSummary(ValidationSummary validationSummary, bool showOnlyOnFailures, string headerText, string howToProceedMessage)
        {
            if (showOnlyOnFailures && !validationSummary.Severity.IsAnError) return true;
            return DoShowValidationSummary(validationSummary, headerText, howToProceedMessage);
        }

        private bool DoShowValidationSummary(ValidationSummary validationSummary, string headerText, string howToProceedMessage)
        {
            using (new StandardMousePointer())
            {

                var sw = new ValidationSummaryWindow(ValidationWPFL8nService);
                sw.Title = ValidationWPFL8nService.DialogTitle;
                sw.Header = String.IsNullOrWhiteSpace(headerText) ? ValidationWPFL8nService.Header : headerText;
                if (!String.IsNullOrWhiteSpace(howToProceedMessage))
                    sw.HowToProceedMessage = howToProceedMessage;
                sw.ValidationSummary = validationSummary;
                var res = sw.ShowDialog();
                return res ?? false;
            }
        }
    }
}
