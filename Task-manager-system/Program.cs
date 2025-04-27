// Create a basic task manager that stores and display up to three tasks

// Add a task
// Mark tasks as completed
// Display the status of each tasks (either completed or pending)

// create a variable for tasks and thier status

string[,] tasks = new string[3, 2];
string userInput = "";
bool found = false;

//menu selection
do
{
    Console.WriteLine("Enter 1, 2, 3 or exit to navigate");
    Console.WriteLine("1. Add task\n 2. Set task status\n 3. Display task and thier status");
    userInput = Console.ReadLine().Trim();

    if (!string.IsNullOrEmpty(userInput))
    {
        string choice = userInput;
        switch (choice)
        {
            case "1":
                addTask(ref tasks);
                break;

            case "2":
           if( markStatus(ref tasks))
           {
            Console.WriteLine("Task masked as completed successfully");
           }
           else
           {
            Console.WriteLine("Try again");
           }
                break;

            case "3":
                displayTask(ref tasks);
        break;

            case "exit":
                break;

            default:
                Console.WriteLine("Invalid input: Enter either 1, 2, 3 or exit");
                break;
        }
    }
} while (userInput != "exit");
// prompt user to add a task
void addTask(ref string[,] task, string status = "Pending")
{
    bool success = false;
    
    do
    { 
        Console.WriteLine("Enter the name of the task");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            string taskName = userInput.Trim();
            for (int i = 0; i < task.GetLength(0); i++)
            {
                if (task[i, 0] == null)
                {
                    task[i, 1] = status;
                    task[i, 0] = taskName;
                    Console.WriteLine("Task added successfully");
                    success = true;
                    break;
                }
                
            if ( i == task.GetLength(0) - 1)
            {
                Console.WriteLine("Task list is full. New task cannot be added");
                success = true;
                break;
            }
            }
                
            }
        else
        {
            Console.WriteLine("Task name cannot be empty.");
            success = false;
        }

    } while (success == false);
}


// Mark task as comleted
bool markStatus(ref string[,] task)
{
    for (int i = 0; i < task.GetLength(0); i++)
    {
        if (!string.IsNullOrEmpty(task[i, 0]))
        {
            Console.WriteLine($"Index {i + 1}: {task[i, 0]} is {task[i, 1]}");
            bool found = true;
        }
    }
    if (!found)
    {
        Console.WriteLine("No task to display");
        return false;
    }
    Console.WriteLine("Enter index to mark status as complete.");
    userInput = Console.ReadLine().Trim();
    if (!string.IsNullOrEmpty(userInput))
    {
        int.TryParse(userInput, out int index);
        index = index - 1;
            switch (index)
            {
                case 0:
                    task[index, 1] = "Completed";
                    Console.WriteLine($"{task[index, 0]} is {task[index, 1]}");
                    break;

                case 1:
                    task[index, 1] = "Completed";
                    Console.WriteLine($"{task[index, 0]} is {task[index, 1]}");
                    break;

                case 2:
                    task[index, 1] = "Completed";
                    Console.WriteLine($"{task[index, 0]} is {task[index, 1]}");
                    break;

                default:
                    Console.WriteLine("Invalid Index");
                    return false;
                    break;
            }
        }
    return true;
}

void displayTask(ref string[,] task)
{
    for (int i = 0; i < task.GetLength(0); i++)
    {
        if (!string.IsNullOrEmpty(task[i, 0]))
        {
            Console.WriteLine($"{task[i, 0]} is {task[i, 1]}");
            found = true;
        }
    }
     if (!found)
    {
        Console.WriteLine("No task to display");
    }
    
}