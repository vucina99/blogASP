using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Email
{
    public class SendEmail
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
