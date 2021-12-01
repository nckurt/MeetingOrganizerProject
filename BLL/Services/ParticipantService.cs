using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ParticipantService
    {
        MeetingOrganizerDbContext dbContext = new MeetingOrganizerDbContext();
        public ParticipantService()
        {

        }

        public List<Participant> GetAllParticipants()
        {
            List<Participant> data = dbContext.Participants.ToList();            
            return data;
        }

        public List<Participant> GetAllParticipants(int meetingId)
        {
            List<Participant> data = dbContext.Participants.Where(x => x.MeetingId == meetingId).ToList();
            return data;
        }

        public Participant GetParticipant(int id)
        {
            Participant data = dbContext.Participants.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public void Add(Participant entity)
        {
            dbContext.Participants.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Participant entity)
        {
            dbContext.Participants.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(Participant entity)
        {
            Participant data = dbContext.Participants.Where(x => x.Id == entity.Id).FirstOrDefault();
            data.Email = entity.Email;            
            dbContext.SaveChanges();

        }
    }
}
