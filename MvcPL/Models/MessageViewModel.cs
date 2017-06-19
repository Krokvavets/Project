using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class MessageViewModel
    {
        public UserEntity User { get; set; }
        public MessageEntity Message { get; set; }
    }
}