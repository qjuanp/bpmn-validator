using Q.BPMN.Validator.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Q.BPMN.Validator
{
    public class XdplValidator
    {
        private readonly Validation validationHandler;
        public XdplValidator(Validation validationHandler)
        {
            this.validationHandler = validationHandler;
        }

        public ValidationContext Validate(string fileName, XDocument document)
        {
            ValidationContext context = null;

            if (document == null) throw new ArgumentNullException("document");

            context = new ValidationContext(fileName, document);

            validationHandler.Validate(context);

            return context;
        }
    }
}
