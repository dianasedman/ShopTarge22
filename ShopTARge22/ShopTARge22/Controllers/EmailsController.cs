using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MailKit.Net.Smtp;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Models;

namespace ShopTARge22.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailsController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {
            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body
            };
            _emailServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }

    }
}
