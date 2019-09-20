using Microsoft.AspNetCore.Html;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq; 

namespace GHMS.Core
{


    public enum Roles
    {
        [Description("Super Admin")]
        SuperAdmin,
        [Description("Hospital Admin")]
        HospitalAdmin,
        [Description("Doctor")]
        Doctor,
        [Description("Junior Doctor")]
        JuniorDoctor,
        [Description("Nurse")]
        Nurse
    }
    public enum ResponseCodes
    {
        [Description("Error")]
        Error = 0,
        [Description("Success")]
        Success = 200,
        [Description("Duplicate")]
        Duplicate = 300,
        [Description("Invalid Model")]
        InvalidModel = 303,
        [Description("Invalid User")]
        Unauthorized = 401,
        [Description("Not Found")]
        NotFound = 404

    }
     
    
    public static class HtmlExtensions
    {
        public static HtmlString EnumDisplayNameFor(this Enum item)
        {
            var type = item.GetType();
            var member = type.GetMember(item.ToString());
            DisplayAttribute displayName = (DisplayAttribute)member[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

            if (displayName != null)
            {
                return new HtmlString(displayName.Name);
            }

            return new HtmlString(item.ToString());
        }

        public static String EnumDescriptionFor(this Enum item)
        {
            var type = item.GetType();
            var member = type.GetMember(item.ToString());
            DescriptionAttribute displayName = (DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (displayName != null)
            {
                return new String(displayName.Description);
            }

            return new String(item.ToString());
        }
    }


}
