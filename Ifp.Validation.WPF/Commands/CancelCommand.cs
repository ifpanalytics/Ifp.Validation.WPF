namespace Ifp.Validation.WPF.Commands
{
    class CancelCommand : WindowCommandBase
    {
        public CancelCommand(ValidationSummaryWindow owner)
            : base(owner)
        {

        }

        public override void Execute(object parameter)
        {
            Owner.DialogResult = false;
            Owner.Close();
        }
    }
}
