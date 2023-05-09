using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; } = true;

    public Category (String name)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name");
        AddNotifications(contract);

        this.Name = name;
        this.Active = true;

    }
}
