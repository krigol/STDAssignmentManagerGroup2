using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}