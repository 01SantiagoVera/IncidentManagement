using System;
using System.Collections.Generic;
using System.Linq;
using IncidentManagement.Data.Repositories;
using IncidentManagement.Entities.Models;
using IncidentManagement.Services.Interfaces;

namespace IncidentManagement.Services.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IRepository<Incident> _incidentRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<User> _userRepository;

        public IncidentService(
            IRepository<Incident> incidentRepository,
            IRepository<Comment> commentRepository,
            IRepository<User> userRepository)
        {
            _incidentRepository = incidentRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public Incident GetIncidentById(int id)
        {
            return _incidentRepository.GetById(id);
        }

        public IEnumerable<Incident> GetAllIncidents()
        {
            return _incidentRepository.GetAll();
        }

        public IEnumerable<Incident> GetIncidentsByStatus(IncidentStatus status)
        {
            return _incidentRepository.Find(i => i.Status == status);
        }

        public IEnumerable<Incident> GetIncidentsByPriority(Priority priority)
        {
            return _incidentRepository.Find(i => i.Priority == priority);
        }

        public IEnumerable<Incident> GetIncidentsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _incidentRepository.Find(i => i.CreatedDate >= startDate && i.CreatedDate <= endDate);
        }

        public IEnumerable<Incident> GetIncidentsByTechnician(int technicianId)
        {
            return _incidentRepository.Find(i => i.AssignedTechnicianId == technicianId);
        }

        public void CreateIncident(Incident incident)
        {
            incident.CreatedDate = DateTime.Now;
            incident.LastUpdatedDate = DateTime.Now;
            _incidentRepository.Add(incident);
        }

        public void UpdateIncident(Incident incident)
        {
            incident.LastUpdatedDate = DateTime.Now;
            _incidentRepository.Update(incident);
        }

        public void DeleteIncident(int id)
        {
            var incident = _incidentRepository.GetById(id);
            if (incident != null)
            {
                _incidentRepository.Delete(incident);
            }
        }

        public void AssignTechnician(int incidentId, int technicianId)
        {
            var incident = _incidentRepository.GetById(incidentId);
            if (incident != null)
            {
                incident.AssignedTechnicianId = technicianId;
                incident.LastUpdatedDate = DateTime.Now;
                _incidentRepository.Update(incident);
            }
        }

        public void UpdateStatus(int incidentId, IncidentStatus status)
        {
            var incident = _incidentRepository.GetById(incidentId);
            if (incident != null)
            {
                incident.Status = status;
                incident.LastUpdatedDate = DateTime.Now;
                _incidentRepository.Update(incident);
            }
        }

        public void AddComment(int incidentId, int userId, string content)
        {
            var comment = new Comment
            {
                IncidentId = incidentId,
                UserId = userId,
                Content = content,
                CreatedDate = DateTime.Now
            };
            _commentRepository.Add(comment);
        }

        public IEnumerable<Comment> GetIncidentComments(int incidentId)
        {
            return _commentRepository.Find(c => c.IncidentId == incidentId);
        }
    }
} 