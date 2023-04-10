using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class WorkerMapper
    {
        public static WorkerGeneralInfoDTO Map(Worker worker)
        {
            return new WorkerGeneralInfoDTO
            {
                Id = worker.Id,
                Login = worker.Login,
                Password = worker.Password,
                FirstName = worker.IdNavigation.Firstname,
                LastName = worker.IdNavigation.Lastname,
                Patronymic = worker.IdNavigation.Patronymic,
                Title = worker.Position.Title,
                PassportNumber = worker.IdNavigation.PassportNumber,
                PassportSeries = worker.IdNavigation.PassportSeries,
                TelephoneNumber = worker.IdNavigation.TelephoneNumber,
                AddressId = worker.IdNavigation.AddressId,
                PassportAddressId = worker.IdNavigation.PassportAddress
                
            };
        }

        public static void Map(WorkerGeneralInfoDTO workerDTO, Worker worker)
        {
            worker.Login = workerDTO.Login;
            worker.Password = workerDTO.Password;
            worker.IdNavigation.Firstname = workerDTO.FirstName;
            worker.IdNavigation.Lastname = workerDTO.LastName;
            worker.IdNavigation.Patronymic = workerDTO.Patronymic;
            worker.Position.Title = workerDTO.Title;
            worker.IdNavigation.PassportNumber = workerDTO.PassportNumber;
            worker.IdNavigation.PassportSeries = workerDTO.PassportSeries;
            worker.IdNavigation.TelephoneNumber = workerDTO.TelephoneNumber;
            worker.IdNavigation.AddressId = workerDTO.AddressId;
            worker.IdNavigation.PassportAddress = workerDTO.PassportAddressId;
        }

        public static IEnumerable<WorkerGeneralInfoDTO> MapAll(IEnumerable<Worker> workers)
        {
            return workers.ToList().ConvertAll<WorkerGeneralInfoDTO>(x => Map(x));
        }
    }
}
