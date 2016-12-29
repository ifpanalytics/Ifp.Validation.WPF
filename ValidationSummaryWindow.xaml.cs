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
    public partial class ValidationSummaryWindow : Window
    {
        public static readonly DependencyProperty ValidationSummaryProperty =
            DependencyProperty.Register("ValidationSummary", typeof(ValidationSummary), typeof(ValidationSummaryWindow), new UIPropertyMetadata());

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ValidationSummaryWindow), new UIPropertyMetadata("Ergebnis der Prüfung"));

        public static readonly DependencyProperty HowToProceedMessageProperty =
            DependencyProperty.Register("HowToProceedMessage", typeof(string), typeof(ValidationSummaryWindow), new UIPropertyMetadata(""));
        
       
        abstract class WindowCommandBase : ICommand
        {
            readonly ValidationSummaryWindow _Owner;

            public event EventHandler CanExecuteChanged;

            public WindowCommandBase(ValidationSummaryWindow owner)
            {
                _Owner = owner;
            }
            protected ValidationSummaryWindow Owner
            {
                get { return _Owner; }
            }

            public virtual bool CanExecute(object parameter)
            {
                return true;
            }

            protected virtual void OnCanExecuteChanged()
            {
                var tmp = CanExecuteChanged;
                if (tmp == null) return;
                tmp(this, EventArgs.Empty);
            }
            public abstract void Execute(object parameter);
        }

        class OkCommandClass : WindowCommandBase
        {
            public OkCommandClass(ValidationSummaryWindow owner)
                : base(owner)
            {

            }
            public override void Execute(object parameter)
            {
                Owner.DialogResult = true;
                Owner.Close();
            }
        }

        class CancelCommandClass : WindowCommandBase
        {
            public CancelCommandClass(ValidationSummaryWindow owner)
                : base(owner)
            {

            }

            public override void Execute(object parameter)
            {
                Owner.DialogResult = false;
                Owner.Close();
            }
        }

        readonly ICommand _OkCommand;
        readonly ICommand _CancelCommand;

        public ValidationSummaryWindow()
        {
            _OkCommand = new OkCommandClass(this);
            _CancelCommand = new CancelCommandClass(this);
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
        public ICommand OkCommand
        {
            get { return _OkCommand; }
        }
        public ICommand CancelCommand
        {
            get { return _CancelCommand; }
        }
    }
}
