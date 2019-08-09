using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int StylistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public virtual Stylist Stylist { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Client()
        {
            this.Appointments = new HashSet<Appointment>();
        }
    }
}