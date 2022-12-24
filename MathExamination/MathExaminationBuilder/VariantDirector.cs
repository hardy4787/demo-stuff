namespace MathExaminationBuilder;
public class VariantDirector
{
    private readonly IVariantBuilder _builder;
    public VariantDirector(IVariantBuilder builder)
    {
        _builder = builder;
    }
    public void BuildOlympiadVariant()
    {
        _builder.AddTrygonometryTasks(1);
        _builder.AddStereometryTasks(1);
        _builder.AddAlgebraTasks(2);
    }
}
