using Microsoft.AspNetCore.Mvc;

namespace Game_Hub.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Тут можна додати логіку (наприклад, перевірку авторизації чи кількості сповіщень),
            // але поки що просто повертаємо представлення компонента
            return View("NavbarMenu");
        }
    }
}