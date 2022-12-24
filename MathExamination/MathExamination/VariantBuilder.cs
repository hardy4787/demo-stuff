using MathExamination.Domain;
using MathExamination.Store;
using MathExaminationBuilder.Models;

namespace MathExaminationBuilder;
public class VariantBuilder: IVariantBuilder
{
    private Variant _variant = new();
    private readonly Random _random = new();

    public VariantBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._variant = new Variant();
    }

    public Variant GetVariant()
    {
        Variant result = this._variant;

        this.Reset();

        return result;
    }

    private void AddRandomTasks(List<MathTask> tasks, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(tasks.Count);

            MathTask randomTask = tasks[index];

            _variant.MathTasks.Add(randomTask);

            tasks.Remove(randomTask);
        }
    }

    public void AddTrygonometryTasks(int count)
    {
        AddRandomTasks(TasksStore.MathTasks.Where(t => t.Subject == Subject.Trygonometry).ToList(), count);
    }

    public void AddAlgebraTasks(int count)
    {
        AddRandomTasks(TasksStore.MathTasks.Where(t => t.Subject == Subject.Algebra).ToList(), count);
    }

    public void AddStereometryTasks(int count)
    {
        AddRandomTasks(TasksStore.MathTasks.Where(t => t.Subject == Subject.Stereometry).ToList(), count);
    }
}
