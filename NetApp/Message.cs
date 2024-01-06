using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace NetApp
{
    internal class Message
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Message>(json);
        }

        public Message(string name, string text)
        {
            Name = name;
            Text = text;
            DateTime = DateTime.Now;
        }
    }
}
