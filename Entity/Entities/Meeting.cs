using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.Entity
{
    public class Meeting
    {
        public Meeting()
        {
            Participants = new List<Participant>();
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Date{ get; set; }
        public DateTime StartTime{ get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }

        public List<Participant> Participants { get; set; }


    }
}
