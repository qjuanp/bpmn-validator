using Q.BPMN.Validator.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Q.BPMN.Validator.Extensions;

namespace Q.BPMN.Validator.Handlers
{
    public class Style0123 : Validation
    {
        public Style0123(Validation successor)
            :base(successor)
        { }
        protected override string Id
        {
            get { return "0123"; }
        }

        protected override Enums.ValidationType Type
        {
            get { return Enums.ValidationType.Style; }
        }

        public override void Validate(Contexts.ValidationContext context)
        {
            Debug.WriteLine("Validate::{0}-{1}", Type.ToString(), Id);
            XDocument currentDocument = context.Document;

            var queryThrowMessages = from el in currentDocument
                                                    .Descendants(XName.Get("TriggerResultMessage", XPDLDefinition.SCHEMA))
                                     where el.HasAttributes && el.Attribute("CatchThrow").Value == "THROW"
                                     select el;

            var queryActivities = (from el in queryThrowMessages
                                   from ancestor in el.Ancestors(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                   select ancestor).ToList();

            var queryMessageFlow = (from ac in queryActivities
                                    join fl in currentDocument
                                                           .Descendants(XName.Get("MessageFlow", XPDLDefinition.SCHEMA))
                                            on ac.Attribute("Id").Value equals fl.Attribute("Source").Value into ps
                                    from p in ps.DefaultIfEmpty()
                                    select new { ActivityId = p == null ? ac.Attribute("Id").Value : string.Empty })
                                   .Select(acid => acid.ActivityId);

            var queryActivityWithError = from ac in currentDocument
                                                        .Descendants(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                         from id in queryMessageFlow
                                         where ac.Attribute("Id").Value == id
                                         select ac;

            if (queryActivityWithError.Count() > 0) ReportError(context, queryActivityWithError.ToList());

            if (Successor != null) Successor.Validate(context);
        }

        private void ReportError(Contexts.ValidationContext context, List<XElement> activities)
        {
            foreach (XElement activity in activities)
            {
                context.Errors.Add(new Models.ValidationError
                {
                    ElementId = new Guid(activity.Attribute("Id").Value),
                    ElementName = activity.Attribute("Name").Value,
                    ElementXPath = activity.GetAbsoluteXPath(),
                    Id = Id,
                    Type = Type,
                    Message = string.Format("Message '{0}' should have an incoming message", activity.Attribute("Name").Value)
                });
            }
        }
    }
}
