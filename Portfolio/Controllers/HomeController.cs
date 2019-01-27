using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var viewModel = new ContactViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Contact(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage Message = new MailMessage();
                    SmtpClient Smtp = new SmtpClient();
                    System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential();

                    Message.From = new MailAddress(viewModel.Email);
                    Message.To.Add(new MailAddress(""));
                    Message.IsBodyHtml = false;
                    Message.Subject = "Question on website";
                    Message.Body = $"{viewModel.Message} \n\n Details sender: {viewModel.LastName} {viewModel.FirstName} \n {viewModel.Phone} \n {viewModel.Email} \n";

                    SmtpUser.UserName = "";
                    SmtpUser.Password = "";

                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = SmtpUser;
                    Smtp.Port = 587;
                    Smtp.Host = "smtp.mijnhostingpartner.nl";
                    Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Smtp.Send(Message);

                    TempData[Constants.SuccessMessage] = $"Thank you for your message, Mr./Mrs. {viewModel.LastName}. I will respond to your message as soon as possible.";
                    return new RedirectToActionResult("Contact", "Home", null);

                }
                catch (Exception)
                {
                    TempData[Constants.FailedMessage] = $"An error occured while sending your message.<br />Please try again later.";
                    return View();
                }
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
