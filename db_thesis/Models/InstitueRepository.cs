namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;

namespace db_thesis.Models
    { 
    
        public class InstitueRepository : Repository<Institue>, IInstitueRepository
		//implement etti
		//sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
		{
            private ThesisDbContext _thesisDbContext;
            public InstitueRepository(ThesisDbContext thesisDbContext) : base(thesisDbContext)
            {
            _thesisDbContext = thesisDbContext;
            }

            public void Guncelle(Institue institue)
            {
            _thesisDbContext.Update(institue);
            }

            public void Kaydet()
            {
            _thesisDbContext.SaveChanges();
            }
        }
    }

}

