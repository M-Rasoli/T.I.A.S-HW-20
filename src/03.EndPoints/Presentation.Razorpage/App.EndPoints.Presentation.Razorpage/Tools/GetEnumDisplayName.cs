using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace App.EndPoints.Presentation.Razorpage.Tools
{
    public static class GetEnumDisplayName
    {
        public static string GetEnumName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }
    }
}
