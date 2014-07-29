using Q.BPMN.Validator.Contexts;
using Q.BPMN.Validator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.BPMN.Validator
{
    public abstract class Validation
    {
        private Validation()
        { }
        protected Validation(Validation succesor)
        {
            Successor = succesor;
        }

        protected abstract string Id { get; }
        protected abstract ValidationType Type { get; }
        protected Validation Successor { get; set; }
        public abstract void Validate(ValidationContext context);
    }
}
