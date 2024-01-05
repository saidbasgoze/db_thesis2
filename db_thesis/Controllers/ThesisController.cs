using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using db_thesis.Models;
using db_thesis.Models.db_thesis.Models;

namespace db_thesis.Controllers
{

	public class ThesisController : Controller
	{
		private readonly IThesisRepository _thesisRepository;
		private readonly IAuthorRepository _authorRepository;
		private readonly ISupervisorRepository _supervisorRepository;
		private readonly IThesisTypeRepository _thesisTypeRepository;
        private readonly ILanguageRepository _languageRepository;
		private readonly IUniversityRepository _universityRepository;


		public ThesisController(IThesisRepository thesisRepository, IAuthorRepository authorRepository, ISupervisorRepository supervisorRepository,IPersonRepository personRepository,IThesisTypeRepository thesisTypeRepository, ILanguageRepository languageRepository, IUniversityRepository universityRepository)
		{
			_thesisRepository = thesisRepository;
			_authorRepository = authorRepository;
			_supervisorRepository = supervisorRepository;
			_thesisTypeRepository= thesisTypeRepository;
            _languageRepository = languageRepository;
			_universityRepository = universityRepository;


        }

		//includeProps: "Author,Supervisor"

		public IActionResult Index()
		{
			List<Thesis> objThesisList = _thesisRepository.GetAll(includeProps: "Author.Person,Supervisor.Person,ThesisType,Language,University").ToList();
			return View(objThesisList);
		}

		public IActionResult Details(int id)
		{
			Thesis thesis = _thesisRepository.Get(u => u.ThesisId == id, includeProps: "Author.Person,Supervisor.Person,ThesisType,Language,University");

			if (thesis == null)
			{
				return NotFound();
			}

			return View(thesis);
		}

       


        // Get



        public IActionResult EkleGuncelle(int? id)
			{
			
			IEnumerable<SelectListItem> AuthorList = _authorRepository.GetAll(includeProps:"Person")
					.Select(k => new SelectListItem
					{
						Text = k.Person !=null? k.Person.Name:"",
						Value = k.PersonId.ToString()
					});
			ViewBag.AuthorList = AuthorList; 

			IEnumerable<SelectListItem> SupervisorList = _supervisorRepository.GetAll(includeProps: "Person")
					.Select(k => new SelectListItem
					{
						Text = k.Person != null ? k.Person.Name : "",
						Value = k.PersonId.ToString()
					});
			ViewBag.SupervisorList = SupervisorList;

			IEnumerable<SelectListItem> ThesisTypeList = _thesisTypeRepository.GetAll()
					.Select(k => new SelectListItem
					{
						Text = k.TypeName,
						Value = k.TypeId.ToString()
					});
			ViewBag.ThesisTypeList = ThesisTypeList;


            IEnumerable<SelectListItem> LanguageList = _languageRepository.GetAll()
                    .Select(k => new SelectListItem
                    {
                        Text = k.LanguageName,
                        Value = k.LanguageId.ToString()
                    });
            ViewBag.LanguageList = LanguageList;

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
				Thesis? thesisVt = _thesisRepository.Get(u => u.ThesisId == id, includeProps: "Author.Person,Supervisor.Person");  // Expression<Func<T, bool>> filtre
				if (thesisVt == null)
				{
					return NotFound();
				}
				return View(thesisVt);
			}

		}

		[HttpPost]
		
		public IActionResult EkleGuncelle(Thesis thesis)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				
				

				
				{
					
				}

				if (thesis.ThesisId == 0)
				{
					_thesisRepository.Ekle(thesis);
					TempData["basarili"] = "New Thesis created successfully!";
				}
				else
				{
					_thesisRepository.Guncelle(thesis);
					TempData["basarili"] = "Thesis updated successfully!";
				}

				_thesisRepository.Kaydet(); 			
				return RedirectToAction("Index", "Thesis");
			}
			return View();
		}



		// GET ACTION

		public IActionResult Sil(int? id)
		{
            IEnumerable<SelectListItem> AuthorList = _authorRepository.GetAll(includeProps: "Person")
                    .Select(k => new SelectListItem
                    {
                        Text = k.Person != null ? k.Person.Name : "",
                        Value = k.PersonId.ToString()
                    });
            ViewBag.AuthorList = AuthorList;

            IEnumerable<SelectListItem> SupervisorList = _supervisorRepository.GetAll(includeProps: "Person")
                    .Select(k => new SelectListItem
                    {
                        Text = k.Person != null ? k.Person.Name : "",
                        Value = k.PersonId.ToString()
                    });
            ViewBag.SupervisorList = SupervisorList;

            IEnumerable<SelectListItem> ThesisTypeList = _thesisTypeRepository.GetAll()
                    .Select(k => new SelectListItem
                    {
                        Text = k.TypeName,
                        Value = k.TypeId.ToString()
                    });
            ViewBag.ThesisTypeList = ThesisTypeList;


            IEnumerable<SelectListItem> LanguageList = _languageRepository.GetAll()
                    .Select(k => new SelectListItem
                    {
                        Text = k.LanguageName,
                        Value = k.LanguageId.ToString()
                    });
            ViewBag.LanguageList = LanguageList;

            IEnumerable<SelectListItem> UniversityList = _universityRepository.GetAll()
                   .Select(k => new SelectListItem
                   {
                       Text = k.UniversityName,
                       Value = k.UniversityId.ToString()
                   });
            ViewBag.UniversityList = UniversityList;
            if (id == null || id == 0)
			{
				return NotFound();
			}

			Thesis thesisVt = _thesisRepository.Get(u => u.ThesisId == id, includeProps: "Author.Person,Supervisor.Person");

			if (thesisVt == null)
			{
				return NotFound();
			}
			




			return View(thesisVt);
		}


		[HttpPost, ActionName("Sil")]
		
		public IActionResult SilPOST(int? id)
		{

			
			Thesis? thesis = _thesisRepository.Get(u => u.ThesisId == id);
			if (thesis == null)
			{
				return NotFound();
			}
			_thesisRepository.Sil(thesis);
			_thesisRepository.Kaydet();
			TempData["basarili"] = "Thesis deleted successfully!";
			return RedirectToAction("Index", "Thesis");
		}
	}
}
