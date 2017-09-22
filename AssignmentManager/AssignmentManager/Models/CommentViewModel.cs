﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int AssignmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}