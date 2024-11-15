using System.ComponentModel;

namespace DAL.Enums
{
    public enum AppointmentStatusType
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Arrived")]
        Arrived = 1,
        [Description("Entered Premesis")]
        EnteredPremesis = 2,
        [Description("In Progress")]
        InProgress = 3,
        [Description("Done")]
        Done = 4
    }
}
