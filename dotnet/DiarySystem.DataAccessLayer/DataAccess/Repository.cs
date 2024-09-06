using System.Text.Json;

namespace DiarySystem.DataAccess;

public class Repository<T> : IInterfaceJsonDa<T>
{
    private readonly string _path;
    private List<T> _entities;

    private void LoadData()
    {
        if (File.Exists(_path))
        {
            using var r = new StreamReader(_path);
            var json = r.ReadToEnd();
            _entities = JsonSerializer.Deserialize<List<T>>(json) 
                        ?? throw new InvalidOperationException("Failed to deserialize data");
        }
        else
        {
            _entities = [];
        }
    }
    private void SaveData()
    {
        var jsonString = JsonSerializer.Serialize(_entities);
        using var writer = new StreamWriter(_path);
        writer.WriteLine(jsonString);
    }
    
    public void Add(T entity)
    {
        LoadData();
        _entities.Add(entity);
        SaveData();
    }

    public void Update(T entity)
    {
        LoadData();
        
        var index = _entities.FindIndex(e => e != null && e.Equals(entity));
        
        if (index < 0)
        {
            throw new InvalidOperationException("Entity not found");
        }
        else
        {
            _entities[index] = entity;
            SaveData();
        }
        
    }
    
    public void Delete(int id)
    {
        LoadData();
        
        var entity = _entities.FirstOrDefault(e => e != null && e.GetHashCode() == id);
        
        if (entity == null)
        {
            throw new InvalidOperationException("Entity not found");
        }
        else
        {
            _entities.Remove(entity);
            SaveData();
        }
        
        _entities.RemoveAt(id);
        SaveData();
    }
    
    
    public Repository(string path)
    {
        _path = path;
        _entities = [];
    }
}