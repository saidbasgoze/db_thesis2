using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using db_thesis.Models;
using db_thesis.Utility;

namespace db_thesis.Controllers
{

	public class LanguageController : Controller
	{
		private readonly ILanguageRepository _languageRepository;
		
		

		public LanguageController(ILanguageRepository languageRepository)
		{
			_languageRepository = languageRepository;
			
			
		}


	
		public IActionResult Index()
		{
			List<Language> objLanguageList = _languageRepository.GetAll().ToList();
			return View(objLanguageList);
		}


		// Get
		
		public IActionResult EkleGuncelle(int? id)
		{
			
			if (id == null || id == 0)
			{
				// ekle
				return View();
			}
			else
			{
				// guncelleme
				Language? languageVt = _languageRepository.Get(u => u.LanguageId == id);  // Expression<Func<T, bool>> filtre
				if (languageVt == null)
				{
					return NotFound();
				}
				return View(languageVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(Language language)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				

				if (language.LanguageId == 0)
				{
					_languageRepository.Ekle(language);
					TempData["basarili"] = "New Language was created succesfully!";
				}
				else
				{
					_languageRepository.Guncelle(language);
					TempData["basarili"] = "Language updated uccessfully!";
				}

				_languageRepository.Kaydet(); 			
				return RedirectToAction("Index", "Language");
			}
			return View();
		}



		// GET ACTION
	
		public IActionResult Sil(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Language? languageVt = _languageRepository.Get(u => u.LanguageId == id);
			if (languageVt == null)
			{
				return NotFound();
			}
			return View(languageVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			Language? languageVt = _languageRepository.Get(u => u.LanguageId == id);
			if (languageVt == null)
			{
				return NotFound();
			}
			_languageRepository.Sil(languageVt);
			_languageRepository.Kaydet();
			TempData["basarili"] = "Language deleted succesfully!";
			return RedirectToAction("Index", "Language");
		}
	}
}

