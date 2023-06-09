﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DTO
{
    /// <summary>
    /// Объект служащий для отображения и изменения необходимых данных.
    /// </summary>
    public class WorkerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Patronymic { get; set; }

        public int PositionId { get; set; }

        public string Title { get; set; } = null!;

        public string Login { get; set; } = null!;

        public byte[] Password { get; set; } = null!;

        public int PassportNumber { get; set; }

        public int PassportSeries { get; set; }

        public string TelephoneNumber { get; set; } = null!;

        public AddressDTO? Address { get; set; }

        public AddressDTO? PassportAddress { get; set; }

        public byte[]? WorkerImage { get; set; }
    }
}
