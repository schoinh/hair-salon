using System;

namespace HairSalon.Models
{
    public class Appointment
    {
        public int ApptId { get; set; }
        public int StylistId { get; set; }
        public int ClientId { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
        public virtual Client Client { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}