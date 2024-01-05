namespace db_thesis.Models
{
 
        
    using global::db_thesis.Utility;
	using Microsoft.EntityFrameworkCore;

namespace db_thesis.Models
    { 
    
        public class ThesisTypeRepository : Repository<ThesisType>, IThesisTypeRepository
        //implement etti
        //sadece 2 tane gelecek çünkü diğerleri zaten Reposityorde var.diğerleri ordan kullanılır.
        {
            private ThesisDbContext _thesisDbContext;
            public ThesisTypeRepository(ThesisDbContext thesisDbContext) : base(thesisDbContext)
            {
            _thesisDbContext = thesisDbContext;
            }

            public void Guncelle(ThesisType thesisType)
            {
				
				_thesisDbContext.Update(thesisType);
            }

            public void Kaydet()
            {
            _thesisDbContext.SaveChanges();
            }
        }
    }

}

