using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
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
using System.Windows.Threading;

namespace Talking_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            time.Content ="Today is " + DateTime.Now.ToString("dddd, MMMM dd, yyyy, hh:mm tt");
            startTimer();
        }
        
        
        private void startTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timerEvent;
            timer.Start();
        }

        private void timerEvent(object sender, EventArgs e)
        {
            time.Content = DateTime.Now.ToString("dddd, MMMM dd, yyyy, hh:mm tt");
        }


        private async void pontosido_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer mp = new SoundPlayer();
            
            List<string> files = new List<string>();
            files.Add($"HU/pontosido.wav"); //A pontos idő:
            files.Add($"HU/orak/{DateTime.Now.Hour}ora.wav"); //16 óra
            files.Add($"HU/Percek/{DateTime.Now.Minute}.mp3"); // 49
            files.Add($"HU/Percek/perc.mp3"); // perc
            files.Add($"HU/{DateTime.Now.Second}.wav"); //húsz
            files.Add($"HU/masodperc.wav"); //másodperc
            foreach (var file in files)
            {
                mp.SoundLocation = file;
                mp.LoadAsync();
                if (mp.IsLoadCompleted)
                {
                    await Task.Run(()=>mp.PlaySync());
                }
            }
            mp.Stop();
        }

        private async void hanyadika_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer mp = new SoundPlayer();

            List<string> files = new List<string>();
            files.Add($"HU/ma.wav"); //ma
            files.Add($"HU/{DateTime.Now.Year}.wav"); //2021
            files.Add($"HU/honap{DateTime.Now.Month}.wav"); //július
            files.Add($"HU/nap{DateTime.Now.Day}.wav"); //tizenharmadika,
            files.Add($"HU/napneve{DateTime.Now.DayOfWeek}.wav"); // kedd van
            foreach (var file in files)
            {
                mp.SoundLocation = file;
                mp.LoadAsync();
                if (mp.IsLoadCompleted)
                {
                    await Task.Run(() => mp.PlaySync());
                }
            }
            mp.Stop();
        }

        private async void datetoday_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer mp = new SoundPlayer();

            List<string> files = new List<string>();
            files.Add($"EN/todayis.wav"); //Today is
            files.Add($"EN/dayofweek{DateTime.Now.DayOfWeek}.wav"); //Monday,
            files.Add($"EN/month{DateTime.Now.Month}.wav"); //July
            files.Add($"EN/day{DateTime.Now.Day}.wav"); //twelfth,
            files.Add($"EN/{DateTime.Now.Year}.wav"); // twenty twenty-one
            foreach (var file in files)
            {
                mp.SoundLocation = file;
                mp.LoadAsync();
                if (mp.IsLoadCompleted)
                {
                    await Task.Run(() => mp.PlaySync());
                }
            }
            mp.Stop();
        }

        private async void timeis_click(object sender, RoutedEventArgs e)
        {
            SoundPlayer mp = new SoundPlayer();

            List<string> files = new List<string>();
            files.Add($"EN/rightnowits.wav"); //Right now it's:
            if (DateTime.Now.Hour == 0)
            {
                ($"EN/hours/{DateTime.Now.Hour}ora.wav");
            }
            if (DateTime.Now.Hour >12)
            {

            }
            files.Add($"EN/hours/{DateTime.Now.Hour}ora.wav"); //16
            files.Add($"EN/{DateTime.Now.Second}.wav"); //49
            files.Add($"EN/masodperc.wav"); //AM
            foreach (var file in files)
            {
                mp.SoundLocation = file;
                mp.LoadAsync();
                if (mp.IsLoadCompleted)
                {
                    await Task.Run(() => mp.PlaySync());
                }
            }
            mp.Stop();
        }
    }
}
