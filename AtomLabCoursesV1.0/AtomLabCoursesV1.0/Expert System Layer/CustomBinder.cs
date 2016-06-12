using NxBRE.InferenceEngine;
using NxBRE.InferenceEngine.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomLabCoursesV1._0.Expert_System_Layer
{
    public class CustomBinder : AbstractBinder
    {
        public CustomBinder() : base(BindingTypes.BeforeAfter) { }

        public override void BeforeProcess()
        {
        }

        public override bool Evaluate(object predicate, string function, string[] arguments)
        {
            if (function == "min_Arg0")
            {
                return Convert.ToInt32(predicate) > Convert.ToInt32(arguments[0]);
            }
            else if (function == "nextlevel_Arg0")
                return Convert.ToInt32(predicate) == Convert.ToInt32(arguments[0]) + 1;
            throw new Exception("Binder can not evaluate " + function);
        }

        public override NewFactEvent OnNewFact
        {
            get
            {
                return new NewFactEvent(NewFactHandler);
            }
        }

        private void NewFactHandler(NewFactEventArgs nfea)
        {
            //MessageBox.Show(" l " + nfea.Fact.GetPredicateValue(0).GetType().ToString());
           // if (nfea.Fact.Type == "Fraudulent Customer")
               // ((Customer)nfea.Fact.GetPredicateValue(0)).Fraudulent = true;
        }
    }

}