using CustomModels;
using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class MeetingMapping
    {
        public MeetingModel1 ToModel(Meeting entity)
        {
            return new MeetingModel1
            {
                Date = entity.Date,
                EndTime = entity.EndTime,
                Id = entity.Id,
                StartTime = entity.StartTime,
                Subject = entity.Subject
            };
        }

        public Meeting ToEntity(MeetingModel1 model)
        {
            return new Meeting
            {
                Date = model.Date,
                EndTime = model.EndTime,
                Id = model.Id,
                StartTime = model.StartTime,
                Subject = model.Subject
            };
        }
    }
}
