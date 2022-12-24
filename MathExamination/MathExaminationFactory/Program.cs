using MathExaminationFactory;

IVariantCreator variantCreator = new OlympiadVariantCreator();
var variant = variantCreator.Create();
Console.WriteLine(variant);