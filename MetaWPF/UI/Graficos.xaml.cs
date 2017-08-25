using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using MetaWPF.Sistema;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace MetaWPF.UI
{
    /// <summary>
    /// Lógica interna para Graficos.xaml
    /// </summary>
    public partial class Graficos : Window
    {
        private Singleton sis = Singleton.Instance;
        private List<double> dados = new List<double>();
        private List<String> sDt = new List<String>();

        private double tensao = 0;
        private double corrente = 0;
        private double potencia = 0;

        private double pMin = 99999999;
        private double pMedia;
        private int iMedia = 0;
        private double pTotal;
        private double pMax;


        private DispatcherTimer timerRT;
        private DispatcherTimer timerHist;

        public Graficos()
        {
            InitializeComponent();
            InitializeComponent();

            graphRT();
            graphHST();

            timerSetup();
        }

        private void timerSetup()
        {
            timerRT = new System.Windows.Threading.DispatcherTimer();
            timerRT.Tick += new EventHandler(timerRT_Tick);
            timerRT.Interval = new TimeSpan(0, 0, 0, 0, 500);

            timerHist = new System.Windows.Threading.DispatcherTimer();
            timerHist.Tick += new EventHandler(timerHist_Tick);
            timerHist.Interval = new TimeSpan(0, 0, 1);

            timerHist.Start();
            timerRT.Start();
        }

        private void timerHist_Tick(object sender, EventArgs e)
        {
            pMedia += getPotencia();
            iMedia++;

            if (iMedia == 3600)
            {
                pTotal += pMedia / iMedia;

                tbKWMedia.Text = Convert.ToString((pMedia / iMedia));
                pMedia = 0;
                iMedia = 0;
            }

            if (iMedia % 30 == 0)
            {
                tbMaxVl.Text = Convert.ToString(pMax);
                tbMinVl.Text = Convert.ToString(pMin);
            }

            if (iMedia % 20 == 0)
            {
                graphHistAdd((pMedia / iMedia));
            }


        }

        private void graphHistAdd(double valor)
        {
            graficoHistorico.Series[0].Values.Add(potencia);

            if (graficoHistorico.Series[0].Values.Count > 300)
                graficoHistorico.Series[0].Values.RemoveAt(0);
        }

        private void timerRT_Tick(object sender, EventArgs e)
        {
            setGaugeTensao(getTensao());
            setGaugeCorrente(getCorrente());
            setGaugePotencia(getPotencia());

            graphRTAdd(potencia);
        }

        private void graphRTAdd(double potencia)
        {
            graficoTempoReal.Series[0].Values.Add(potencia);

            if (graficoTempoReal.Series[0].Values.Count > 150)
                graficoTempoReal.Series[0].Values.RemoveAt(0);
        }

        private void graphHST()
        {
            graficoHistorico.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { },
                    PointGeometrySize = 4,
                    StrokeThickness = 4,
                    LineSmoothness = 1
                }
            };
            graficoHistorico.AxisX.Add(new Axis
            {
                LabelFormatter = value => DateTime.Now.ToString("HH:mm:ss")
            });
        }

        private void pvm()
        {
            graficoTempoReal.Series[0].Values.Add(11.0);
            graficoTempoReal.Series[0].Values.Add(13.0);
            graficoTempoReal.Series[0].Values.Add(14.0);
            graficoTempoReal.Series[0].Values.Add(5.0);
            graficoTempoReal.Series[0].Values.Add(16.0);
            graficoTempoReal.Series[0].Values.Add(7.0);
        }

        private void graphRT()
        {


            graficoTempoReal.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { },
                    PointGeometrySize = 4,
                    LineSmoothness = 1,
                    StrokeThickness = 4
                }
            };
            graficoTempoReal.AxisX.Add(new Axis
            {
                LabelFormatter = value => DateTime.Now.ToString("HH:mm:ss")
            });

        }

        public void setGaugeCorrente(double valor)
        {
            if (valor > gaugeCorrent.To)
                gaugeCorrent.To = valor;
            gaugeCorrent.Value = valor;
        }

        public void setGaugeTensao(double valor)
        {
            if (valor > gaugeTensao.To)
                gaugeTensao.To = valor;
            gaugeTensao.Value = valor;
        }

        public void setGaugePotencia(double valor)
        {
            if (valor > gaugePotencia.To)
                gaugePotencia.To = valor;
            gaugePotencia.Value = valor;
        }

        public double getTensao()
        {
            tensao = Convert.ToDouble(sis.Receber(0));
            return tensao;
        }

        public double getCorrente()
        {
            corrente = Convert.ToDouble(sis.Receber(0))/1000;
            return corrente;
        }

        public double getPotencia()
        {
            potencia = corrente * tensao;
            if (potencia > pMax)
                pMax = potencia;
            else if (potencia < pMin)
                pMin = potencia;

            return potencia;
        }

    }
}
