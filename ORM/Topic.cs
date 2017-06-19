using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Topic
    {
        public Topic()
        {
            Messages = new List<Message>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SectionId { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual Section Section { get; set; }
    }
}
