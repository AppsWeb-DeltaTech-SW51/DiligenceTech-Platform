namespace DeltaTech.DiligenceTech.API.Communication.Domain.Model.Entities;

public partial class Notification
{
    public int Id { get; }
    public string Type { get; private set; }
    public string Content { get; private set; }
    
    public Notification(string type, string content)
    {
        Type = type;
        Content = content;
    }
}