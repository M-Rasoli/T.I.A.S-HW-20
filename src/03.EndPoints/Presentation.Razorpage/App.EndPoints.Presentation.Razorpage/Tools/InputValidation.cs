using App.Domain.Core._Common.Entities;

namespace App.EndPoints.Presentation.Razorpage.Tools
{
    public static class InputValidation
    {
        public static Result<bool> IsValidMobileNumber(string mobileNumber)
        {
            if (mobileNumber.Length != 11 || !mobileNumber.StartsWith("09"))
            {
                return Result<bool>.Failure(message: "فرمت شماره موبایل وارد شده اشتباه است.");
            }
            var checkAllDigit = mobileNumber.All(char.IsDigit);
            if (!checkAllDigit)
            {
                return Result<bool>.Failure(message:"شماره موبایل فقط باید شامل اعداد باشد.");
            }
            return Result<bool>.Success(message:"");

        }

        public static Result<bool> IsValidNationalCode(string nationalCode)
        {
            if (nationalCode.Length != 10)
            {
                return Result<bool>.Failure(message: "فرمت شماره موبایل وارد شده اشتباه است.");
            }
            var checkAllDigit = nationalCode.All(char.IsDigit);
            if (!checkAllDigit)
            {
                return Result<bool>.Failure(message: "کد ملی فقط باید شامل اعداد باشد.");
            }
            return Result<bool>.Success(message: "");
        }
    }
}
