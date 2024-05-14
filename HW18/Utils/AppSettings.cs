using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Utils
{
    public class AppSettings
    {
        public string? BrowserType { get; set; }
        public double TimeOut { get; set; }
        public string SauceDemoUrl { get; set; }
        public string UserNameSauceDemo { get; set; }
        public string PasswordSauceDemo { get; set; }
        public string HerokuappUrl { get;  set; }
        public string TestRailUrl { get; set;}
        public string UsernameTestRail { get; set; }
        public string PasswordTestRail { get; set; }
    }
}
