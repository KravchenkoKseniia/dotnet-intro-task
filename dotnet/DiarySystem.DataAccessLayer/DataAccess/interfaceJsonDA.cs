namespace dotnet.DataAccess;

public interface interfaceJsonDA<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    List<T> GetAll();
}