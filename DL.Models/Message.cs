using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Message
    {
        public string Id { get; set; }        

        public string Type { get; set; }

        public string Text { get; set; }       

        public string Sender { get; set; }

        public string Recipient { get; set; }      

        public DateTime DateTime { get; set; }
    }
}
