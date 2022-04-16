using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.RabbitMQ.Api.Models
{
    public class Notification : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
    }
}
