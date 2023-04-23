using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.Mappers
{
    public static class WorkerMapper
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
                WorkerImage = worker.Image?.WorkerImage1
            };
        }

        public static void Map(WorkerDTO workerDto, Worker worker)
        {
            worker.Login = workerDto.Login;
            worker.Password = workerDto.Password;
            worker.IdNavigation.Firstname = workerDto.FirstName;
            worker.IdNavigation.Lastname = workerDto.LastName;
            worker.IdNavigation.Patronymic = workerDto.Patronymic;
            worker.PositionId = workerDto.PositionId;
            worker.IdNavigation.PassportNumber = workerDto.PassportNumber;
            worker.IdNavigation.PassportSeries = workerDto.PassportSeries;
            worker.IdNavigation.TelephoneNumber = workerDto.TelephoneNumber;

            if (workerDto.WorkerImage != null)
            {
                WorkerImage image = new WorkerImage() { WorkerImage1 = workerDto.WorkerImage };
                _context.WorkerImages.Add(image);
                _context.SaveChanges();
                worker.Image = image;
            }

            if (workerDto.Address != null)
            {
                AddressMapper.Map(workerDto.Address, (worker.IdNavigation.Address = new Address()));
            }

            if (workerDto.PassportAddress != null)
            {
                AddressMapper.Map(workerDto.PassportAddress, (worker.IdNavigation.PassportAddressNavigation = new Address()));
            }
        }

        public static IEnumerable<WorkerDTO> MapAll(IEnumerable<Worker> workers)
        {
            return workers.ToList().ConvertAll(Map);
        }
    }
}
