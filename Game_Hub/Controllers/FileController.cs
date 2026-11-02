using Microsoft.AspNetCore.Mvc;

namespace Game_Hub.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "Files");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                TempData["SuccessMessage"] = "Файл успішно завантажено на сервер!";
                return RedirectToAction(nameof(FileList));
            }

            ModelState.AddModelError("", "Будь ласка, оберіть файл для завантаження.");
            return View();
        }

        public IActionResult FileList()
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "Files");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var files = Directory.GetFiles(uploadsFolder)
                                 .Select(Path.GetFileName)
                                 .ToList();

            return View(files);
        }

        public IActionResult ViewFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return NotFound();
            }

            var filePath = Path.Combine(_env.WebRootPath, "Files", filename);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            ViewBag.FileName = filename;
            ViewBag.FileUrl = "/Files/" + filename;
            return View();
        }
    }
}