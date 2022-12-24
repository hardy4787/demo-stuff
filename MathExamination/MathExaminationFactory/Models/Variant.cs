using MathExamination.Domain;
using System.Text;

namespace MathExaminationFactory.Models;

public class Variant
{
    public List<MathTask> AlgebraTasks { get; set; } = new();
    public List<MathTask> TrigonometryTasks { get; set; } = new();
    public List<MathTask> StereometryTasks { get; set; } = new();

    public override string ToString()
    {
        StringBuilder str = new();
        str.Append("Algebra: \n");
        str.Append(string.Join("\n", AlgebraTasks.Select((x, i) => $"{i + 1}. {x.Description}")));
        str.Append("\n\nTrygonometry: \n");
        str.Append(string.Join("\n", TrigonometryTasks.Select((x, i) => $"{i + 1}. {x.Description}")));
        str.Append("\n\nStereometry: \n");
        str.Append(string.Join("\n", StereometryTasks.Select((x, i) => $"{i + 1}. {x.Description}")));
        return str.ToString();
    }
}