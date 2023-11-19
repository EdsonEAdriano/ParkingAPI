using System.Text.RegularExpressions;

namespace ParkingAPI.Helpers
{
    public static class CNPJ
    {
        public static bool validateCNPJ(string cnpj)
        {
            if (cnpj.Length != 18)
                return false;

            if (cnpj[2] == '.' && cnpj[6] == '.' && cnpj[10] == '/' && cnpj[15] == '-')
                return true;

            return false;
        }

        public static long parseCNPJ(string cnpj)
        {
            return long.Parse(cnpj.Replace(".", "").Replace("-", "").Replace("/", ""));
        }
    }
}
