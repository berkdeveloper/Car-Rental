using Core.Domain.Core;
using Dawn;

namespace Domain.Entities;

public class Brand : AggregateRoot<Guid>
{
    public string Name { get; private set; }

    public Brand() : base(Guid.NewGuid()) { }

    public Brand(string name) => Name = name;

    public void SetName(string name)
    {
        Guard.Argument(name, nameof(name)).NotNull().NotEmpty().NotWhiteSpace();

        Name = name;
    }
}
