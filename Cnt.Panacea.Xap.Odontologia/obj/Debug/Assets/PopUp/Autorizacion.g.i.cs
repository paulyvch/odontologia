﻿#pragma checksum "C:\Cnt\Git\odontologia\Cnt.Panacea.Xap.Odontologia\Assets\PopUp\Autorizacion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5B45ABA84083B88BFA8B7922447AF9FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Cnt.Panacea.Xap.Odontologia.PopUp {
    
    
    public partial class Autorizacion : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox txtbxUser;
        
        internal System.Windows.Controls.PasswordBox txtbxPass;
        
        internal System.Windows.Controls.Button btnIngresar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Cnt.Panacea.Xap.Odontologia;component/Assets/PopUp/Autorizacion.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtbxUser = ((System.Windows.Controls.TextBox)(this.FindName("txtbxUser")));
            this.txtbxPass = ((System.Windows.Controls.PasswordBox)(this.FindName("txtbxPass")));
            this.btnIngresar = ((System.Windows.Controls.Button)(this.FindName("btnIngresar")));
        }
    }
}

