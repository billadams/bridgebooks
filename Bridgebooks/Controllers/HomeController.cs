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
            SEOViewModel viewModel = new SEOViewModel
            {
                Description = "Bridge Books LLC specializes in small business and non-profit accounting.",
                Canonical = "/"
            };

            return View(viewModel);
        }

        [Route("OurTeam")]
        public ActionResult OurTeam()
        {
            SEOViewModel viewModel = new SEOViewModel
            {
                Description = "Bridge Books LLC has over 38 combined years experience in the financial and accounting industy.",
                Canonical = "/ourteam"
            };

            return View(viewModel);
        }

        [Route("Services")]
        public ActionResult Services()
        {
            SEOViewModel viewModel = new SEOViewModel
            {
                Description = "Bridge Books LLC provides accounting, bookkeeping, payroll, and financial consulting services.",
                Canonical = "/services"
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult Contact()
        {
            ContactViewModel viewModel = new ContactViewModel
            {
                SEOViewModel = new SEOViewModel
                {
                    Description = "Bridge Books LLC would like to hear your questions or concerns.",
                    Canonical = "/contact"
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("Contact")]
        public ActionResult Contact(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                EmailHelper emailHelper = new EmailHelper();

                var didSend = emailHelper.SendEmail(viewModel);

                if (!didSend)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }
            }
            else
            {
                viewModel.SEOViewModel = new SEOViewModel
                {
                    Description = "Bridge Books LLC would like to hear your questions or concerns.",
                    Canonical = "/contact"
                };

                return View(viewModel);
            }

            return View("~/Views/Home/ThankYou.cshtml", viewModel);
        }

        [Route("ThankYou")]
        public ActionResult ThankYou(ContactViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}