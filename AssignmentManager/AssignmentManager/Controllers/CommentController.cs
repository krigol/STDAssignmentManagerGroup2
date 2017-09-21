using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        public ActionResult Index(int id)
        {
            var commentsRepository = new CommentsRepository();
            List<Comment> comments = new List<Comment>();

            comments.AddRange(commentsRepository
                        .GetAll(comment => comment.AssignmentId == id));

            var assignmentRepostory = new AssignmentRepository();

            ViewBag.AssignmentTitle = assignmentRepostory.GetById(id).Title;
            ViewBag.AssignmentId = id;

            // Navigational Properties example

            //var firstEntity = comments.FirstOrDefault();
            //ViewBag.AssignmentTitle =
            //    firstEntity != null ? firstEntity.Assignment.Title : "No COMMENTS YET";

            return View(comments);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            Comment entity = new Comment()
            { 
                AssignmentId = id
            };

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(Comment entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Insert(entity);

            return RedirectToAction("Index/" + entity.AssignmentId);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Comment entity)
        {
            entity.UpdatedAt = DateTime.Now;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Update(entity);

            return RedirectToAction("Index/" + entity.AssignmentId); 
        }

        public ActionResult Delete(int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetById(id);

            commentsRepository.Delete(entity);

            return RedirectToAction("Index/" + entity.AssignmentId); 
        }
	}
}