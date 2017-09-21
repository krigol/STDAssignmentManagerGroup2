using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : Controller
    {
        //
        // GET: /Assignment/
        public ActionResult Index()
        {
            var assingments = new List<Assignment>();
            var assingmentRepository = new AssignmentRepository();
            assingments.AddRange(assingmentRepository.GetAll());

            return View(assingments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Assignment entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.IsDone = false;

            var assignmentRepository = new AssignmentRepository();

            assignmentRepository.Insert(entity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var assignmentRepository = new AssignmentRepository();
            Assignment entity = assignmentRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Assignment entity)
        {
            var assignmentRepository = new AssignmentRepository();
            entity.UpdatedAt = DateTime.Now;

            assignmentRepository.Update(entity);

            return RedirectToAction("Index"); 
        }

        public ActionResult Delete(int id)
        {
            var assignmentRepository = new AssignmentRepository();
            Assignment entity = assignmentRepository.GetById(id);

            assignmentRepository.Delete(entity);

            return RedirectToAction("Index");
        }
	}
}