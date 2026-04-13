using System.Collections.Generic;

namespace CybersecurityChatbot.Models
{
    public class Response
    {
        public string Pattern { get; set; }
        public List<string> Responses { get; set; }
        public string Category { get; set; }
    }
}

