using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class MessageEntity
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
