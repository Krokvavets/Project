using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class SectionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }
        public List<TopicEntity> Topics { get; set; }
    }
}