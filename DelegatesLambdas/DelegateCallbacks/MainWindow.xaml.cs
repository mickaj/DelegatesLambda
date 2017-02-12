using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace DelegateCallbacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void runProcess_Click(object sender, RoutedEventArgs e)
        {
            int itr;
            if(!int.TryParse(iterationsQTY.Text, out itr))
            {
                MessageBox.Show("Cannot convert input itereation number to integer!", "Upsss...");
            }
            else
            {
                runProcess.IsEnabled = false;
                iterationsQTY.IsEnabled = false;
                runProcess.IsEnabled = false;
                progress.Maximum = itr;
                progress.IsEnabled = true;
                progress.Value = 0;
                //creating new instance of Calculation class
                Calculation thisCalc = new Calculation(itr);
                //creating new task for the Process method to keep the UI responsive
                Task processTask = new Task(() => thisCalc.Process(UpdateUI));
                processTask.Start();
                // continueTask specifies what happens when processTask is completed
                Task continueTask = processTask.ContinueWith((a) =>
                {
                    MessageBox.Show("Process compeleted after " + itr + " iterations.", "Process finished");
                });
            }
        }

        //call back method that gets current iteration in Process method and updates the UI
        public void UpdateUI(int i)
        {
            //updating the UI is achieved through dispatcher to allow processTask to update values in root thread
            this.Dispatcher.Invoke(() =>
            {
                iterationNo.Text = i.ToString();
                progress.Value = i;
                if(i == int.Parse(iterationsQTY.Text))
                {
                    iterationsQTY.IsEnabled = true;
                    runProcess.IsEnabled = true;
                    progress.IsEnabled = false;
                    runProcess.IsEnabled = true;
                }
            });
        }
    }
}
