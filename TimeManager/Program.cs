using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Models;

namespace TimeManager
{
    #region 
    // Задача:
    // Создание "задачи"
    // составление времени выполнения
    // отсчет времени

    // сущности:
    // Person
    // Task
    // Category
    #endregion


    class Program
    {
        /// <summary>
        /// Справочник категориев
        /// </summary>
        static List<Category> ListCategory = new List<Category>();

        /// <summary>
        /// Справочник Персонов
        /// </summary>
        static List<Person> ListPerson = new List<Person>();

        /// <summary>
        /// Список задач
        /// </summary>
        static List<TaskAction> ListTask = new List<TaskAction>();

        static void Main(string[] args)
        {
            // заполняем справочники
            RegistCategories();
            RegistPersons();

            // флаг для бесконечного цикла
            bool isWork = true;
            while (isWork)
            {
                // очередная иттерация
                var res = Run();

                if (res == "q")
                    isWork = false;
            }

            ShowAllTasks();

            Console.ReadKey();
        }

        /// <summary>
        /// Иттерация
        /// </summary>
        /// <returns>если результат будет 'q', то это значит завершить</returns>
        static string Run()
        {
            Console.Clear();
            Console.WriteLine("- - - Start - - - ");

            // select category
            Console.WriteLine("Выберите категорию");
            for (var i = 0; i < ListCategory.Count; i++)
            {
                Console.WriteLine(string.Format("{1}) {0}",
                    ListCategory[i].Name,
                    i));
            }
            Console.WriteLine("введите от 0 до " + (ListCategory.Count - 1));
            var selectedIntexCategory = Convert.ToInt32(Console.ReadLine());
            var selectedCategory = ListCategory[selectedIntexCategory];

            // select person
            Console.WriteLine("Выберите пользователя");
            for (var i = 0; i < ListPerson.Count; i++)
            {
                Console.WriteLine(string.Format("{1}) {0}", ListPerson[i].FullName, i));
            }
            Console.WriteLine("введите от 0 до " + (ListPerson.Count - 1));
            var selectedIntexPerson = Convert.ToInt32(Console.ReadLine());
            var selectedPerson = ListPerson[selectedIntexPerson];

            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("Вы выбрали: ");
            Console.WriteLine(string.Format("Категория: {0}", selectedCategory.Name));
            Console.WriteLine(string.Format("Пользователь: {0}", selectedPerson.FullName));

            CreateTask(selectedCategory, selectedPerson);

            Console.WriteLine("Желаете закончить? q - да");
            var res = Console.ReadLine();
            
            return res;
        }

        /// <summary>
        /// Заполнить справочник категориев
        /// </summary>
        static void RegistCategories()
        {
            var Category1 = new Category() { Name = "Домашнее задание", Duration = new TimeSpan(0, 30, 0) };
            var Category2 = new Category() { Name = "Уборка", Duration = new TimeSpan(0, 30, 0) };
            var Category3 = new Category() { Name = "Зарядка", Duration = new TimeSpan(0, 30, 0) };

            ListCategory.Add(Category1);
            ListCategory.Add(Category2);
            ListCategory.Add(Category3);
        }

        /// <summary>
        /// Заполнить справочник персонов
        /// </summary>
        static void RegistPersons()
        {
            var prs1 = new Person() { FullName = "Mark" };
            var prs2 = new Person() { FullName = "Sam" };
            var prs3 = new Person() { FullName = "John" };

            ListPerson.Add(prs1);
            ListPerson.Add(prs2);
            ListPerson.Add(prs3);
        }

        /// <summary>
        /// Создать задачу
        /// </summary>
        /// <param name="category">Выбранная категория</param>
        /// <param name="person">Выбранный персон</param>
        static void CreateTask(Category category, Person person)
        {
            var task = new TaskAction()
            {
                Id = ListTask.Count + 1,
                Category = category,
                Person = person,
                IsFinished = false,
                PlanStart = DateTime.Now
            };


            ListTask.Add(task);
        }

        /// <summary>
        /// Отобразить все задачи
        /// </summary>
        static void ShowAllTasks()
        {
            Console.Clear();
            Console.WriteLine("**********");
            Console.WriteLine("All tasks");

            foreach (var task in ListTask)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2} | {3} ",
                    task.Id,
                    task.Category.Name,
                    task.Person.FullName,
                    task.IsFinished));
            }
            Console.WriteLine("**********");
        }
    }
}
