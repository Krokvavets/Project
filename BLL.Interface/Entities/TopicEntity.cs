using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class TopicEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }
    }
}
