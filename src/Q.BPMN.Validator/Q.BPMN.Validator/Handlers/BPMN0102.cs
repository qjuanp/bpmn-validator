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
            Debug.WriteLine("Validate::{0}-{1}", Type.ToString(), Id);
            XDocument currentDocument = context.Document;

            IEnumerable<string> endEventsIds = from el in currentDocument
                                                    .Descendants(XName.Get("EndEvent", XPDLDefinition.SCHEMA))
                                                    .Ancestors(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                               select el.Attribute("Id").Value;


            IEnumerable<string> otherActivitiesIds = (from act in currentDocument
                                                        .Descendants(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                                      join endEv in endEventsIds
                                                                 on act.Attribute("Id").Value equals endEv
                                                                 into ps
                                                      from p in ps.DefaultIfEmpty()
                                                      select new { ActivityId = p == null ? act.Attribute("Id").Value : string.Empty })
                                                    .Select(acid => acid.ActivityId);

            IEnumerable<string> activitiesWithErrors = (from act in otherActivitiesIds
                                                        join tr in currentDocument
                                                                     .Descendants(XName.Get("Transition", XPDLDefinition.SCHEMA))
                                                                 on act equals tr.Attribute("From").Value
                                                                 into ps
                                                        from p in ps.DefaultIfEmpty()
                                                        select new { ActivityId = p == null ? act : string.Empty })
                                                        .Select(acid => acid.ActivityId);

            var queryActivityWithError = from ac in currentDocument
                                                        .Descendants(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                         from id in activitiesWithErrors
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
                    Message = string.Format("Activity '{0}' must have an outgoing sequence flow", activity.Attribute("Name").Value)
                });
            }
        }

    }
}
