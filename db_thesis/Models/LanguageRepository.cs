namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;

namespace db_thesis.Models
    { 
    
        public class LanguageRepository : Repository<Language>, ILanguageRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _thesisDbContext;
            public LanguageRepository(ThesisDbContext thesisDbContext) : base(thesisDbContext)
            {
            _thesisDbContext = thesisDbContext;
            }

            public void Guncelle(Language language)
            {
            _thesisDbContext.Update(language);
            }

            public void Kaydet()
            {
            _thesisDbContext.SaveChanges();
            }
        }
    }

}

