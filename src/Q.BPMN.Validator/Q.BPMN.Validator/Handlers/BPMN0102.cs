using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.BPMN.Validator.Handlers
{
    public class BPMN0102 : Validation
    {
        public BPMN0102(Validation successor)
            : base(successor)
        { }
        protected override string Id
        {
            get { return "0102"; }
        }

        protected override Enums.ValidationType Type
        {
            get { return Enums.ValidationType.BPMN; }
        }

        public override void Validate(Contexts.ValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
