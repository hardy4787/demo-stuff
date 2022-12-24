using MathExamination.Domain;
using MathExamination.Store;
using MathExaminationFactory.Models;

namespace MathExaminationFactory;
public class OlympiadVariantCreator: IVariantCreator
{
    private const int ALGEBRA_TASKS_COUNT = 2;
    private const int STEREOMTRY_TASKS_COUNT = 1;
    private const int TRYGONOMETRY_TASKS_COUNT = 1;

    public Variant Create()
    {
        return new Variant
        {
            AlgebraTasks = TasksStore.MathTasks.Where(t => t.Subject == Subject.Algebra).Take(ALGEBRA_TASKS_COUNT).ToList(),
            StereometryTasks = TasksStore.MathTasks.Where(t => t.Subject == Subject.Stereometry).Take(STEREOMTRY_TASKS_COUNT).ToList(),
            TrigonometryTasks = TasksStore.MathTasks.Where(t => t.Subject == Subject.Trygonometry).Take(TRYGONOMETRY_TASKS_COUNT).ToList(),
        };
    }
}
