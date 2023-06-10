using Microsoft.Extensions.Configuration;
using TechnologyTests;
using TechnologyTests.Reflection;

var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<MySettings>()
               .AddEnvironmentVariables();

IConfigurationRoot configuration = builder.Build();
var mySettings = new MySettings();
configuration.GetSection("MySettings").Bind(mySettings);

GlobalAccess.Init(configuration, mySettings);
ClassCreator.NewInstance(GlobalAccess.instance.settings.ClassIndex);