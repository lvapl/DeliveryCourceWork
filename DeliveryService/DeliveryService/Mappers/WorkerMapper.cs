using DeliveryService.DTO;
using DeliveryService.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class WorkerMapper
    {
        private static DsContext _context = App.ServiceProvider.GetRequiredService<DsContext>();

        public static WorkerDTO Map(Worker worker)
        {
            return new WorkerDTO
            {
                Id = worker.Id,
                Login = worker.Login,
                Password = worker.Password,
                FirstName = worker.IdNavigation.Firstname,
                LastName = worker.IdNavigation.Lastname,
                Patronymic = worker.IdNavigation.Patronymic,
                PositionId = worker.PositionId,
                Title = worker.Position.Title,
                PassportNumber = worker.IdNavigation.PassportNumber,
                PassportSeries = worker.IdNavigation.PassportSeries,
                TelephoneNumber = worker.IdNavigation.TelephoneNumber,
                Address = worker.IdNavigation.Address == null ? null : AddressMapper.Map(worker.IdNavigation.Address),
                PassportAddress = worker.IdNavigation.PassportAddressNavigation == null ? null : AddressMapper.Map(worker.IdNavigation.PassportAddressNavigation),
                WorkerImage = worker.Image == null ? null : worker.Image.WorkerImage1
            };
        }

        public static void Map(WorkerDTO workerDTO, Worker worker)
        {
            worker.Login = workerDTO.Login;
            worker.Password = workerDTO.Password;
            worker.IdNavigation.Firstname = workerDTO.FirstName;
            worker.IdNavigation.Lastname = workerDTO.LastName;
            worker.IdNavigation.Patronymic = workerDTO.Patronymic;
            worker.PositionId = workerDTO.PositionId;
            worker.IdNavigation.PassportNumber = workerDTO.PassportNumber;
            worker.IdNavigation.PassportSeries = workerDTO.PassportSeries;
            worker.IdNavigation.TelephoneNumber = workerDTO.TelephoneNumber;

            if (workerDTO.WorkerImage != null)
            {
                WorkerImage image = new WorkerImage() { WorkerImage1 = workerDTO.WorkerImage };
                _context.WorkerImages.Add(image);
                _context.SaveChanges();
                worker.Image = image;
            }

            if (workerDTO.Address != null)
            {
                AddressMapper.Map(workerDTO.Address, (worker.IdNavigation.Address = new Address()));
            }

            if (workerDTO.PassportAddress != null)
            {
                AddressMapper.Map(workerDTO.PassportAddress, (worker.IdNavigation.PassportAddressNavigation = new Address()));
            }
        }

        public static IEnumerable<WorkerDTO> MapAll(IEnumerable<Worker> workers)
        {
            return workers.ToList().ConvertAll<WorkerDTO>(x => Map(x));
        }
    }
}
