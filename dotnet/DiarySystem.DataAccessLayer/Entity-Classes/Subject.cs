namespace DataAccessLayer.Entity_Classes;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Teacher { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        var other = (Subject)obj;
        return Id == other.Id;
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

