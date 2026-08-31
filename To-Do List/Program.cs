namespace To_Do_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<listItem> taskList = new List<listItem>();
            renderTaskList(taskList);
            while (true)
            {
                string task = Console.ReadLine();
                if (task == "addTask")
                {
                    bool isEmpty = true;
                    string taskName = "";
                    while (isEmpty == true)
                    {
                        Console.WriteLine("What is the task name?");
                       taskName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(taskName)) {
                            isEmpty = false;
                        }
                    }
                    listItem item = new listItem();
                    item.setName(taskName);
                    taskList.Add(item);
                    renderTaskList(taskList);

                } else if (task == "completeTask")
                {
                    if (taskList.Count == 0)
                    {
                        Console.WriteLine("No tasks to complete");
                        renderTaskList(taskList);
                    }
                    else
                    {
                        bool isAnInt = false;
                        int completedTaskID = 0;
                        while (isAnInt == false || (completedTaskID > (taskList.Count-1) || completedTaskID < (taskList.Count - 1)))
                        {
                            completeTaskList(taskList);
                            string completedTaskIDString = Console.ReadLine();
                            isAnInt = Int32.TryParse(completedTaskIDString, out completedTaskID);
                        }
                        
                        taskList[completedTaskID].setremovedOrNot(false);
                        renderTaskList(taskList);
                    }

                } else if (task == "exit")
                {
                    break;
                } else
                {
                    Console.WriteLine("enter either 'addTask', 'completeTask', or 'exit'");
                }
            }
        }
        private static void renderTaskList(List<listItem> taskList)
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("Task List:");
                Console.WriteLine("- NONE");
                Console.WriteLine("Menu: ");
                Console.WriteLine("- addTask");
                Console.WriteLine("- completeTask");
                Console.WriteLine("- exit");
            }
            else
            {
                Console.WriteLine("Task List:");
                printTaskList(taskList);
                Console.WriteLine("Menu: ");
                Console.WriteLine("- addTask");
                Console.WriteLine("- completeTask");
                Console.WriteLine("- exit");
            }
        }

        private static void printTaskList(List<listItem> taskList) {
            foreach (listItem item in taskList)
            {
                if (item.removedOrNot == false)
                {
                    Console.WriteLine($"[X] {item.name}");
                   
                } else
                {
                    Console.WriteLine($"[ ] {item.name}");
                }
                

            }
        }
        
        private static void completeTaskList(List<listItem> taskList)
        {

            for (int i = 0; i < taskList.Count; i++) {
                Console.WriteLine($"[{i}] [ ] {taskList[i].name}");
            }
            Console.WriteLine("Enter the the number of the completed task");

        }

        private class listItem
        {
            public void setName(string name)
            {
                this.name = name;
            }
            public void setremovedOrNot(bool removedOrNot)
            {
                this.removedOrNot = removedOrNot;
            }
            public string name;
            public bool removedOrNot = true;
        }


    }
}
