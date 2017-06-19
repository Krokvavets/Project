using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalTopic : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }
    }
}
