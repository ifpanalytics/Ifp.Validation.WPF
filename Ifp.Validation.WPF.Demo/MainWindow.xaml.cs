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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResetLastResult();
        }

        private static ValidationSummary GetTestValidationSummary()
        {
            var rule1 = new ValidationRuleDelegate<int>(_ => "A custom information message.".ToFailure(FailureSeverity.Information));
            var rule2 = new ValidationRuleDelegate<int>(_ => "A custom warning message.".ToFailure(FailureSeverity.Warning));
            var rule3 = new ValidationRuleDelegate<int>(_ => "A custom error message.".ToFailure(FailureSeverity.Error));
            var rule4 = new ValidationRuleDelegate<int>(_ => ValidationOutcome.Success);
            var validator = new RuleBasedValidator<int>(rule1, rule2, rule3, rule4);
            var summary = validator.Validate(0);
            return summary;
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
            var summary = "Custom warning message".ToFailure(FailureSeverity.Warning).ToSummary();
            var summaryPresenter = new ValidationSummaryPresentationService(new ValidationWPFL8nService_en_US());
            var result = summaryPresenter.ShowValidationSummary(summary);
            SetLastResult(result);
        }
        private void bt_Example5_Click(object sender, RoutedEventArgs e)
        {
            ResetLastResult();
            var summary = "Custom information message".ToFailure(FailureSeverity.Information).ToSummary();
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
    }
}
