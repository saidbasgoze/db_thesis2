namespace db_thesis.Models
{
	public interface IAuthorRepository : IRepository<Author>
		// : hem inheritance hem interface için kullanılır bu bir inheritance
		//IRepository içindeki tüm metodlar burda varmış gibi yani hepsi otomatik geliyor.
		//extra ne varsa onları yazıcaksın inheritance amacı o.
	{
		void Guncelle(Author author);
		void Kaydet();

	}
}
