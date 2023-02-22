using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using TaskScheduled = Microsoft.Win32.TaskScheduler.Task;

namespace Shopee_Automate
{
    class Scheduler
    {
        private static TaskService _taskService = new TaskService();
        private TaskScheduled _task;

        public static string TaskName = "ShopeeAutomate";
        public static string TaskPath = TaskName;

        public Scheduler()
        {
            _task = _taskService.GetTask(TaskPath);
        }

        public bool CreateTask(DailyTrigger time)
        {
            if (_task != null) return true;

            TaskDefinition ntask = _taskService.NewTask();
            ntask.RegistrationInfo.Description = "自動化蝦幣領取";

            ntask.Triggers.Add(time);
            ntask.Actions.Add(new ExecAction(Program.ExecutePath, "nogui", Util.CurrentPath));

            Console.WriteLine("成功新增 Scheduler!");

            _task = _taskService.RootFolder.RegisterTaskDefinition(TaskName, ntask);

            return true;
        }

        public bool DeleteTask()
        {
            if (_task == null) return true;

            _taskService.RootFolder.DeleteTask(TaskName);

            _task.Dispose();

            _task = null;

            Console.WriteLine("成功刪除 Scheduler!");
            return true;
        }

        public bool CheckTaskExists()
        {
            return _task != null;
        }
    }
}
