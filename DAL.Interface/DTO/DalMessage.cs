using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalMessage : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Footer { get; set; }
        public string Note { get; set; }
        public string Quote { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
