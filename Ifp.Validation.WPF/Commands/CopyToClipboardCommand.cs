using Ifp.Validation.WPF.CopyToClipboard;
using Ifp.Validation.WPF.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Ifp.Validation.WPF.Commands
{
    class CopyToClipboardCommand : CommandBase
    {

        public CopyToClipboardCommand(IValidationWPFL8nService validationWPFL8NService)
        {
            ValidationWPFL8NService = validationWPFL8NService;
        }
        protected IValidationWPFL8nService ValidationWPFL8NService { get; }

        public override bool CanExecute(object parameter) 
            => parameter is ValidationSummary summary && summary.ValidationFailures.Any();

        public override void Execute(object parameter)
        {
            if (parameter is ValidationSummary summary)
            {
                var outcomeAsText = FormatOutcomeAsText(summary.ValidationFailures);
                var outcomeAsHtml = FormatOutcomeAsHtml(summary.ValidationFailures);
                HtmlClipboardHelper.CopyToClipboard(outcomeAsHtml, outcomeAsText);
            }
        }

        private string FormatOutcomeAsHtml(IEnumerable<ValidationOutcomeWithMessage> validationOutcomes)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<table>");
            validationOutcomes.Aggregate(sb, (sb1, outcome) =>
            {
                var icon = GetSeverityIcon(outcome.Severity);
                var color = GetSeverityColor(outcome.Severity);
                sb1.AppendLine("  <tr>");
                sb1.AppendLine("    <td>");
                sb1.AppendLine($@"      <p style=""color:{color}; text-align: center;"">{icon}</p>");
                sb1.AppendLine("    </td>");
                sb1.AppendLine("    <td>");
                sb1.AppendLine(WebUtility.HtmlEncode(outcome.ErrorMessage));
                sb1.AppendLine("    </td>");
                sb1.AppendLine("  </tr>");
                return sb1;
            });
            sb.AppendLine("</table>");
            return sb.ToString();
        }

        private string FormatOutcomeAsText(IEnumerable<ValidationOutcomeWithMessage> validationOutcomes)
            => validationOutcomes.Aggregate(
                new StringBuilder(),
                (sb, outcome) => sb.AppendLine($"{GetSeverityText(outcome.Severity)}:	{outcome.ErrorMessage}"),
                sb => sb.ToString());

        private static string GetSeverityColor(ValidationSeverity severity)
        {
            // https://coolors.co/191970-b8860b-b22222-000000
            switch (severity)
            {
                case ValidationSeverity.InformationSeverity _: return "MidnightBlue";
                case ValidationSeverity.WarningSeverity _: return "DarkGoldenRod";
                case ValidationSeverity.ErrorSeverity _: return "FireBrick"; 
                default: return "Black";
            }
        }

        private static string GetSeverityIcon(ValidationSeverity severity)
        {
            switch (severity)
            {
                case ValidationSeverity.InformationSeverity _: return "ℹ"; //Information Source Emoji https://unicode-table.com/en/2139/
                case ValidationSeverity.WarningSeverity _: return "⚠"; //Warning Sign Emoji https://unicode-table.com/en/26A0/
                case ValidationSeverity.ErrorSeverity _: return "❌"; //Cross Mark Emoji https://unicode-table.com/en/274C/
                default: return " "; //No-Break Space https://unicode-table.com/en/00A0/
            }
        }

        private string GetSeverityText(ValidationSeverity severity)
        {
            switch (severity)
            {
                case ValidationSeverity.InformationSeverity _: return ValidationWPFL8NService.SeverityInfomation;
                case ValidationSeverity.WarningSeverity _: return ValidationWPFL8NService.SeverityWarning;
                case ValidationSeverity.ErrorSeverity _: return ValidationWPFL8NService.SeverityError;
                default: return ValidationWPFL8NService.SeverityUnknown;
            }
        }
    }
}
