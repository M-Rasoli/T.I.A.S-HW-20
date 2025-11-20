using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarAgg.Enums
{
    public enum CarCompanyEnum
    {
        [Display(Name = "ایران خودرو")]
        IranKhodro = 1 ,
        [Display(Name = "سایپا")]
        Saipa = 2
    }
}
