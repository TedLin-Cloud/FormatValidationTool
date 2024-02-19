using FormatValidationTool.FormatValidations;
using System.ComponentModel.DataAnnotations;

namespace FormatValidationTool
{
    /// <summary>
    /// 新式身分證ID驗證
    /// [CustID(ErrorMessage = "身分證格式錯誤")]
    /// </summary>
    public class CustIDAttribute : ValidationAttribute
    {
        public override bool IsValid(object value = null)
        {
            if (value == null)
                return false;

            return value.ToString().ChkID();
        }
    }

    /// <summary>
    /// 舊式居留證ID驗證
    /// [Resident(ErrorMessage = "身分證格式錯誤")]
    /// </summary>
    public class ResidentAttribute : ValidationAttribute
    {
        public override bool IsValid(object value = null)
        {
            if (value == null)
                return false;

            return value.ToString().ChkResident();
        }
    }

    /// <summary>
    /// 新式身分證及舊式居留證 ID驗證
    /// [CustID(ErrorMessage = "身分證格式錯誤")]
    /// </summary>
    public class CustIDAndResidentAttribute : ValidationAttribute
    {
        public override bool IsValid(object value = null)
        {
            if (value == null)
                return false;

            return value.ToString().ChkIDAndResident();
        }
    }
}