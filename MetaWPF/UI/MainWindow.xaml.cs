using MetaWPF.Sistema;
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
using System.Windows.Shapes;

namespace MetaWPF.UI
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Singleton sis = Singleton.Instance;
        List<CheckBox> cbList = new List<CheckBox>();

        public MainWindow()
        {
            InitializeComponent();

            timer1();
        }

        private void timer1()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<String> ports = sis.retornaPortas();

            if (cbPorts.Items.Count != ports.Count)
            {
                cbPorts.Items.Clear();
                foreach (String port in ports)
                {
                    cbPorts.Items.Add(port);
                }
                cbPorts.SelectedIndex = 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btConectar.Content = "Desconectar";
            sis.Conectar(cbPorts.Text);
        }

        private void gerarCampos()
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sis.close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sis.iniciarSoftware();
        }
    }
}

