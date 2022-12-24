using MathExaminationBuilder;

var variantBuilder = new VariantBuilder();
var variantDirector = new VariantDirector(variantBuilder);
variantDirector.BuildOlympiadVariant();
Console.WriteLine(variantBuilder.GetVariant());