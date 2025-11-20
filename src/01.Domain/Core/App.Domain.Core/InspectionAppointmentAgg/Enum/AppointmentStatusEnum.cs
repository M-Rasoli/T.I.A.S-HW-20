using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.InspectionAppointmentAgg.Enum
{
    public enum AppointmentStatusEnum
    {
        [Display(Name = "تایید شده")]
        Confirmed = 1 ,
        [Display(Name = "در انتظار")]
        Pending = 2,
        [Display(Name = "کنسل شده")]
        Canceled = 3,
        [Display(Name = "رد شده")]
        Denied = 4,
    }
}
