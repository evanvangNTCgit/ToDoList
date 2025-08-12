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
            var addingTaskWindow = new TaskAddWindow(taskSample);
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
    }
}