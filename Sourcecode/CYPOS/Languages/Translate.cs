using System.Configuration;
using System.Reflection;
using System.Resources;

namespace cypos.Language
{
    public class Translate
    {
        public static ResourceManager rm;

        public string getText(string text)
        {
            string language = ConfigurationManager.AppSettings["language"];

            string _languaje = "es_Local";
            if (language == "Spanish")
            {
                _languaje = "es_Local";
            }
            else if (language == "English")
            { 
                _languaje = "en_Local";
            }
            rm = new ResourceManager("cypos.Languages." + _languaje, Assembly.GetExecutingAssembly());
            return rm.GetString(text);
        }

        public string getLang()
        {
            return ConfigurationManager.AppSettings["language"];
        }


    }
}
