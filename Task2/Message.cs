using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task2
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
        public override string ToString()
        {
            return $" {this.DateTime.ToString()} {this.Name.ToString()} : {this.Text.ToString()}";
        }
    }
}
