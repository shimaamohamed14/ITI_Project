using ITI_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    public class AIController : Controller
    {
        private readonly AIService _aiService;
        public AIController(AIService aiService)
        {
            _aiService = aiService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ask(string question)
        {
            var answer = await _aiService.AskAI(question);

            ViewBag.Answer = answer;

            return View("Index");
        }
    }
}
