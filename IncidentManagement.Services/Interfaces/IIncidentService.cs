using System;
using System.Collections.Generic;
using IncidentManagement.Entities.Models;

namespace IncidentManagement.Services.Interfaces
{
    public interface IIncidentService
    {
        Incident GetIncidentById(int id);
        IEnumerable<Incident> GetAllIncidents();
        IEnumerable<Incident> GetIncidentsByStatus(IncidentStatus status);
        IEnumerable<Incident> GetIncidentsByPriority(Priority priority);
        IEnumerable<Incident> GetIncidentsByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Incident> GetIncidentsByTechnician(int technicianId);
        void CreateIncident(Incident incident);
        void UpdateIncident(Incident incident);
        void DeleteIncident(int id);
        void AssignTechnician(int incidentId, int technicianId);
        void UpdateStatus(int incidentId, IncidentStatus status);
        void AddComment(int incidentId, int userId, string content);
        IEnumerable<Comment> GetIncidentComments(int incidentId);
    }
} 