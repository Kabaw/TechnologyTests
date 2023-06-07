using Microsoft.Extensions.Configuration;

namespace TechnologyTests;

public class GlobalAccess
{
    private static GlobalAccess? _instance;

    public static GlobalAccess instance { get => _instance!; private set => _instance = value; }
    public IConfiguration configuration { get; private set; }

    private GlobalAccess(IConfiguration configuration)
    {
        if (instance is not null)
            throw new ApplicationException("A instance of GlobalAccess already exists!");

        this.configuration = configuration;
        instance = this;
    }

    public static void Init(IConfiguration configuration)
    {
        new GlobalAccess(configuration);
    }
}