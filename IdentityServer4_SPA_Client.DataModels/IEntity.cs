namespace IdentityServer4.DataModels
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
