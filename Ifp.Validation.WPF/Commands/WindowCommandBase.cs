using Ifp.Validation.WPF.Commands;

namespace Ifp.Validation.WPF
{
    abstract class WindowCommandBase : CommandBase
    {
        public WindowCommandBase(ValidationSummaryWindow owner)
        {
            Owner = owner;
        }

        protected ValidationSummaryWindow Owner { get; }
    }
}
