namespace Ifp.Validation.WPF.Commands
{
    class OkCommand : WindowCommandBase
    {
        public OkCommand(ValidationSummaryWindow owner)
            : base(owner)
        {

        }

        public override void Execute(object parameter)
        {
            Owner.DialogResult = true;
            Owner.Close();
        }
    }
}
