using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using db_thesis.Models;
using db_thesis.Utility;

namespace db_thesis.Controllers
{

	public class PersonController : Controller
	{
		private readonly IPersonRepository _personRepository;
		

		public PersonController(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
			
		}


		
		public IActionResult Index()
		{
			List<Person> objPersonList = _personRepository.GetAll().ToList();
			return View(objPersonList);
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
				Person? personVt = _personRepository.Get(u => u.PersonId == id);  // Expression<Func<T, bool>> filtre
				if (personVt == null)
				{
					return NotFound();
				}
				return View(personVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(Person person)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				
				

				
				{
					
				}

				if (person.PersonId == 0)
				{
					_personRepository.Ekle(person);
					TempData["basarili"] = "Yeni İnsan başarıyla oluşturuldu!";
				}
				else
				{
					_personRepository.Guncelle(person);
					TempData["basarili"] = "İnsan güncelleme başarılı!";
				}

				_personRepository.Kaydet(); 		
				return RedirectToAction("Index", "Person");
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
			Person? personVt = _personRepository.Get(u => u.PersonId == id);
			if (personVt == null)
			{
				return NotFound();
			}
			
			return View(personVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			Person? person = _personRepository.Get(u => u.PersonId == id);
			if (person == null)
			{
				return NotFound();
			}
			_personRepository.Sil(person);
			_personRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "Person");
		}
	}
}
