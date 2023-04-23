using System;
using System.Net;
using DeliveryService.Enums;
using DeliveryService.Model;

namespace DeliveryService.Services
{
    public interface IAuthenticationService
    {
        public Worker? AuthenticateWorker(NetworkCredential credential);

        public bool HasAccessToSection(AppPages section);

        public bool HasAccessToSubSection<T>(T subSection) where T: Enum;

        public bool HasPermissionToModifySubsection<T>(T dtoSubSection) where T : Enum;
    }
}
