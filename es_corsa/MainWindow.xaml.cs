using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;

namespace es_corsa
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(muoviSqualo1));
            Thread t2 = new Thread(new ThreadStart(muoviSqualo2));
            Thread t3 = new Thread(new ThreadStart(muoviSqualo3));
            t1.Start();
            t2.Start(); t3.Start();
        }

       int posizionePartenza1 = 83;
        int posizionePartenza2 = 83;
        int posizionePartenza3 = 83;
        public void muoviSqualo1()
        {
            while (posizionePartenza1 < 500)
            {
                posizionePartenza1 += 5;

                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgShark1.Margin = new Thickness(posizionePartenza1, 10, 0, 0);
                }));
            }


        }

        public void muoviSqualo2()
        {
            while (posizionePartenza2 < 500)
            {
                posizionePartenza2 += 5;

                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgShark2.Margin = new Thickness(posizionePartenza2, 146, 0, 0);
                }));
            }


        }

        public void muoviSqualo3()
        {
            while (posizionePartenza3 < 500)
            {
                posizionePartenza3 += 5;

                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgShark3.Margin = new Thickness(posizionePartenza3, 287, 0, 0);
                }));
            }


        }
    }
}
