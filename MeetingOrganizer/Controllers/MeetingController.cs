using BLL.Mapping;
using BLL.Services;
using CustomModels;
using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.Controllers
{
    public class MeetingController : Controller
    {
        MeetingOrganizerDbContext dbContext = new MeetingOrganizerDbContext();
        MeetingService meetingService = new MeetingService();
        ParticipantService participantService= new ParticipantService();
        MeetingMapping meetingMapping = new MeetingMapping();
        //private readonly MeetingService meetingService;
        //public MeetingController()
        //{

        //}
        //public MeetingController(MeetingService meetingService)
        //{
        //    this.meetingService = meetingService;
        //}
        // GET: Meeting
        public ActionResult Index()
        {                        
            var data=meetingService.GetAllMeetings();
         
            List<MeetingModel1> model = new List<MeetingModel1>();

            foreach (var item in data)
            {
                var meetingModel= meetingMapping.ToModel(item);
                model.Add(meetingModel);
            }          
            return View(model);
              
        }

        public ActionResult Add()
        {            
            return View(new FormModel()) ;
        }

        [HttpPost]
        public ActionResult Add(FormModel model )
        {
            Meeting entity=meetingMapping.ToEntity(model.MeetingModel);
            entity.IsActive = true;
            meetingService.Add(entity);
            Meeting meetingEntity=meetingService.GetMeeting(entity.Subject);
            foreach (var participant in model.Participants)
            {
                participant.MeetingId = meetingEntity.Id;
                participantService.Add(participant);                
            }
            return RedirectToAction("Index", "Meeting");
        }

        public ActionResult Update(int meetingId)
        {
            FormModel formModel = new FormModel();

            var meeting=meetingService.GetMeeting(meetingId);
            var model = meetingMapping.ToModel(meeting);

            var participants = participantService.GetAllParticipants(meetingId);
            foreach (var participant in participants)
            {
                if(participant.Id==0)
                {
                    participantService.Add(participant);
                }
                else
                {
                    participantService.Update(participant);
                }                
            }

            formModel.MeetingModel = model;
            formModel.Participants = participants;
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Update(FormModel model)
        {
            var entity=meetingMapping.ToEntity(model.MeetingModel);
            meetingService.Update(entity);

            var participants = participantService.GetAllParticipants(model.MeetingModel.Id);
            if(model.Participants.Count!=0)
            {
                foreach (var item in model.Participants)
                {
                    item.MeetingId = model.MeetingModel.Id;
                    participants.Add(item);
                }
            }

            foreach (var participant in participants)
            {
                if (participant.Id == 0)
                {
                    participantService.Add(participant);
                }
                else
                {
                    participantService.Update(participant);
                }
            }
            return RedirectToAction("Index", "Meeting");
        }
        
        public ActionResult Delete(int meetingId)
        {
            var meeting = meetingService.GetMeeting(meetingId);
            meetingService.Delete(meeting);
            return RedirectToAction("Index", "Meeting");
        }
    }
}