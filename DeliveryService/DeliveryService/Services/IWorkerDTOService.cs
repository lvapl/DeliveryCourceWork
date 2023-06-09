﻿using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="WorkerDTO"/>.
    /// </summary>
    public interface IWorkerDTOService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="workerGeneralInfoDto">Добавляемый элемент.</param>
        public void Add(WorkerDTO workerGeneralInfoDto);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="workerGeneralInfoDto">Редактирует существующий элемент.</param>
        public void Edit(WorkerDTO workerGeneralInfoDto);

        /// <summary>
        /// Удаляет элемент по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого элемента.</param>
        public void Remove(int id);

        /// <summary>
        /// Возвращает элемент по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Найденный элемент.</returns>
        public WorkerDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        public IEnumerable<WorkerDTO> GetAll();
    }
}
