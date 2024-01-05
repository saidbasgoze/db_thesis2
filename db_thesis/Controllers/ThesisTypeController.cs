using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using db_thesis.Models;
using db_thesis.Utility;
using db_thesis.Models.db_thesis.Models;

namespace db_thesis.Controllers
{

	public class ThesisTypeController : Controller
	{
		private readonly IThesisTypeRepository _thesisTypeRepository;
		
		

		public ThesisTypeController(IThesisTypeRepository thesisTypeRepository )
		{
			_thesisTypeRepository = thesisTypeRepository;
		
			
		}


	
		public IActionResult Index()
		{
			List<ThesisType> objThesisTypeList = _thesisTypeRepository.GetAll().ToList();
			return View(objThesisTypeList);
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
				ThesisType? thesisTypeVt = _thesisTypeRepository.Get(u => u.TypeId == id);  // Expression<Func<T, bool>> filtre
				if (thesisTypeVt == null)
				{
					return NotFound();
				}
				return View(thesisTypeVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(ThesisType thesisType)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				

				if (thesisType.TypeId == 0)
				{
					_thesisTypeRepository.Ekle(thesisType);
					TempData["basarili"] = "Yeni Thesis Type başarıyla oluşturuldu!";
				}
				else
				{
					_thesisTypeRepository.Guncelle(thesisType);
					TempData["basarili"] = "Thesis Type Güncelleme Başarılı!";
				}

				_thesisTypeRepository.Kaydet(); 		
				return RedirectToAction("Index", "ThesisType");
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
			ThesisType? thesisType = _thesisTypeRepository.Get(u => u.TypeId == id);
			if (thesisType == null)
			{
				return NotFound();
			}
			return View(thesisType);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			ThesisType? thesisType = _thesisTypeRepository.Get(u => u.TypeId == id);
			if (thesisType == null)
			{
				return NotFound();
			}
			_thesisTypeRepository.Sil(thesisType);
			_thesisTypeRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "ThesisType");
		}
	}
}

