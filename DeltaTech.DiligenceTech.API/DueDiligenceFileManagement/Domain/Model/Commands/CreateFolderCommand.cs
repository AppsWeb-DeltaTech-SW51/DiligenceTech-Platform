using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;

public record CreateFolderCommand(string Name, EFolderStatus BuyStatus, EFolderStatus SellStatus, bool Obligatory, EFolderPriority Priority);