namespace db_thesis.Models
{
	public interface IThesisRepository : IRepository<Thesis>
		// : hem inheritance hem interface için kullanılır bu bir inheritance
		//IRepository içindeki tüm metodlar burda varmış gibi yani hepsi otomatik geliyor.
		//extra ne varsa onları yazıcaksın inheritance amacı o.
	{

        List<Thesis> AdvancedSearch(string authorName, string supervisorName, string thesisTitle, string typeName, string universityName);
        void Guncelle(Thesis Thesis);
		void Kaydet();

	}
}
