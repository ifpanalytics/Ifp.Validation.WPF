using Ifp.Validation.WPF.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ifp.Validation.WPF.Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResetLastResult();
        }

        private static ValidationSummary GetTestValidationSummary()
        {
            var vsBuilder = new ValidationSummaryBuilder();
            vsBuilder.Append(TextTemplates.MessageInfoBithdate.ToFailure(FailureSeverity.Information));
            vsBuilder.Append(TextTemplates.MessageWarningPassword.ToFailure(FailureSeverity.Warning));
            vsBuilder.Append(TextTemplates.MessageErrorEmail.ToFailure(FailureSeverity.Error));
            vsBuilder.Append(TextTemplates.MessageErrorSurname.ToFailure(FailureSeverity.Error));
            vsBuilder.Append(ValidationOutcome.Success);
            return vsBuilder.ToSummary();
        }
        private void SetLastResult(bool result) => sbi_LastResult.Content = $"Last validation result: {result}";
        private void ResetLastResult() => sbi_LastResult.Content = "Waiting for validation dialog.";

        private void bt_Example1_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = GetTestValidationSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary);
            SetLastResult(result);
        }


        private void bt_Example2_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = GetTestValidationSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_de_DE());
            var result = summaryPresenter.ShowValidationSummary(summary);
            SetLastResult(result);
        }

        private void bt_Example3_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = GetTestValidationSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary, true, "Custom header", "How to proceed..");
            SetLastResult(result);
        }

        private void bt_Example4_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = TextTemplates.MessageWarningPassword.ToFailure(FailureSeverity.Warning).ToSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary);
            SetLastResult(result);
        }
        private void bt_Example5_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = TextTemplates.MessageInfoBithdate.ToFailure(FailureSeverity.Information).ToSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary);
            SetLastResult(result);
        }
        private void bt_Example6_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = ValidationOutcome.Success.ToSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary);
            SetLastResult(result);
        }
        private void bt_Example7_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = ValidationOutcome.Success.ToSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary, true);
            SetLastResult(result);
        }

        private void bt_Example8_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var vsBuilder = new ValidationSummaryBuilder();
            var r = new Random(0);
            for (int i = 0; i < 30; i++)
                vsBuilder.Append(TextTemplates.BlindTexts[r.Next(TextTemplates.BlindTexts.Length)].ToFailure((FailureSeverity)r.Next(3)));
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(vsBuilder.ToSummary(), true, "Example 8", "Resize the window, to see layout changes.");
            SetLastResult(result);
        }
    }
}