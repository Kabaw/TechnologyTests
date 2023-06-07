using Microsoft.Extensions.Configuration;
using TechnologyTests;
using TechnologyTests.Linq;

var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<MySettingsConfig>()
               .AddEnvironmentVariables();

IConfigurationRoot configuration = builder.Build();
var mySettingsConfig = new MySettingsConfig();
configuration.GetSection("MySettings").Bind(mySettingsConfig);

Console.WriteLine("Setting from appsettings.json: " + mySettingsConfig.AccountName);
Console.WriteLine("Setting from secrets.json: " + mySettingsConfig.ApiSecret);
Console.WriteLine("Connection string: " + configuration.GetConnectionString("DefaultConnection"));

GlobalAccess.Init(configuration);

new LinqStudy();