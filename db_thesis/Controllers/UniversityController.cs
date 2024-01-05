using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using db_thesis.Models;
using db_thesis.Utility;

namespace db_thesis.Controllers
{

	public class UniversityController : Controller
	{
		private readonly IUniversityRepository _universityRepository;
		
		

		public UniversityController(IUniversityRepository universityRepository)
		{
			_universityRepository = universityRepository;
			
			
		}


	
		public IActionResult Index()
		{
			List<University> objUniversityList = _universityRepository.GetAll().ToList();
			return View(objUniversityList);
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
				University? universityVt = _universityRepository.Get(u => u.UniversityId == id);  // Expression<Func<T, bool>> filtre
				if (universityVt == null)
				{
					return NotFound();
				}
				return View(universityVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(University university)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				

				if (university.UniversityId == 0)
				{
					_universityRepository.Ekle(university);
					TempData["basarili"] = "Yeni University başarıyla oluşturuldu!";
				}
				else
				{
					_universityRepository.Guncelle(university);
					TempData["basarili"] = "University Güncelleme Başarılı!";
				}

				_universityRepository.Kaydet(); 			
				return RedirectToAction("Index", "University");
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
			University? universityVt = _universityRepository.Get(u => u.UniversityId == id);
			if (universityVt == null)
			{
				return NotFound();
			}
			return View(universityVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			University? universityVt = _universityRepository.Get(u => u.UniversityId == id);
			if (universityVt == null)
			{
				return NotFound();
			}
			_universityRepository.Sil(universityVt);
			_universityRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "University");
		}
	}
}

