using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModels
{
    public class FormModel
    {
        public FormModel()
        {
            MeetingModel = new MeetingModel1();
            Participants = new List<Participant>();
        }
        public MeetingModel1 MeetingModel{ get; set; }
        public List<Participant> Participants{ get; set; }
    }
}
