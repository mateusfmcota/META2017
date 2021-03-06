﻿using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using MetaWPF.Sistema;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace MetaWPF.UI
{


    public partial class Graficos : Window
    {

        private Singleton sis = Singleton.Instance;
        private Func<long, string> DateTimeFormatter { get; set; }
        private List<String> sDt = new List<String>();

        private double tensao = 0;
        private double corrente = 0;
        private double potencia = 0;

        private double pMin = 99999999; //Potencia maxima
        private double pMedia; //potencia minima
        private int iMedia = 0; //contador para a media de potencia
        private double pTotal; //potencia total
        private double pMax; //potencia maxima


        private DispatcherTimer timerRT; //timer do grafico em tempo real
        private DispatcherTimer timerHist; //timer para o grafico de historico

        public Graficos()
        {
            InitializeComponent();

            graphRT(); //gera o grafico em tempo real
            graphHST(); //gera o grafico da historia

            timerSetup(); //configura os timers
        }

        private void timerSetup()
        {
            timerRT = new System.Windows.Threading.DispatcherTimer();
            timerRT.Tick += new EventHandler(timerRT_Tick);
            timerRT.Interval = new TimeSpan(0, 0, 0, 0, 500); //atualiza a cada 500ms

            timerHist = new System.Windows.Threading.DispatcherTimer();
            timerHist.Tick += new EventHandler(timerHist_Tick);
            timerHist.Interval = new TimeSpan(0, 0, 1); //atualiza a cada 1 segundo

            timerHist.Start();
            timerRT.Start();
        }

        private void timerHist_Tick(object sender, EventArgs e)
        {
            pMedia += getPotencia();
            iMedia++;

            if (iMedia == 3600) //coloca a media a cada 1 hora
            {
                pTotal += pMedia / iMedia;

                tbKWMedia.Text = Convert.ToString((pMedia / iMedia));
                pMedia = 0;
                iMedia = 0;
            }

            if (iMedia % 30 == 0) //altera o valor de maximo e minimo a cada 30 segundos
            {
                tbMaxVl.Text = Convert.ToString(pMax);
                tbMinVl.Text = Convert.ToString(pMin);
            }

            if (iMedia % 1 == 0) //adiciona um ponto no grafico da historia a cada 20 segundos
            {
                graphHistAdd((pMedia / iMedia));
            }

        }

        private void graphHistAdd(double valor)
        {
            //adiciona valores ao grafico
            graficoHistorico.Series[0].Values.Add(potencia);

            if (graficoHistorico.Series[0].Values.Count > 300) //impede de ter mais do que 300 pontos no grafico
                graficoHistorico.Series[0].Values.RemoveAt(0);
        }

        private void timerRT_Tick(object sender, EventArgs e)
        {
            //altera o valor do mostrador de tensao/corrente e potencia
            setGaugeTensao(getTensao());
            setGaugeCorrente(getCorrente());
            setGaugePotencia(getPotencia());
            //adiciona 1 ponto no grafico em tempo real
            graphRTAdd(potencia);
        }

        private void graphRTAdd(double potencia)
        {
            //adiciona 1 ponto no grafico em tempo real
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
                    LineSmoothness = 1,

                   
                }
            };
            graficoHistorico.AxisX.Add(new Axis
            {
                LabelFormatter = value => DateTime.Now.ToString("HH:mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(1).Ticks
                }
            });

        }

        private void pvm()
        {
            //codigo de teste para povoamento
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
                LabelFormatter = value => DateTime.Now.ToString("HH:mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(1).Ticks
                }
            });


        }

        public void setGaugeCorrente(double valor)//coloca o valor no mostrador de corrente
        {
            if (valor > gaugeCorrent.To)
                gaugeCorrent.To = valor;
            gaugeCorrent.Value = valor;
        }

        public void setGaugeTensao(double valor) //coloca o valor no mostrador de Tensao
        {
            if (valor > gaugeTensao.To)
                gaugeTensao.To = valor;
            gaugeTensao.Value = valor;
        }

        public void setGaugePotencia(double valor) //coloca o valor no mostrador de Potencia
        {
            if (valor > gaugePotencia.To)
                gaugePotencia.To = valor;
            gaugePotencia.Value = valor;
        }

        public double getTensao() //Puxa a tensão do singleton
        {
            tensao = Convert.ToDouble(sis.Receber(0));
            return tensao;
        }

        public double getCorrente() //Puxa a Corrente do singleton
        {
            corrente = Convert.ToDouble(sis.Receber(0))/1000;
            return corrente;
        }

        public double getPotencia() //Calcula a pontencia
        {
            potencia = corrente * tensao;
            if (potencia > pMax)
                pMax = potencia;
            else if (potencia < pMin)
                pMin = potencia;

            return potencia;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sis.close();
        }
    }
}
