using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;

public record CreateFolderResource(string Name, EFolderStatus BuyStatus, EFolderStatus SellStatus, bool Obligatory,
    EFolderPriority Priority);