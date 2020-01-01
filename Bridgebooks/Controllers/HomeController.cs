using Bridgebooks.Helpers;
using Bridgebooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bridgebooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("OurTeam")]
        public ActionResult OurTeam()
        {
            return View();
        }

        [Route("Services")]
        public ActionResult Services()
        {

            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmailHelper emailHelper = new EmailHelper();

                var didSend = emailHelper.SendEmail(model);

                if (!didSend)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }
            }
            else
            {
                return View(model);
            }

            return View("~/Views/Home/ThankYou.cshtml", model);
        }

        [Route("ThankYou")]
        public ActionResult ThankYou(ContactViewModel model)
        {
            return View(model);
        }
    }
}