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
    /// Interaktionslogik für ValidationSummaryWindow.xaml
    /// </summary>
    public partial class ValidationSummaryPresenter : UserControl
    {
        public static readonly DependencyProperty ValidationSummaryProperty =
            DependencyProperty.Register("ValidationSummary", typeof(ValidationSummary), typeof(ValidationSummaryPresenter), new UIPropertyMetadata(OnValidationSummaryPropertyChanged));

        public ValidationSummaryPresenter()
        {
            InitializeComponent();
        }

        static void OnValidationSummaryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var presenter = d as ValidationSummaryPresenter;
            var summary = e.NewValue as ValidationSummary;
            presenter.tb_Empty.Visibility = summary == null || !summary.ValidationFailures.Any()? Visibility.Visible : Visibility.Collapsed;
            presenter.ic_ValidationSummary.Visibility = presenter.tb_Empty.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public ValidationSummary ValidationSummary
        {
            get { return (ValidationSummary)GetValue(ValidationSummaryProperty); }
            set { SetValue(ValidationSummaryProperty, value); }
        }
    }
}
