using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : Entity<Guid>
{
    public string Name { get; set; }

    public Brand() : base(Guid.NewGuid()) { }

    public Brand(string name) => Name = name;
}
