using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ifp.Validation.WPF
{
    /// <summary>
    /// Interaktionslogik für ValidationSummaryButtons.xaml
    /// </summary>
    public partial class ValidationSummaryButtons : UserControl
    {
        public static readonly DependencyProperty ValidationSummaryProperty =
            DependencyProperty.Register("ValidationSummary", typeof(ValidationSummary), typeof(ValidationSummaryButtons), new UIPropertyMetadata(OnValidationSummaryPropertyChanged));

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(ValidationSummaryButtons), new UIPropertyMetadata(OnCancelCommandPropertyChanged));

        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(ICommand), typeof(ValidationSummaryButtons), new UIPropertyMetadata(OnOkCommandPropertyChanged));

        public ValidationSummaryButtons()
        {
            InitializeComponent();
        }

        static void OnValidationSummaryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newSummary = e.NewValue as ValidationSummary;
            EnableCommands(d as ValidationSummaryButtons, newSummary == null ? null : newSummary.Severity);
        }

        static void OnCancelCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as ValidationSummaryButtons;
            t.bt_Cancel.Command = e.NewValue as ICommand;
        }

        static void OnOkCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as ValidationSummaryButtons;
            t.bt_Ok.Command = e.NewValue as ICommand;
        }
        private static void EnableCommands(ValidationSummaryButtons d, ValidationSeverity validationSeverity)
        {
            var causesCancel = validationSeverity == null ? false : validationSeverity.CausesCancel;
            var allowsCancel = validationSeverity==null?false:validationSeverity.AllowsCancel;
            d.bt_Ok.IsEnabled = !causesCancel;
            d.bt_Cancel.Visibility = (causesCancel || allowsCancel) ? Visibility.Visible : Visibility.Collapsed; 
        }

        public ValidationSummary ValidationSummary
        {
            get { return (ValidationSummary)GetValue(ValidationSummaryProperty); }
            set { SetValue(ValidationSummaryProperty, value); }
        }
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public ICommand OkCommand
        {
            get { return (ICommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }
    }
}
