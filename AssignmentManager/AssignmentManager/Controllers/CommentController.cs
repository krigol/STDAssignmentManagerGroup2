using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using AssignmentManager.Models;
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

            var model = new CommentsListViewModel();

            model.AssignmentTitle = assignmentRepostory.GetById(id).Title;
            model.AssignmentId = id;

            foreach (var entity in comments)
            {
                var commentModel = new CommentViewModel
                {
                    Id = entity.Id,
                    Content = entity.Content,
                    Title = entity.Title,
                    CreatedAt = entity.CreatedAt,
                    UpdatedAt = entity.UpdatedAt,
                    AssignmentId = entity.AssignmentId
                };

                model.Comments.Add(commentModel);
            }

            // Navigational Properties example

            //var firstEntity = comments.FirstOrDefault();
            //ViewBag.AssignmentTitle =
            //    firstEntity != null ? firstEntity.Assignment.Title : "No COMMENTS YET";

            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var model = new CommentViewModel()
            { 
                AssignmentId = id
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Comment();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.AssignmentId = model.AssignmentId;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Insert(entity);

            return RedirectToAction("Index/" + entity.AssignmentId);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetById(id);

            var model = new CommentViewModel
            {
                Id = entity.Id,
                Content = entity.Content,
                Title = entity.Title,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                AssignmentId = entity.AssignmentId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Comment();
            entity.UpdatedAt = DateTime.Now;
            entity.CreatedAt = model.CreatedAt;
            entity.Content = model.Content;
            entity.Id = model.Id;
            entity.AssignmentId = model.AssignmentId;
            entity.Title = model.Title;

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