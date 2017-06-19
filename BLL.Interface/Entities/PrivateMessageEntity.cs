using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class PrivateMessageEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Preview { get; set; }
        public string Status { get; set; }
        public int RecipientId { get; set; }
        public int SenderId { get; set; }
    }
}
