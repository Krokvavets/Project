using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public string Footer { get; set; }
        public string Note { get; set; }
        public string Quote { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }


    }
}
