using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class CommentsListViewModel
    {
        public string AssignmentTitle { get; set; }

        public int AssignmentId { get; set; }

        public List<CommentViewModel> Comments { get; private set; }

        public CommentsListViewModel()
        {
            Comments = new List<CommentViewModel>();
        }
    }
}