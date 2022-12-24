using MathExamination.Domain;
using System.Text;

namespace MathExaminationBuilder.Models;

public class Variant
{
    public List<MathTask> MathTasks { get; set; } = new();

    public override string ToString()
    {
        StringBuilder str = new();
        str.Append(string.Join("\n", MathTasks.Select((x, i) => $"{i + 1}. {x.Description}")));
        return str.ToString();
    }
}
