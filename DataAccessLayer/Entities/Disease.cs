using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Disease:IBaseEntity
    {
        public Disease()
        {
            Note = new List<Note>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int DiseaseStatusId { get; set; }

        public virtual DiseaseStatus DiseaseStatus { get; set; }
        public virtual ICollection<Note> Note { get; set; }
    }
}
