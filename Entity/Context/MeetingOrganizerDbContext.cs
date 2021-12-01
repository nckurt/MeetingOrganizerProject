using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Entity
{
    public class MeetingOrganizerDbContext: DbContext
    {
        public MeetingOrganizerDbContext():base("MeetingOrganizerDbContext")
        {

        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
       
    }
}