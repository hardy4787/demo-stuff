namespace MathExamination.Domain;

public class MathTask
{
    public Subject Subject { get; set; }
    public Complexity Complexity { get; set; }
    public string Description { get; set; } = null!;
    public string Prompt { get; set; } = null!;
    public string Solution { get; set; } = null!;
}
