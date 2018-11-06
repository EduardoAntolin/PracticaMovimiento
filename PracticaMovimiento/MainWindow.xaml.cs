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
//Nuevas librerias papá
using System.Threading;
using System.Diagnostics;

namespace PracticaMovimiento
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch;
        TimeSpan tiempoAnterior;

        
        

        public MainWindow()
        {
            InitializeComponent();
            miCanvas.Focus();

            stopwatch = new Stopwatch();
            stopwatch.Start();
            tiempoAnterior = stopwatch.Elapsed;



            //1.-Establecer instrucciones 
            ThreadStart threadStart = new ThreadStart(moverEnemigos);
            //2.- Inicializar el thread
            Thread threadMoverEnemigos = new Thread(threadStart);
            //3.- Ejecutar el thread
            threadMoverEnemigos.Start();
        }

        void moverEnemigos()
        {
            while (true)
            { 
                Dispatcher.Invoke(
                ()=>
                {
                    var tiempoActual = stopwatch.Elapsed;
                    var deltaTime = tiempoActual - tiempoAnterior;
                    
                        double leftCarroActual = Canvas.GetLeft(ImgCarro);
                        Canvas.SetLeft(ImgCarro, leftCarroActual - 1);
                    if(Canvas.GetLeft(ImgCarro) <= -100)
                    {
                        Canvas.SetLeft(ImgCarro, 800);
                    }
                    
                }
                );
            }

        }
       


        private void miCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up)
            {
                double topNemoActual = Canvas.GetTop(imgNemo);
                Canvas.SetTop(imgNemo, topNemoActual - 15);
            }

            if(e.Key == Key.Down)
            {
                double topNemoActual = Canvas.GetTop(imgNemo);
                Canvas.SetBottom(imgNemo, topNemoActual - 15);
            }

            if (e.Key == Key.Right)
            {
                double topNemoActual = Canvas.GetTop(imgNemo);
                Canvas.SetRight(imgNemo, topNemoActual - 15);
            }

            if (e.Key == Key.Left)
            {
                double topNemoActual = Canvas.GetTop(imgNemo);
                Canvas.SetLeft(imgNemo, topNemoActual - 15);
            }
        }
    }
}
