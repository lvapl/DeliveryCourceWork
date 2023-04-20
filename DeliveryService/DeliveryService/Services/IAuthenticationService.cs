using DeliveryService.Enums;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IAuthenticationService
    {
        public Worker? AuthenticateWorker(NetworkCredential credential);

        public bool HasAccessToSection(AppPages section);

        public bool HasAccessToSubSection<T>(T subSection) where T: System.Enum;

        public bool HasPermissionToModifySubsection<T>(T DTOSubSection) where T : System.Enum;
    }
}
