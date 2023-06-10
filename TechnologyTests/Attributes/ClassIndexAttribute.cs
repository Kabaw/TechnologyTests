namespace TechnologyTests.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ClassIndexAttribute : Attribute
{
    public int Index;
}