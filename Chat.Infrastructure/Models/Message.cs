using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Models
{
    public sealed class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }  = string.Empty;
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public bool IsEveryone { get; set; } = true;
    }
}
