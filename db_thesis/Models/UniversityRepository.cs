namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;

namespace db_thesis.Models
    { 
    
        public class UniversityRepository : Repository<University>, IUniversityRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _thesisDbContext;
            public UniversityRepository(ThesisDbContext thesisDbContext) : base(thesisDbContext)
            {
            _thesisDbContext = thesisDbContext;
            }

            public void Guncelle(University university)
            {
            _thesisDbContext.Update(university);
            }

            public void Kaydet()
            {
            _thesisDbContext.SaveChanges();
            }
        }
    }

}

