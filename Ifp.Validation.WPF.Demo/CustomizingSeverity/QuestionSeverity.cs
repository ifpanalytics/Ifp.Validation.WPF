using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifp.Validation.WPF.Demo.CustomizingSeverity
{
    public class QuestionSeverity : ValidationSeverity
    {
        public static QuestionSeverity Instance = new QuestionSeverity();
        private QuestionSeverity()
        {

        }
        public override bool AllowsCancel => true;

        public override bool CausesCancel => false;

        // This number is responsible for: sort order of outcomes (descending) and the overall outcome (maximum wins).
        protected override int SeverityAsNumber => 0;
    }

    public class QuestionOutcome : ValidationOutcomeWithMessage
    {
        public QuestionOutcome(string message):base(message)
        {

        }

        public override ValidationSeverity Severity => QuestionSeverity.Instance;
    }
}
