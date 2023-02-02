using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class ErpCodes : ValueObject
{
    private ErpCodes() // Empty constructor for EF
    { }

    public ErpCodes(string seniorId, string vplId)
    {
        SeniorId = seniorId;
        VplId = vplId;

        AddNotifications(new Contract<ErpCodes>()
            .Requires()
            .IsNotNullOrEmpty(SeniorId, "ErpCodes.SeniorId", "O código proveniente do Senior não pode ser vazio.")
            .IsNotNullOrWhiteSpace(SeniorId, "ErpCodes.SeniorId", "O código proveniente do Senior não pode ser vazio.")
            .IsNotNullOrEmpty(VplId, "ErpCodes.VplId", "O código proveniente do VPL não pode ser vazio.")
            .IsNotNullOrWhiteSpace(VplId, "ErpCodes.VplId", "O código proveniente do VPL não pode ser vazio.")
            );
    }

    public string SeniorId { get; private set; } = string.Empty;
    public string VplId { get; private set; } = string.Empty;
}