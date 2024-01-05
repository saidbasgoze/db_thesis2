using db_thesis.Models;
using Microsoft.AspNetCore.Mvc;

namespace db_thesis.Controllers
{
    // SearchController.cs
    public class SearchController : Controller
    {
        private readonly IThesisRepository _thesisRepository;

        public SearchController(IThesisRepository thesisRepository)
        {
            _thesisRepository = thesisRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Arama formunu gösteren view
        }

        [HttpPost]
        public IActionResult Index(string authorName, string supervisorName, string thesisTitle,string typeName, string universityName)
        {
            // Gelişmiş arama kriterlerini kullanarak veritabanından filtreleme yap
            var searchResults = _thesisRepository.AdvancedSearch(authorName, supervisorName, thesisTitle, typeName, universityName);

			if (searchResults.Count == 0)
			{
				// Arama sonuçları bulunamadıysa, uygun bir mesaj göster
				TempData["basarili"] = "Arama kriterlerinize uygun sonuç bulunamadı.";
			}

			// Sonuçları Index sayfasına gönder
			return View("~/Views/Thesis/Index.cshtml", searchResults);
        }
    }
}
