using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.BPMN.Validator.Handlers
{
    public class Style0115 : Validation
    {
        public Style0115(Validation successor)
            : base(successor)
        { }
        protected override string Id
        {
            get { return "0115"; }
        }

        protected override Enums.ValidationType Type
        {
            get { return Enums.ValidationType.Style; }
        }

        public override void Validate(Contexts.ValidationContext context)
        {
            Debug.WriteLine("Validate::{0}-{1}", Type.ToString(), Id);

            
        }
    }
}
