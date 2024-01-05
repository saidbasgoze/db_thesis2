namespace db_thesis.Models
{
	public interface ISupervisorRepository : IRepository<Supervisor>
		// : hem inheritance hem interface için kullanılır bu bir inheritance
		//IRepository içindeki tüm metodlar burda varmış gibi yani hepsi otomatik geliyor.
		//extra ne varsa onları yazıcaksın inheritance amacı o.
	{
		void Guncelle(Supervisor supervisor);
		void Kaydet();

	}
}
