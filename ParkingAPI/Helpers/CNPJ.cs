using System.Text.RegularExpressions;

namespace ParkingAPI.Helpers
{
    public static class CNPJ
    {
        public static bool validateCNPJ(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, "[^0-9]", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma1 = 0;
            int soma2 = 0;

            for (int i = 0; i < 12; i++)
            {
                soma1 += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];
                soma2 += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];
            }

            int digito1 = (soma1 % 11 < 2) ? 0 : (11 - (soma1 % 11));
            int digito2 = (soma2 % 11 < 2) ? 0 : (11 - (soma2 % 11));

            return (digito1 == int.Parse(cnpj[12].ToString()) && digito2 == int.Parse(cnpj[13].ToString()));
        }

        public static long parseCNPJ(string cnpj)
        {
            return long.Parse(cnpj.Replace(".", "").Replace("-", "").Replace("/", ""));
        }
    }
}
