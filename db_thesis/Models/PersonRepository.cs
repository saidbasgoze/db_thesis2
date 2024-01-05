namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;

namespace db_thesis.Models
    { 
    
        public class PersonRepository : Repository<Person>, IPersonRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _ThesisDbContext;
            public PersonRepository(ThesisDbContext ThesisDbContext) : base(ThesisDbContext)
            {
            _ThesisDbContext = ThesisDbContext;
            }

            public void Guncelle(Person person)
            {
				_ThesisDbContext.Update(person);
            }

            public void Kaydet()
            {
				_ThesisDbContext.SaveChanges();
            }
        }
    }

}

