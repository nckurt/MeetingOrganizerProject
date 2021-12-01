using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{    
    public class MeetingService
    {
        MeetingOrganizerDbContext dbContext = new MeetingOrganizerDbContext();
        public MeetingService()
        {
            
        }

        public List<Meeting> GetAllMeetings()
        {
            List<Meeting> data=dbContext.Meetings.Where(x=>x.IsActive==true).ToList();
            if(data==null)
            { 
                return new List<Meeting>(); 
            }

            return data;
        }

        public Meeting GetMeeting(int id)
        {
            Meeting data = dbContext.Meetings.Where(x => x.Id == id&&x.IsActive==true).FirstOrDefault();
            return data;
        }

        public Meeting GetMeeting(string subject)
        {
            Meeting data = dbContext.Meetings.Where(x => x.Subject==subject && x.IsActive == true).FirstOrDefault();
            return data;
        }

        public void Add(Meeting entity)
        {
            entity.IsActive = true;
            dbContext.Meetings.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Meeting entity)
        {
            Meeting model = dbContext.Meetings.Where(x => x.Id == entity.Id).FirstOrDefault();
            model.IsActive = false;
            dbContext.SaveChanges();
        }

        public void Update(Meeting entity)
        {
            Meeting data = dbContext.Meetings.Where(x => x.Id == entity.Id).FirstOrDefault();
            data.StartTime = entity.StartTime;
            data.EndTime = entity.EndTime;
            data.Subject = entity.Subject;
            //data.Participants = entity.Participants;

            dbContext.SaveChanges();

        }
    
    }
}
