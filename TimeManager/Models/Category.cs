using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    /// <summary>
    /// Категория задачи
    /// </summary>
    class Category
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Длительность задачи
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
