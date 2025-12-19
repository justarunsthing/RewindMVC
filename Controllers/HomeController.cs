using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RewindMVC.Models;

namespace RewindMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult App()
        {
            var model = new Rewind();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(Rewind model)
        {
            if (!string.IsNullOrEmpty(model.Input))
            {
                var userInput = model.Input.ToLower().Replace(" ", "");
                var reversedInput = string.Empty;

                for (int i = userInput.Length - 1; i >= 0; i--)
                {
                    reversedInput += userInput[i];
                }

                model.Result = reversedInput;
                model.Message = $"The reversed string is \"{model.Result}\"";
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
