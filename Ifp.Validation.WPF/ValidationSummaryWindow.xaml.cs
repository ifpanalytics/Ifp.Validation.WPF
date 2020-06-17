using Ifp.Validation.WPF.Commands;
using Ifp.Validation.WPF.Localization;
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
    /// Interaktionslogik für ValidationSummaryWindow.xaml
    /// </summary>
    public partial class ValidationSummaryWindow : Window
    {
        public static readonly DependencyProperty ValidationSummaryProperty =
            DependencyProperty.Register("ValidationSummary", typeof(ValidationSummary), typeof(ValidationSummaryWindow), new UIPropertyMetadata());

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ValidationSummaryWindow), new UIPropertyMetadata("Ergebnis der Prüfung"));

        public static readonly DependencyProperty HowToProceedMessageProperty =
            DependencyProperty.Register("HowToProceedMessage", typeof(string), typeof(ValidationSummaryWindow), new UIPropertyMetadata(""));

        public static readonly DependencyProperty ValidationWPFL8nServiceProperty =
            DependencyProperty.Register("ValidationWPFL8nService", typeof(IValidationWPFL8nService), typeof(ValidationSummaryWindow), new PropertyMetadata());

        public ValidationSummaryWindow()
        {
            OkCommand = new OkCommand(this);
            CancelCommand = new CancelCommand(this);
            CopyToClipboardCommand = new CopyToClipboardCommand();
            InitializeComponent();
        }
        public ValidationSummary ValidationSummary
        {
            get { return (ValidationSummary)GetValue(ValidationSummaryProperty); }
            set { SetValue(ValidationSummaryProperty, value); }
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public string HowToProceedMessage
        {
            get { return (string)GetValue(HowToProceedMessageProperty); }
            set { SetValue(HowToProceedMessageProperty, value); }
        }

        public IValidationWPFL8nService ValidationWPFL8nService
        {
            get { return (IValidationWPFL8nService)GetValue(ValidationWPFL8nServiceProperty); }
            set { SetValue(ValidationWPFL8nServiceProperty, value); }
        }

        public ICommand OkCommand { get; }

        public ICommand CancelCommand { get; }

        public ICommand CopyToClipboardCommand { get; }
    }
}
