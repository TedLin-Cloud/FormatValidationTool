using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FormatValidationTool.FormatValidations
{
    public static class FormatValidation
    {
        /// <summary>
        /// 新式身分證檢核
        /// </summary>
        /// <param name="firstCode"></param>
        /// <param name="leftCode"></param>
        /// <returns></returns>
        public static bool ChkID(this string value)
        {
            if (value == null)
                return false;

            var id = value.ToString();

            //分組及檢核
            Regex regex = new Regex(@"^([A-Z])(A|B|C|D|1|2|8|9)(\d{8})$");
            Match match = regex.Match(id);

            if (!match.Success)
            {
                return false;
            }

            var reg = new Regex(@"^[A-Z]");

            var firstCode = match.Groups[1].Value;
            var leftCode = match.Groups[2].Value + match.Groups[3].Value;

            if (reg.IsMatch(leftCode.Substring(0, 1)))
            {
                return false;
            }

            string alphabet = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
            string transferIdNo = $"{(alphabet.IndexOf(firstCode) + 10)}" +
                                  $"{leftCode}";
            int[] idNoArray = transferIdNo.ToCharArray()
                                          .Select(c => Convert.ToInt32(c.ToString()))
                                          .ToArray();

            int sum = idNoArray[0];
            int[] weight = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };
            for (int i = 0; i < weight.Length; i++)
            {
                sum += (weight[i] * idNoArray[i + 1]) % 10;
            }
            return (sum % 10 == 0);
        }

        /// <summary>
        /// 舊式居留證檢核
        /// </summary>
        /// <param name="firstCode"></param>
        /// <param name="secondCode"></param>
        /// <param name="leftCode"></param>
        /// <returns></returns>
        public static bool ChkResident(this string value)
        {
            if (value == null)
                return false;

            var id = value.ToString();

            //分組及檢核
            Regex regex = new Regex(@"^([A-Z])(A|B|C|D|1|2|8|9)(\d{8})$");
            Match match = regex.Match(id);

            if (!match.Success)
            {
                return false;
            }

            var reg = new Regex(@"^[A-Z]");

            var firstCode = match.Groups[1].Value;
            var secondCode = match.Groups[2].Value;
            var leftCode = match.Groups[3].Value;

            string alphabet = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
            string transferIdNo =
                $"{alphabet.IndexOf(firstCode) + 10}" +
                $"{(alphabet.IndexOf(secondCode) + 10) % 10}" +
                $"{leftCode}";
            int[] idNoArray = transferIdNo.ToCharArray()
                                          .Select(c => Convert.ToInt32(c.ToString()))
                                          .ToArray();

            int sum = idNoArray[0];
            int[] weight = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };
            for (int i = 0; i < weight.Length; i++)
            {
                sum += weight[i] * idNoArray[i + 1];
            }
            return (sum % 10 == 0);
        }

        /// <summary>
        /// 新式身分證檢核及舊式居留證檢核
        /// </summary>
        /// <param name="firstCode"></param>
        /// <param name="leftCode"></param>
        /// <returns></returns>
        public static bool ChkIDAndResident(this string value)
        {
            if (ChkID(value) || ChkResident(value))
                return true;
            else
                return false;
        }
    }
}
