namespace IWantApp.Domain;

public abstract class Entity
{
    public Entity()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EditeddBy { get; set; }
    public DateTime EditeddOn { get; set; }
}
