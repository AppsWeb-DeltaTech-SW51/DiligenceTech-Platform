using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Commands;

namespace DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;

public partial class QA
{
    public int Id { get; }
    public string Content { get; private set; }
    public QA Question { get; set; }
    public int? QuestionId { get; private set; }
    public ICollection<QA> Answers { get; }
    
    public QA(string content)
    {
        Content = content;
    }
    
    public void AssignQuestion(QA question)
    {
        Question = question;
        QuestionId = question?.Id;
    }

    public QA(CreateQACommand command)
    {
        Content = command.content;
    }
}