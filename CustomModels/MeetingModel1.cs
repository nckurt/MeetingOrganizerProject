using MeetingOrganizer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModels
{
    public class MeetingModel1
    {       
        public int Id { get; set; }
        [Required(ErrorMessage = "Toplantı konusu girilmelidir.")]
        [Display(Name ="Toplantı Konusu")]
        public string Subject { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "toplantı tarihi girilmelidir.")]
        [Display(Name = "Toplantı Tarihi")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Başlangıç saati girilmelidir.")]
        [Display(Name = "Başlangıç Saati")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode =true)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Bitiş saati girilmelidir.")]
        [Display(Name = "Bitiş Saati")]
        public DateTime EndTime { get; set; }        
    }
}
