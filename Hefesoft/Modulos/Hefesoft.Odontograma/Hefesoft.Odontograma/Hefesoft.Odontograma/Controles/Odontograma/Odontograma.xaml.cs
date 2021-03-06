﻿using Hefesoft.Odontograma.Util;
using Cnt.Panacea.Xap.Odontologia.Util.Messenger;
using Cnt.Panacea.Xap.Odontologia.Vm.Contexto;
using Cnt.Panacea.Xap.Odontologia.Vm.Estaticas;
using Cnt.Panacea.Xap.Odontologia.Vm.Messenger.Guardar;
using Cnt.Panacea.Xap.Odontologia.Vm.Messenger.Mensajes;
using Cnt.Panacea.Xap.Odontologia.Vm.Messenger.Odontograma.Tipo;
using Cnt.Panacea.Xap.Odontologia.Vm.Messenger.Paleta;
using GalaSoft.MvvmLight.Messaging;
using Hefesoft.Util.W8.UI.Common;
using Microsoft.Practices.ServiceLocation;
using Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Hefesoft.Util.W8.UI.Util;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=321224

namespace Hefesoft.Odontograma
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class Odontograma : Page, IDisposable
    {
        public Odontograma()
        {
            this.InitializeComponent();            
            oirMensaje();
            addBusy();
            oirCambiosBotones();
            oirMoverHubMapaDental();

            NavigationHelper = new Hefesoft.Util.W8.UI.Common.NavigationHelper();
            NavigationHelper.setPage(this);

            //Datos prueba
            Variables_Globales.IdIps = 21;
            Variables_Globales.IdPaciente = 232431;
            Variables_Globales.IdTratamientoActivo = 2;
            Variables_Globales.Modo = Cnt.Panacea.Xap.Odontologia.Vm.Util.Modos.Modo.windows8;
            Variables_Globales.PCL = new PCL();

            //var contexto = ServiceLocator.Current.GetInstance<IContexto_Odontologia>();
            //contexto.binding(new Inicializar_Servicio().CreateCustomBinding());
            //contexto.url("net.tcp://192.168.1.250:4520/Cnt.Panacea.Web.Host/Silverlight/Odontologia.OdontologiaServicio.svc");

            //EndpointAddress endpointAddress = new EndpointAddress("net.tcp://192.168.1.250:4520/Cnt.Panacea.Web.Host/Silverlight/Odontologia.OdontologiaServicio.svc");
            //var cliente = new OdontologiaServicioClient(new Inicializar_Servicio().CreateCustomBinding(), endpointAddress);

            ////El inspector hay que seguir trabajando en el para guardar los datos en table storage
            ////Dinamicamente
            ////cliente.Endpoint.EndpointBehaviors.Add(new MyBehavior());
            //contexto.servicio(cliente);

            // Metodo para pasarle los parametros al binding
            //Ya que windows 8 no tiene archivos client config de configuracion
            //contexto.inicializarContexto();

            #if DEBUG
            Hefesoft.Util.W8.UI.Util.RegisterElement.registrarClaseUI<Hefesoft.Util.W8.UI.PopUp.Modal>();
            var modal = ServiceLocator.Current.GetInstance<Hefesoft.Util.W8.UI.PopUp.Modal>();
            this.LayoutRoot.Children.Add(modal);
            #endif
        }

        
        public NavigationHelper NavigationHelper { get; set; }        

        private void oirMensaje()
        {
            Messenger.Default.Register<Mostrar_Mensaje_Usuario>(this, item =>
            {
                mostrarMensaje(item);
            });
        }

        private async void mostrarMensaje(Mostrar_Mensaje_Usuario item)
        {
            // Create the message dialog and set its content
            var msg = new Windows.UI.Popups.MessageDialog(item.Mensaje);
            // Show the message dialog and wait
            await msg.ShowAsync();
        }

        private void oirCambiosBotones()
        {
            // Activa o desactiva botones deacuerdo al estado de la pagina
            Messenger.Default.Register<Cnt.Panacea.Xap.Odontologia.Vm.Messenger.Guardar.Activar_Elementos>(this, elemento =>
            {
                if (elemento.valor == "Nuevo")
                {
                    nuevoTratamientoUI();
                    finalizaTratamientoBtn.Visibility = Visibility.Collapsed;
                }
                else if (elemento.valor == "Plan Tratamiento")
                {
                    planTratamientoUI();
                    finalizaTratamientoBtn.Visibility = Visibility.Collapsed;
                }
                else if (elemento.valor == "Evolucion")
                {
                    evolucionUI();
                    finalizaTratamientoBtn.Visibility = Visibility.Visible;
                }
                else if (elemento.valor == "Todos")
                {
                    finalizaTratamientoBtn.Visibility = Visibility.Collapsed;
                    activarTodosUI();
                }
            });
        }        

        private void nuevoTratamientoUI()
        {
            Variables_Globales.IdTratamientoActivo = 0;
            odontogramaEvolucionBtn.IsEnabled = false;
            odontogramaPlanTratamientoBtn.IsEnabled = false;            
        }

        private void planTratamientoUI()
        {
            odontogramaPlanTratamientoBtn.IsEnabled = true;
            odontogramaEvolucionBtn.IsEnabled = false;
        }

        private void evolucionUI()
        {
            odontogramaPlanTratamientoBtn.IsEnabled = true;
            odontogramaEvolucionBtn.IsEnabled = true;
        }

        private void activarTodosUI()
        {
            odontogramaPlanTratamientoBtn.IsEnabled = true;
            odontogramaEvolucionBtn.IsEnabled = true;
        }

        public void addBusy()
        {
            var busy = ServiceLocator.Current.GetInstance<Hefesoft.Standard.BusyBox.Busy>();
            var elemento = Hefesoft.Util.W8.UI.Assets.BusyBox.Busy.addBusy(busy);
            Grid.SetRowSpan(elemento, 2);
            LayoutRoot.Children.Add(elemento);
        }

        public void Dispose()
        {
            Messenger.Default.Unregister<Mostrar_Mensaje_Usuario>(this);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Unregister<Mostrar_Cargando>(this);
            Messenger.Default.Unregister<Cnt.Panacea.Xap.Odontologia.Vm.Messenger.Guardar.Activar_Elementos>(this);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Unregister<Hefesoft.Usuario.Messenger.Usuario_Cargado>(this);
        }
        bool desHacerBool;        
    }
}
