using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.BPMN.Validator.Handlers
{
    public class Style0122 : Validation
    {
        public Style0122(Validation successor)
            :base(successor)
        { }
        protected override string Id
        {
            get { return "0122"; }
        }

        protected override Enums.ValidationType Type
        {
            get { return Enums.ValidationType.Style; }
        }

        public override void Validate(Contexts.ValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
