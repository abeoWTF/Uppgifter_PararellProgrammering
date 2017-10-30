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

namespace Uppgifter_ParallellProgrammering_2
{

    //2 Skapa en ListBox och en Button.Button-elementet ska ha texten Start.När man klickar på den ska du starta en Task som lägger till 10 valfria strängar i ListBox, med en sekunds mellanrum.
    //3 Förbättra programmet med en Button med texten Stop.När man klickar på den ska din Task stanna. Använd en privat bool för att stoppa.
    //3b Byt ut boolen mot en CancellationToken och CancellationTokenSource.
    //4 Förbättra programmet så att det går att starta om din Task genom att klicka på Start efter att man har stoppat den.Men eftersom det inte går att starta om en avslutad task så får du skapa en ny task.
    //Start ska bara gå att klicka när din Task inte körs och Stop bara när Task körs.



    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts;
        private CancellationToken ct;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void RunProgram()
        {
            cts = new CancellationTokenSource();
            ct = cts.Token;

            Stop_btn.IsEnabled = true;
            Button_btn.IsEnabled = false;

            int number = 0;

            Task t1 = Task.Run(() =>
            {
                while (number < 10 && !ct.IsCancellationRequested)
                {
                    
                    Thread.Sleep(1000);
                    Dispatcher.Invoke(() =>
                    {
                        ListBox_lstbox.Items.Add("lol");
                        number++;
                    });
                }
            });
            
        }
       

        private void Button_btn_Click(object sender, RoutedEventArgs e)
        {
            
            RunProgram();
        }

        private void Stop_btn_Click(object sender, RoutedEventArgs e)
        {
            Stop_btn.IsEnabled = false;
            Button_btn.IsEnabled = true;
            cts?.Cancel();
        }
    }
}
