using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyTests.Reflection;

public static class ClassCreator
{
    public static object NewInstance(string className)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        Type[] types = executingAssembly
            .GetTypes()
            .Where(t => t.Name == className || t.FullName == className)
            .ToArray();

        if (types.Length == 0)
            throw new NullReferenceException("The informed class type dosen't exist!");

        if (types.Length > 1)
            throw new ApplicationException("The informed class name is ambiguos, please specify the namespace!");

        var type = types[0];

        var instance = Activator.CreateInstance(type);

        if (instance is null)
            throw new NullReferenceException("The system failed in creating a instance of the informed type!");

        return instance;
    }
}