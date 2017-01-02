using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ifp.Validation.WPF.Localization
{
    public class ValidationWPFL8nService : IValidationWPFL8nService
    {
        public string Cancel => "Cancel";
        public string DialogTitle => "Validation result";
        public string Header => "Validation result";
        public string OK => "OK";
        public string ValidationSuccessful => "Validation successful!";
    }
    public class ValidationWPFL8nService_en_US: ValidationWPFL8nService
    {
    }
    public class ValidationWPFL8nService_de_DE : IValidationWPFL8nService
    {
        public string Cancel => "Abbrechen";
        public string DialogTitle => "Prüfergebnis";
        public string Header => "Ergebnis der Prüfung";
        public string OK => "OK";
        public string ValidationSuccessful => "Gültigkeitsprüfung erfolgreich!";
    }
}
