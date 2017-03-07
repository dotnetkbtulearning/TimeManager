using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    /// <summary>
    /// Назначаемая задача
    /// </summary>
    class TaskAction
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public Person Person { get; set; }
        
        /// <summary>
        /// Категория задачи
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Плановая дата начала работы
        /// </summary>
        public DateTime PlanStart { get; set; }

        /// <summary>
        /// Флаг окончания задачи
        /// </summary>
        public bool IsFinished { get; set; }
    }
}
