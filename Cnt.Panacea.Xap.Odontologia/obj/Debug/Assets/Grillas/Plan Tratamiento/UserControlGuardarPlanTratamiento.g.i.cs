﻿#pragma checksum "D:\Cnt\odontologia\Cnt.Panacea.Xap.Odontologia\Assets\Grillas\Plan Tratamiento\UserControlGuardarPlanTratamiento.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B795C18D01CDEEE6504990D492708A7F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Cnt.Panacea.Xap.Odontologia;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Cnt.Panacea.Xap.Odontologia {
    
    
    public partial class UserControlGuardarPlanTratamiento : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard StoryboardComprobantes;
        
        internal System.Windows.Media.Animation.Storyboard StoryboardComprobantesCerrar;
        
        internal System.Windows.Media.Animation.Storyboard StoryboardProcedimientosCerrar;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid grid2;
        
        internal System.Windows.Controls.TextBox txtCuotaInicial;
        
        internal System.Windows.Controls.TextBlock txtSesiones;
        
        internal System.Windows.Controls.TextBox TxtValorCuota;
        
        internal System.Windows.Controls.TextBox txtbxValorTotal;
        
        internal System.Windows.Controls.CheckBox checkBox;
        
        internal System.Windows.Controls.HyperlinkButton HyprlnkBttnValores;
        
        internal Cnt.Panacea.Xap.Odontologia.UserControlGridPlanTratamientoProcedimientosWizard wizard;
        
        internal System.Windows.Controls.HyperlinkButton HyprlnkBttnSiguiente;
        
        internal System.Windows.Controls.HyperlinkButton HyprlnkBttnAnterior;
        
        internal System.Windows.Controls.Grid GridComprobantes;
        
        internal System.Windows.Controls.Border BorderComprobantes;
        
        internal System.Windows.Controls.StackPanel stackPanel1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Cnt.Panacea.Xap.Odontologia;component/Assets/Grillas/Plan%20Tratamiento/UserCont" +
                        "rolGuardarPlanTratamiento.xaml", System.UriKind.Relative));
            this.StoryboardComprobantes = ((System.Windows.Media.Animation.Storyboard)(this.FindName("StoryboardComprobantes")));
            this.StoryboardComprobantesCerrar = ((System.Windows.Media.Animation.Storyboard)(this.FindName("StoryboardComprobantesCerrar")));
            this.StoryboardProcedimientosCerrar = ((System.Windows.Media.Animation.Storyboard)(this.FindName("StoryboardProcedimientosCerrar")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.grid2 = ((System.Windows.Controls.Grid)(this.FindName("grid2")));
            this.txtCuotaInicial = ((System.Windows.Controls.TextBox)(this.FindName("txtCuotaInicial")));
            this.txtSesiones = ((System.Windows.Controls.TextBlock)(this.FindName("txtSesiones")));
            this.TxtValorCuota = ((System.Windows.Controls.TextBox)(this.FindName("TxtValorCuota")));
            this.txtbxValorTotal = ((System.Windows.Controls.TextBox)(this.FindName("txtbxValorTotal")));
            this.checkBox = ((System.Windows.Controls.CheckBox)(this.FindName("checkBox")));
            this.HyprlnkBttnValores = ((System.Windows.Controls.HyperlinkButton)(this.FindName("HyprlnkBttnValores")));
            this.wizard = ((Cnt.Panacea.Xap.Odontologia.UserControlGridPlanTratamientoProcedimientosWizard)(this.FindName("wizard")));
            this.HyprlnkBttnSiguiente = ((System.Windows.Controls.HyperlinkButton)(this.FindName("HyprlnkBttnSiguiente")));
            this.HyprlnkBttnAnterior = ((System.Windows.Controls.HyperlinkButton)(this.FindName("HyprlnkBttnAnterior")));
            this.GridComprobantes = ((System.Windows.Controls.Grid)(this.FindName("GridComprobantes")));
            this.BorderComprobantes = ((System.Windows.Controls.Border)(this.FindName("BorderComprobantes")));
            this.stackPanel1 = ((System.Windows.Controls.StackPanel)(this.FindName("stackPanel1")));
        }
    }
}

