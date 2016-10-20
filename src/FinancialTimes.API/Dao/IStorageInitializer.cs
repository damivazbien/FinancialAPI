namespace FinancialTimes.API.DAO
{
    public interface IStorageInitializer
	{
		void Initialize();
		void Drop();
	}    
}
