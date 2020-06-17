using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ifp.Validation.WPF.Localization
{
    public interface IValidationWPFL8nService
    {
        string OK { get; }
        string Cancel { get; }
        string ValidationSuccessful { get; }
        string DialogTitle { get; }
        string Header { get; }
        string CopyToClipboard { get; }
        string SeverityInfomation { get; }
        string SeverityWarning { get; }
        string SeverityError { get; }
        string SeverityUnknown { get; }
    }
}
