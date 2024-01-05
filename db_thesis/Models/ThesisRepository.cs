namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;
    using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace db_thesis.Models
    { 
    
        public class ThesisRepository : Repository<Thesis>, IThesisRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _ThesisDbContext;
            public ThesisRepository(ThesisDbContext ThesisDbContext) : base(ThesisDbContext)
            {
            _ThesisDbContext = ThesisDbContext;
            }

            public List<Thesis> AdvancedSearch(string authorName, string supervisorName, string thesisTitle, string typeName, string universityName)
            {
                // Gelişmiş arama kriterlerini kullanarak veritabanından filtreleme yap
                var query = _ThesisDbContext.Thesisses.Include(t => t.Author.Person)
						  .Include(t => t.Supervisor.Person)
						  .Include(t => t.ThesisType)
						  .Include(t => t.University)
						  .Include(t => t.Language)
						  .AsQueryable();

				if (!string.IsNullOrEmpty(authorName))
				{
					query = query.Where(t => t.Author.Person.Name.Contains(authorName));
				}

				if (!string.IsNullOrEmpty(supervisorName))
				{
					query = query.Where(t => t.Supervisor.Person.Name.Contains(supervisorName));
				}

				if (!string.IsNullOrEmpty(thesisTitle))
				{
					query = query.Where(t => t.ThesisTitle.Contains(thesisTitle));
				}
				if (!string.IsNullOrEmpty(typeName))
				{
					query = query.Where(t => t.ThesisType.TypeName.Contains(typeName));
				}
				if (!string.IsNullOrEmpty(universityName))
				{
					query = query.Where(t => t.University.UniversityName.Contains(universityName));
				}




				var searchResults = query.ToList();

				return searchResults;

				// Diğer arama kriterleri için benzer koşulları ekleyin

				
            }

            public void Guncelle(Thesis thesis)
            {
				_ThesisDbContext.Update(thesis);
            }

            public void Kaydet()
            {
				_ThesisDbContext.SaveChanges();
            }
        }
    }

}

