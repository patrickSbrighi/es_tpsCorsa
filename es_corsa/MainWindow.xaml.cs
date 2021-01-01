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
using System.Diagnostics;
using System.Data.Odbc;

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
        }

        int posizionePartenza1;
        int posizionePartenza2;
        int posizionePartenza3;
        List<Pair> tempi;
        Stopwatch cronometro1;
        Stopwatch cronometro2;
        Stopwatch cronometro3;
        public void muoviSqualo1()
        {
            posizionePartenza1 = 83;
            cronometro1 = new Stopwatch();
            cronometro1.Start();
            while (posizionePartenza1 < 600)
            {
                posizionePartenza1 += 10;

                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgShark1.Margin = new Thickness(posizionePartenza1, 10, 0, 0);
                }));
            }
            cronometro1.Stop();
            Stop(cronometro1.Elapsed, 1);
        }

        public void muoviSqualo2()
        {
            posizionePartenza2 = 83;
            cronometro2 = new Stopwatch();
            cronometro2.Start();
            while (posizionePartenza2 < 600)
            {
                posizionePartenza2 += 10;
               
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgShark2.Margin = new Thickness(posizionePartenza2, 146, 0, 0);
                }));
            }
            cronometro2.Stop();
            Stop(cronometro2.Elapsed, 2);
        }

        public void muoviSqualo3()
        {
            posizionePartenza3 = 83;
            cronometro3 = new Stopwatch();
            cronometro3.Start();
            while (posizionePartenza3 < 600)
            {
                posizionePartenza3 += 10;

                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgShark3.Margin = new Thickness(posizionePartenza3, 287, 0, 0);
                }));
            }
            cronometro3.Stop();
            Stop(cronometro3.Elapsed, 3);
        }

        private void Stop(TimeSpan tempo, int numero)
        {
            Pair p = new Pair(tempo, numero);
            tempi.Add(p);
        }

        private void btnVia_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(Inizio));
            t1.Start();
        }

        private void Inizio()
        {
            tempi = new List<Pair>();
            Thread t1 = new Thread(new ThreadStart(muoviSqualo1));
            Thread t2 = new Thread(new ThreadStart(muoviSqualo2));
            Thread t3 = new Thread(new ThreadStart(muoviSqualo3));
            t1.Start();
            t2.Start();
            t3.Start();

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                btnVia.Content = "Riparti";
                btnVia.IsEnabled = false;
            }));

            t1.Join();
            t2.Join();
            t3.Join();

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                btnVia.IsEnabled = true;
            }));

            OrdinamentoSuTempo();

            string output = "";
            for(int i = 0; i < tempi.Count; i++)
            {
                output += "Squalo numero " + tempi[i].Numero + " con un tempo di " + tempi[i].Tempo + "s\n";
            }

            MessageBox.Show(output);
            
        }

        private void OrdinamentoSuTempo()
        {
            List<TimeSpan> ordine = new List<TimeSpan>();
            foreach(Pair p in tempi)
            {
                ordine.Add(p.Tempo);
            }

            ordine.Sort();

            for(int i = 0; i < tempi.Count; i++)
            {
                if(tempi[i].Tempo != ordine[i])
                {
                    int numero;
                    int pos = 0;
                    for(int j = 0; j < tempi.Count; j++)
                    {
                        if (tempi[j].Tempo == ordine[i])
                        {
                            numero = tempi[j].Numero;
                            pos = j;
                        }
                    }

                    Pair aux;
                    aux = tempi[i];
                    tempi[i] = tempi[pos];
                    tempi[pos] = aux;
                }
            }
        }
    }
}
