namespace DiarySystem.DataAccess;

public interface IInterfaceJsonDa<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);

}