using Microsoft.Extensions.Configuration;

namespace TechnologyTests;

public class GlobalAccess
{
    private static GlobalAccess? _instance;
    public static GlobalAccess instance { get => _instance!; private set => _instance = value; }

    public IConfiguration configuration { get; private set; }
    public MySettings settings { get; private set; }

    private GlobalAccess(IConfiguration configuration, MySettings mySettings)
    {
        if (_instance is not null)
            throw new ApplicationException("An instance of GlobalAccess already exists!");        

        this.configuration = configuration;
        settings = mySettings;
        _instance = this;
    }

    public static void Init(IConfiguration configuration, MySettings mySettings)
    {
        new GlobalAccess(configuration, mySettings);
    }
}