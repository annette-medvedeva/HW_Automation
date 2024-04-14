using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Utils
{

    public class Configurator
    {
        public static AppSettings ReadConfiguration()
        {
            var appSettingPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "appsettings.json");
            var appSettingsText = File.ReadAllText(appSettingPath);
            return JsonConvert.DeserializeObject<AppSettings>(appSettingsText) ?? throw new FileNotFoundException();
        }
    }

}
