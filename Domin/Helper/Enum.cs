using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Domain.Helper;

public enum RoleEnum
{
    [Display(Name = "Admin")]
    Admin = 1,
    [Display(Name = "Locker Admin")]
    LockerAdmin = 2,
    [Display(Name = "Activity Admin")]
    ActivityAdmin =3,
    [Display(Name = "Event Admin")]
    EventAdmin =4,
    [Display(Name = "Trip Admin")]
    TripAdmin =5,
    [Display(Name = "Area Admin")]
    AreaAdmin =6,
    [Display(Name = "Membership Admin")]
    MembershipAdmin = 7,
    [Display(Name = "Resort Admin")]
    ResortAdmin = 8,
    [Display(Name = "Locker Employee")]
    LockerEmployee = 9,
    [Display(Name = "Activity Employee")]
    ActivityEmployee = 10,
    [Display(Name = "Event Employee")]
    EventEmployee = 11,
    [Display(Name = "Trip Employee")]
    TripEmployee = 12,
    [Display(Name = "Area Employee")]
    AreaEmployee = 13,
    [Display(Name = "Membership Employee")]
    MembershipEmployee = 14,
    [Display(Name = "Resort Employee")]
    ResortEmployee = 15,
    [Display(Name = "Payment")]
    Payment = 16
}