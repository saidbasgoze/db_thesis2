namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;

namespace db_thesis.Models
    { 
    
        public class SupervisorRepository : Repository<Supervisor>, ISupervisorRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _thesisDbContext;
            public SupervisorRepository(ThesisDbContext thesisDbContext) : base(thesisDbContext)
            {
            _thesisDbContext = thesisDbContext;
            }

            public void Guncelle(Supervisor supervisor)
            {
            _thesisDbContext.Update(supervisor);
            }

            public void Kaydet()
            {
            _thesisDbContext.SaveChanges();
            }
        }
    }

}

