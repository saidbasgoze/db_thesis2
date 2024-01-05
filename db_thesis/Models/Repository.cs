using db_thesis.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace db_thesis.Models

{ 
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly ThesisDbContext _thesisDbContext;
            internal DbSet<T> dbSet; 
        public Repository(ThesisDbContext ThesisDbContext) 

        {
            _thesisDbContext = ThesisDbContext;
            this.dbSet = ThesisDbContext.Set<T>();
            _thesisDbContext.Authors.Include(k => k.Person);
			_thesisDbContext.Supervisors.Include(k => k.Person);
			_thesisDbContext.Thesisses.Include(k => k.Language);

			_thesisDbContext.Thesisses.Include(k => k.ThesisType);
			_thesisDbContext.Institues.Include(k => k.University);


			var authors=_thesisDbContext.Thesisses.Include(k => k.Author).ThenInclude(k=>k.Person);
			var supervisors=_thesisDbContext.Thesisses.Include(k => k.Supervisor).ThenInclude(k => k.Person);






			//foreign keyi çekiyoruz burda.
		}
            public void Ekle(T entity)
            {

                dbSet.Add(entity);
            }
		




		public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
            {
                IQueryable<T> sorgu = dbSet;
			sorgu = sorgu.Where(filtre); //birden fazla kayıt getirebilir.tek bir nesne getirmeli


			if (!string.IsNullOrEmpty(includeProps))
                {
                    foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        sorgu = sorgu.Include(includeProp);
                    }
                }
            return sorgu.FirstOrDefault();
        }

            public IEnumerable<T> GetAll(string? includeProps = null)
            {
                IQueryable<T> sorgu = dbSet;

                if (!string.IsNullOrEmpty(includeProps))
                {
                    foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        sorgu = sorgu.Include(includeProp);
					    

				}
                }

            return sorgu.ToList();
			//tüm listeyi getirir bu.
		}

            public void Sil(T entity)
            {
                dbSet.Remove(entity);
            }

            public void SilAralik(IEnumerable<T> entities)
            {
                dbSet.RemoveRange(entities);
            }
        }
    }


