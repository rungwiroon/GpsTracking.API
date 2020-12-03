namespace Core.Domain.SeedWork
{
    public interface IViewRepository<T>
        where T : IViewModel
    {
        T GetByQuery(IQuery<T> query);

        void Create(T vehicleGroup);
        void Update(T vehicleGroup);
        void Delete(T vehicleGroupId);
    }
}
