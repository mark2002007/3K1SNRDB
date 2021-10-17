using System.Configuration;

namespace _3K1SNRDB;

public class Helper
{
    public static string CnnVal() => ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
}