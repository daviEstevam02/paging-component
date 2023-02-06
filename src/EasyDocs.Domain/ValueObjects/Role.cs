using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Br;
using Flunt.Validations;
using Microsoft.Extensions.Options;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Role : ValueObject
{
    private Role()
    { }

    public Role(
        bool canRead,
        bool canWrite,
        bool canUpdate,
        bool canDelete
        )
    {
        CanRead = canRead;
        CanWrite = canWrite;
        CanUpdate = canUpdate;
        CanDelete = canDelete;

        AddNotifications(new Contract<Role>()
            .Requires()
            .IsTrue(Validate(), "Roles", "Pelo menos uma permissão deve ser verdadeira.")
            );
    }

    public bool CanRead { get; private set; }
    public bool CanWrite { get; private set; }
    public bool CanUpdate { get; private set; }
    public bool CanDelete { get; private set; }

    private bool Validate()
        => CanRead is true
        || CanWrite is true
        || CanUpdate is true
        || CanDelete is true;

}