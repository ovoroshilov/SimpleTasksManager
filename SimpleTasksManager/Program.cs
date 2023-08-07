using System;
namespace SimpleTasksManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskDbContext taskDbContext = new TaskDbContext();
            Program program = new Program();
            ChooseAction(taskDbContext, program);
        }
        public static void ChooseAction(TaskDbContext taskDbContext, Program program)
        {
            while (true)
            {
                Console.WriteLine("Choose action: ");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Add task");
                Console.WriteLine("2 - Delete Task");
                Console.WriteLine("3 - Check task by ID");
                Console.WriteLine("4 - Check all tasks");
                Console.WriteLine("5 - Update task");

                int act = Convert.ToInt32(Console.ReadLine());
                switch (act)
                {
                    case 1:
                        program.CreateTask(taskDbContext);
                        break;
                    case 2:
                        program.DeleteTask(taskDbContext);
                        break;
                    case 3:
                        program.GetTask(taskDbContext);
                        break;
                    case 4:
                        program.GetAllTask(taskDbContext);
                        break;
                    case 5:
                        program.Update(taskDbContext);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void CreateTask(TaskDbContext context)
        {
            Console.WriteLine("Write task title");
            string title = Console.ReadLine();
            Console.WriteLine("Write task discription");
            string discription = Console.ReadLine();
            context.CreateTask(title, discription, DateTime.Now);
        }
        private void DeleteTask(TaskDbContext context)
        {
            Console.WriteLine("Write deleted task id");
            int idForDelete = Convert.ToInt32(Console.ReadLine());
            context.DeleteTask(idForDelete);
        }
        private void Update(TaskDbContext context)
        {
            Console.WriteLine("Write task id for update");
            int idForUpdate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write task title");
            string updateTitle = Console.ReadLine();
            Console.WriteLine("Write task discription");
            string updateDiscription = Console.ReadLine();
            context.Update(idForUpdate, updateTitle, updateDiscription, DateTime.Now);
        }
        private void GetTask(TaskDbContext context)
        {
            Console.WriteLine("Write task id");
            int id = Convert.ToInt32(Console.ReadLine());
            context.GetTask(id);
        }
        private void GetAllTask(TaskDbContext context)
        {
            Console.WriteLine("Your all tasks: ");
            context.GetAllTask().ForEach(task => Console.WriteLine($"\n{task.Title}; \n{task.Description} \n{task.Date}"));
        }
    }
}
