using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IncidentManagement.Entities.Models;
using IncidentManagement.Services.Interfaces;

namespace IncidentManagement.Web.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        // GET: Incident
        public ActionResult Index()
        {
            var incidents = _incidentService.GetAllIncidents();
            return View(incidents);
        }

        // GET: Incident/Details/5
        public ActionResult Details(int id)
        {
            var incident = _incidentService.GetIncidentById(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incident/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incident/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Incident incident)
        {
            if (ModelState.IsValid)
            {
                _incidentService.CreateIncident(incident);
                return RedirectToAction("Index");
            }
            return View(incident);
        }

        // GET: Incident/Edit/5
        public ActionResult Edit(int id)
        {
            var incident = _incidentService.GetIncidentById(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: Incident/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                _incidentService.UpdateIncident(incident);
                return RedirectToAction("Index");
            }
            return View(incident);
        }

        // POST: Incident/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _incidentService.DeleteIncident(id);
            return RedirectToAction("Index");
        }

        // POST: Incident/AssignTechnician
        [HttpPost]
        public JsonResult AssignTechnician(int incidentId, int technicianId)
        {
            try
            {
                _incidentService.AssignTechnician(incidentId, technicianId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Incident/UpdateStatus
        [HttpPost]
        public JsonResult UpdateStatus(int incidentId, IncidentStatus status)
        {
            try
            {
                _incidentService.UpdateStatus(incidentId, status);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Incident/AddComment
        [HttpPost]
        public JsonResult AddComment(int incidentId, int userId, string content)
        {
            try
            {
                _incidentService.AddComment(incidentId, userId, content);
                var comments = _incidentService.GetIncidentComments(incidentId);
                return Json(new { success = true, comments = comments });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Incident/GetComments/5
        public JsonResult GetComments(int id)
        {
            var comments = _incidentService.GetIncidentComments(id);
            return Json(comments, JsonRequestBehavior.AllowGet);
        }
    }
} 