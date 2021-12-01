using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Models
{
    public class MeetingModel
    {
        public MeetingModel()
        {
            Participants = new List<Participant>();
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<Participant> Participants{ get; set; }
    }
}