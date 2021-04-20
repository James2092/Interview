namespace Interview.Repository.DapperRepository
{
    public interface IRepository
    {
        void ExecuteStoredProcedure(string name, object parameters);
    }
}
