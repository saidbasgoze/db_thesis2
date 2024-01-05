using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using db_thesis.Models;
using db_thesis.Utility;

namespace db_thesis.Controllers
{

	public class AuthorController : Controller
	{
		private readonly IAuthorRepository _authorRepository;
		private readonly IPersonRepository _personRepository;
		

		public AuthorController(IAuthorRepository authorRepository, IPersonRepository personRepository)
		{
			_authorRepository = authorRepository;
			_personRepository = personRepository;
			
		}


	
		public IActionResult Index()
		{
			List<Author> objAuthorList = _authorRepository.GetAll(includeProps: "Person").ToList();
			return View(objAuthorList);
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
				Author? authorVt = _authorRepository.Get(u => u.AuthorId == id);  // Expression<Func<T, bool>> filtre
				if (authorVt == null)
				{
					return NotFound();
				}
				return View(authorVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(Author author)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				

				if (author.AuthorId == 0)
				{
					_authorRepository.Ekle(author);
					TempData["basarili"] = "Yeni Yazar başarıyla oluşturuldu!";
				}
				else
				{
					_authorRepository.Guncelle(author);
					TempData["basarili"] = "Yazar Güncelleme Başarılı!";
				}

				_authorRepository.Kaydet(); // SaveChanges() yapmazsanız bilgiler veri tabanına eklenmez!			
				return RedirectToAction("Index", "Author");
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
			Author? authorVt = _authorRepository.Get(u => u.AuthorId == id);
			if (authorVt == null)
			{
				return NotFound();
			}
            
            return View(authorVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{
			Author? author = _authorRepository.Get(u => u.AuthorId == id);
			if (author == null)
			{
				return NotFound();
			}
			_authorRepository.Sil(author);
			_authorRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "Author");
		}
	}
}

