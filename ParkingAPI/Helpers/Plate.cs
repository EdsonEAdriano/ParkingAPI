using System.Text.RegularExpressions;

namespace ParkingAPI.Helpers
{
    public static class Plate
    {
        public static bool validatePlate(string placa)
        {
            string pattern = @"^[A-Za-z]{3}-\d{4}$|^[A-Za-z]{3}\d[A-Za-z]\d{2}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(placa);
        }
    }
}
