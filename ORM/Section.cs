using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Section
    {
        public Section()
        {
            Topics = new List<Topic>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
