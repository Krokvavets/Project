using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SectionId { get; set; }
        [Required]
        public string TextMessage { get; set; }
        public virtual ICollection<MessageEntity> Messages { get; set; }
    }
}