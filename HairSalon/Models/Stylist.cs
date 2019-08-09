using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int StylistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Specialties { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Stylist()
        {
            this.Clients = new HashSet<Client>();
            this.Appointments = new HashSet<Appointment>();
        }
    }
}