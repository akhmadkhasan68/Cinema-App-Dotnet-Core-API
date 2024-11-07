using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Utils.Helpers
{
    public static class AppSettingHelper
    {
        private static IConfiguration _configuration = null!;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static T GetValue<T>(string key)
        {
            return _configuration.GetValue<T>(key)!;
        }

        public static T GetSection<T>(string key)
        {
            return _configuration.GetSection(key).Get<T>()!;
        }


    }
}
