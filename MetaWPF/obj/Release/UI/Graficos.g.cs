﻿#pragma checksum "..\..\..\UI\Graficos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E41202D59AC4F7E30A26D039469BAA04"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MetaWPF.UI {
    
    
    /// <summary>
    /// Graficos
    /// </summary>
    public partial class Graficos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart graficoHistorico;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMaxVl;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMinVl;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbC3;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbC4;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKWMedia;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart graficoTempoReal;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Gauge gaugeCorrent;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Gauge gaugePotencia;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\UI\Graficos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Gauge gaugeTensao;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MetaWPF;component/ui/graficos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\Graficos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\UI\Graficos.xaml"
            ((MetaWPF.UI.Graficos)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.graficoHistorico = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 3:
            this.tbMaxVl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbMinVl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbC3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbC4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbKWMedia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.graficoTempoReal = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 9:
            this.gaugeCorrent = ((LiveCharts.Wpf.Gauge)(target));
            return;
            case 10:
            this.gaugePotencia = ((LiveCharts.Wpf.Gauge)(target));
            return;
            case 11:
            this.gaugeTensao = ((LiveCharts.Wpf.Gauge)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

