using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ERMAN.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationRepository _notificationRepo;
        public NotificationController(NotificationRepository notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }

        [HttpGet(Name = "GetNotifications")]
        [Authorize(Roles = "Student, Coordinator")]
        public List<Notification> GetAll()
        {
            return _notificationRepo.GetAll();
        }
    }
}
