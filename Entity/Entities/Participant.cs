using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.Entity
{
    public class Participant
    {
        public int Id { get; set; }
        public string FullName { get; set; }     
        [Display(Name ="E-Posta")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int MeetingId { get; set; }


    }
}
