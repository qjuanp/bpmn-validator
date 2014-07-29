using Q.BPMN.Validator.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Q.BPMN.Validator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly XdplValidator validator;
        public HomeController(XdplValidator validator)
        {
            this.validator = validator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validate()
        {
            HttpPostedFileBase file = null;
            XDocument document = null;
            ValidationContext context = null;

            if (Request != null)
            {
                file = Request.Files["XpdlFile"];

                if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName)) {
                    Debug.WriteLine("Validate::{0}",file.FileName);

                    document = XDocument.Load(file.InputStream);
                    context = validator.Validate(file.FileName, document);

                    Debug.WriteLine(context.Model.ToString());
                }
            }
            return View("Index");
        }

        public ActionResult About()
        {
            return Redirect("https://github.com/qjuanp/bpmn-validator");
        }

        public ActionResult Contact()
        {
            return Redirect("http://about.me/qjuanp");
        }
    }
}