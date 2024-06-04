namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;

public record FileInfo(string FileName, string FileUrl)
{
    public FileInfo() : this(string.Empty, string.Empty)
    {
    }
}