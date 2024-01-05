using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using db_thesis.Models;
using db_thesis.Utility;

namespace db_thesis.Controllers
{

	public class InstitueController : Controller
	{
		private readonly IInstitueRepository _institueRepository;
		private readonly IUniversityRepository _universityRepository;
		

		public InstitueController(IInstitueRepository institueRepository, IUniversityRepository universityRepository)
		{
			_institueRepository = institueRepository;
			_universityRepository = universityRepository;
			
		}


	
		public IActionResult Index()
		{
			List<Institue> objInstitueList = _institueRepository.GetAll(includeProps: "University").ToList();
			return View(objInstitueList);
		}


		// Get
		
		public IActionResult EkleGuncelle(int? id)
		{
			IEnumerable<SelectListItem> UniversityList = _universityRepository.GetAll()
				.Select(k => new SelectListItem
				{
					Text = k.UniversityName,
					Value = k.UniversityId.ToString()
				});
			ViewBag.UniversityList = UniversityList;
			if (id == null || id == 0)
			{
				// ekle
				return View();
			}
			else
			{
				// guncelleme
				Institue? institueVt = _institueRepository.Get(u => u.InstitueId == id);  // Expression<Func<T, bool>> filtre
				if (institueVt == null)
				{
					return NotFound();
				}
				return View(institueVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(Institue institue)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				

				if (institue.InstitueId == 0)
				{
					_institueRepository.Ekle(institue);
					TempData["basarili"] = "Yeni institue başarıyla oluşturuldu!";
				}
				else
				{
					_institueRepository.Guncelle(institue);
					TempData["basarili"] = "Yazar Güncelleme Başarılı!";
				}

				_institueRepository.Kaydet(); // SaveChanges() yapmazsanız bilgiler veri tabanına eklenmez!			
				return RedirectToAction("Index", "Institue");
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
			Institue? institueVt = _institueRepository.Get(u => u.InstitueId == id, includeProps: "University");
			if (institueVt == null)
			{
				return NotFound();
			}
			return View(institueVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			Institue? institue = _institueRepository.Get(u => u.InstitueId == id, includeProps: "University");
			if (institue == null)
			{
				return NotFound();
			}
			
			_institueRepository.Sil(institue);
			_institueRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "Institue");
		}
	}
}

