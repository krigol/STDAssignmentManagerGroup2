﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Title must be at least 8 symbols.")]
        [DisplayName("Заглавие: ")]
        public string Title { get; set; }

        [DisplayName("Описание: ")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsDone { get; set; }

    }
}