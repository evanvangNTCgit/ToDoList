using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         *  TODO: Add a different (or maybe the same?) window for editing a task.
         */
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TaskInput_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var taskSample = new Task("", 1, "Add a description");

            // This code is ran to add into the addingTaskWindow for ensuring that the 
            // User does not use the same two priority numbers (EX: two priority one tasks)
            List<Task> tasks = new List<Task>();
            foreach (Task task in TasksList.Items) 
            {
                tasks.Add(task);
            }

            var addingTaskWindow = new TaskAddWindow(taskSample, tasks);
            addingTaskWindow.ShowDialog();

            TasksList.Items.Add(taskSample);
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            TasksList.Items.Remove(TasksList.SelectedItem);
        }

        public void ReOrderTasksList() 
        {
            var taskListToSort = new List<Task>();

            foreach (Task task in TasksList.Items) 
            {
                taskListToSort.Add(task);
            }

            // Using bubbleSort.
            var taskListSorted = SortTasks(taskListToSort);

            TasksList.Items.Clear();

            foreach(Task task in taskListSorted) 
            {
                TasksList.Items.Add((Task)task);
            }
        }

        public List<Task> SortTasks(List<Task> taskList) 
        {
            for (int i = 0; i < taskList.Count; i++) 
            {
                for (int j = 0; j < taskList.Count - 1; j++) 
                {
                    if (taskList[j].Priority > taskList[i].Priority) 
                    {
                        var tempVar = taskList[j];
                        taskList[j] = taskList[i];
                        taskList[i] = tempVar;
                    }
                }
            }

            return taskList;
        }

        //ReOrder Tasks Button Click
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReOrderTasksList();

            Console.WriteLine("Stop");
        }
    }
}