namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;

namespace db_thesis.Models
    { 
    
        public class AuthorRepository : Repository<Author>, IAuthorRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _thesisDbContext;
            public AuthorRepository(ThesisDbContext thesisDbContext) : base(thesisDbContext)
            {
            _thesisDbContext = thesisDbContext;
            }

            public void Guncelle(Author author)
            {
            _thesisDbContext.Update(author);
            }

            public void Kaydet()
            {
            _thesisDbContext.SaveChanges();
            }
        }
    }

}

