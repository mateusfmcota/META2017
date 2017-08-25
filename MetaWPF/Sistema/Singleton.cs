using MetaWPF.UI;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaWPF.Sistema
{
    public class Singleton
    {
        private List<String> Historico = new List<string>();
        private int Dados;
        private int[] DadosSelecionados;

        private System.IO.Ports.SerialPort serialPort = new SerialPort();

        private List<String> Ports { get; set; } = new List<string>();

        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }

        }

        private void AtualizaListaCom()
        {
            int i = 0;
            bool qtd = false;


            if (Ports.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (Ports.Contains(s) == false)
                    {
                        qtd = true;
                    }
                }
            }
            else
            {
                qtd = true;
            }

            //Se não foi detectado diferença
            if (qtd == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            Ports.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                Ports.Add(s);
            }

        }

        public void close()
        {
            if (serialPort.IsOpen == true)
                serialPort.Close();
        }

        public List<String> retornaPortas()
        {
            AtualizaListaCom();
            return Ports;
        }

        internal void iniciarSoftware()
        {
            Graficos g = new Graficos();
            g.Show();
            
        }

        
        public Boolean Conectar(String COMName)
        {
            int port = Ports.IndexOf(COMName);
            if (serialPort.IsOpen == false)
            {
                try
                {
                    serialPort.PortName = Ports[port].ToString();
                    serialPort.Open();
                    return true;

                }
                catch
                {
                    return false;
                }

                if (serialPort.IsOpen)
                {
                    return true;
                }

            }
            else
            {

                try
                {
                    serialPort.Close();
                    return false;
                }
                catch
                {
                    return true;
                }

            } //Reescrever de acordo com a documentação https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.aspx
        }

        internal void gerarGrafico(int i)
        {
            //Grafico g = new Grafico(i);
            //g.Show();
        }

        public void Enviar(String s)
        {
            if (serialPort.IsOpen == true)          //porta está aberta
                serialPort.Write(s);  //envia o texto presente no textbox Enviar
        }

        public String Receber(int i)
        {
            if (i == -1)
                return serialPort.ReadLine();

            if (Historico.Count > 300)
                Historico.RemoveAt(0);

            Historico.Add(serialPort.ReadLine());

            String dt = serialPort.ReadLine();
            String[] dts = dt.Split('/');
            return dts[i];
        }

        public int getNumDados()
        {

            String dt = serialPort.ReadLine();
            String[] dts = dt.Split('/');
            return dts.Length;
        }

        public List<String> receberHist()
        {
            return Historico;
        }
    }
}

