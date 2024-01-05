using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using db_thesis.Models;
using db_thesis.Utility;

namespace db_thesis.Controllers
{

	public class SupervisorController : Controller
	{
		private readonly ISupervisorRepository _supervisorRepository;
		private readonly IPersonRepository _personRepository;
		

		public SupervisorController(ISupervisorRepository supervisorRepository, IPersonRepository personRepository)
		{
			_supervisorRepository = supervisorRepository;
			_personRepository = personRepository;
			
		}


	
		public IActionResult Index()
		{
			List<Supervisor> objSupervisorList = _supervisorRepository.GetAll(includeProps: "Person").ToList();
			return View(objSupervisorList);
		}


		// Get
		
		public IActionResult EkleGuncelle(int? id)
		{
			IEnumerable<SelectListItem> PersonList = _personRepository.GetAll()
				.Select(k => new SelectListItem
				{
					Text = k.Name,
					Value = k.PersonId.ToString()
				});
			ViewBag.PersonList = PersonList;
			if (id == null || id == 0)
			{
				// ekle
				return View();
			}
			else
			{
				// guncelleme
				Supervisor? supervisorVt = _supervisorRepository.Get(u => u.SupervisorId == id);  // Expression<Func<T, bool>> filtre
				if (supervisorVt == null)
				{
					return NotFound();
				}
				return View(supervisorVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(Supervisor supervisor)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				

				if (supervisor.SupervisorId == 0)
				{
					_supervisorRepository.Ekle(supervisor);
					TempData["basarili"] = "Yeni Supervisor başarıyla oluşturuldu!";
				}
				else
				{
					_supervisorRepository.Guncelle(supervisor);
					TempData["basarili"] = "Supervisor Güncelleme Başarılı!";
				}

				_supervisorRepository.Kaydet(); // SaveChanges() yapmazsanız bilgiler veri tabanına eklenmez!			
				return RedirectToAction("Index", "Supervisor");
			}
			return View();
		}



		// GET ACTION
	
		public IActionResult Sil(int? id)
		{
            IEnumerable<SelectListItem> PersonList = _personRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.PersonId.ToString()
                });
            ViewBag.PersonList = PersonList;
            if (id == null || id == 0)
			{
				return NotFound();
			}
			Supervisor? supervisorVt = _supervisorRepository.Get(u => u.SupervisorId == id);
			if (supervisorVt == null)
			{
				return NotFound();
			}
			return View(supervisorVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			Supervisor? supervisor = _supervisorRepository.Get(u => u.SupervisorId == id);
			if (supervisor == null)
			{
				return NotFound();
			}
			_supervisorRepository.Sil(supervisor);
			_supervisorRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "Supervisor");
		}
	}
}

