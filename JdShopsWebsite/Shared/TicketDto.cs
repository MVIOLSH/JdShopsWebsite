﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdShopsWebsite.Shared
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string TypeOfRequest { get; set; }
        public string ShopNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
    }
}
