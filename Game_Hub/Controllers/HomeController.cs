using Game_Hub.Models;
using Game_Hub.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Game_Hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender; // Додаємо сервіс пошти

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Відображення форми зворотного зв'язку (Пункт 5)
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Browse()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Streams()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        // Обробка форми при натисканні Submit (Пункт 6)
        [HttpPost]
        public async Task<IActionResult> Contact(EmailMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(
                    model.Email,
                    string.IsNullOrEmpty(model.Subject) ? "Повідомлення з Game Hub" : model.Subject,
                    model.Message
                );
                ViewBag.SuccessMessage = "Повідомлення успішно надіслано!";
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult SubmitGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitGame(GameSubmissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Повертаємо форму з помилками валідації
            }

            TempData["SuccessMessage"] = "Форму успішно заповнено та провалідовано!";
            return RedirectToAction("SubmitGame");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}