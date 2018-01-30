using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketChat.Models
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
