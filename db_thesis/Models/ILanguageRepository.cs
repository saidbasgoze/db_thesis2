namespace db_thesis.Models
{
	public interface ILanguageRepository : IRepository<Language>
		// : hem inheritance hem interface için kullanılır bu bir inheritance
		//IRepository içindeki tüm metodlar burda varmış gibi yani hepsi otomatik geliyor.
		//extra ne varsa onları yazıcaksın inheritance amacı o.
	{
		void Guncelle(Language language);
		void Kaydet();

	}
}
