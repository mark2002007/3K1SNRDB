using System.Configuration;

namespace _3K1SNRDB
{
    public class Helper
    {
        public static string dbName() => ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
    }
}