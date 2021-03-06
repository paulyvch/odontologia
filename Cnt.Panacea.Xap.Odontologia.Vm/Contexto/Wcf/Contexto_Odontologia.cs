﻿using Cnt.Panacea.Entities.Odontologia;
using Cnt.Panacea.Entities.Parametrizacion;
using Cnt.Panacea.Xap.Odontologia.Vm.Contexto;
using Proxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

//Clase que maneja las llamadas al servicio

namespace Cnt.Panacea.Xap.Odontologia.Vm.Contexto.Wcf
{
    public class Contexto_Odontologia : IContexto_Odontologia
    {
        public bool guardado_En_Proceso = false;

        private OdontologiaServicioClient cliente;
        private dynamic _binding;        
        private string _url;
        

        public dynamic servicio(dynamic clienteProxy)
        {
            cliente = clienteProxy;
            return cliente;
        }
 

        public void binding(dynamic valor)
        {
            dynamic varBinding = valor;
            _binding = valor;            
        }

        public void url(string url)
        {
            _url = url;
        }

        public void inicializarContexto()
        {           

            if (_binding != null)
            {
                
            }
            else
            {
                cliente = new OdontologiaServicioClient();
            }

            
        }
        public Task<bool> ActualizarPlanesTratamiento(TratamientoEntity Tratamiento, PlanesTratamientoCollection Planes)
        {
            foreach (PlanTratamientoEntity pivot in Planes)
            {
                if (pivot.Articulos != null)
                {
                    for (int i = 0; i <= pivot.Articulos.Count - 1; i++)
                    {
                        pivot.Articulos[i].Identificador = i;
                    }
                }
            }

            inicializarContexto();
            var tcs = new TaskCompletionSource<bool>();
            cliente.ActualizarPlanesTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };
            cliente.ActualizarPlanesTratamientoAsync(Tratamiento, Planes.ToObservableCollection());

            return tcs.Task;
        }

        public Task<bool> Actualizartratamiento(TratamientoEntity Tratamiento)
        {

            var tcs = new TaskCompletionSource<bool>();

            cliente.ActualizarTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };
            cliente.ActualizarTratamientoAsync(Tratamiento);

            return tcs.Task;
        }

        public Task<ConvenioEntity> consultarConvenio(short id)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ConvenioEntity>();

            var client = cliente;

            client.ConsultarConvenioAtencionCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };

            client.ConsultarConvenioAtencionAsync(id);

            return tcs.Task;
        }


        /// <summary>
        /// Lista los tratamientos activos d eun paciente
        /// </summary>
        public Task<ObservableCollection<TratamientoEntity>> ConsultarTratamientosPaciente(short idIps, int idPaciente)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<TratamientoEntity>>();

            var client = cliente;

            client.ListarPacienteCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };

            client.ListarPacienteAsync(idIps, idPaciente);

            return tcs.Task;

        }

        //public  Task<ObservableCollection<ConfiguracionDiagnosticoOdontologiaEntity>> ConsultarDiagnosticosConfigurados(short idIps)
        //{

        //    var tcs = new TaskCompletionSource<ObservableCollection<ConfiguracionDiagnosticoOdontologiaEntity>>();

        //    cliente.ConsultarDiagnosticosCondiguradoCompleted += (s, e) =>
        //    {
        //        if (e.Error != null)
        //            tcs.TrySetException(e.Error);
        //        else if (e.Cancelled)
        //            tcs.TrySetCanceled();
        //        else
        //            tcs.TrySetResult(e.Result);
        //    };
        //    cliente.ConsultarDiagnosticosCondiguradoAsync(idIps);

        //    return tcs.Task;
        //}

        public Task<ObservableCollection<ConfiguracionProcedimientoOdontologiaDto>> ConsultarProcedimientosOdontologiaLigero(short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ConfiguracionProcedimientoOdontologiaDto>>();
            cliente.ConsultarProcedimientosOdontologiaLigeroCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarProcedimientosOdontologiaLigeroAsync(idIps);

            return tcs.Task;
        }

        public Task<ObservableCollection<TipoTratamientoEntity>> ConsultarTiposTratamiento(short IdIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<TipoTratamientoEntity>>();

            cliente.consultarTiposTratamientosActivosCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.consultarTiposTratamientosActivosAsync(IdIps);

            return tcs.Task;
        }

        public Task<ObservableCollection<RelaDiagnosticoProcedEntity>> ConsultarProcedimientosPorDiagnostico(short idIps, String Diagnosticos)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<RelaDiagnosticoProcedEntity>>();

            cliente.ConsultarProcedimientosPorDiagnosticoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };

            cliente.ConsultarProcedimientosPorDiagnosticoAsync(idIps, Diagnosticos);

            return tcs.Task;
        }

        public Task<ObservableCollection<ProcedimientoEspecialidadSedeEntity>> ConsultarEspecialidadesPorProcedimiento(short idSede, string Procedimientos)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ProcedimientoEspecialidadSedeEntity>>();

            cliente.ListarEspecialidadesPorProcedimientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarEspecialidadesPorProcedimientoAsync(idSede, Procedimientos);

            return tcs.Task;
        }

        public Task<TratamientoImagenEntity> ConsultarImagenTratamiento(int idImagenTratamiento)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<TratamientoImagenEntity>();

            cliente.ConsultarImagenTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarImagenTratamientoAsync(idImagenTratamiento);

            return tcs.Task;
        }

        public Task<ObservableCollection<NivelSeveridadDXEntity>> ConsultarNivelSeveridad()
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<NivelSeveridadDXEntity>>();
            cliente.ConsultaNivelesSeveridadCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultaNivelesSeveridadAsync(String.Empty);
            return tcs.Task;
        }

        public Task<ObservableCollection<OdontogramaEntity>> ConsultarOdontogramaPaciente(Int64 idOdontogramaPaciente, short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<OdontogramaEntity>>();

            cliente.ListarOdontogramaPacienteCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarOdontogramaPacienteAsync(idOdontogramaPaciente, idIps);

            return tcs.Task;
        }

        public Task<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>> ConsultarOtrasCaracteristicasConfig(short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>>();
            cliente.ConsultarOtrasCaracteristicasConfigCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarOtrasCaracteristicasConfigAsync(idIps);

            return tcs.Task;
        }

        public Task<TerceroEntity> ConsultarPrestador(int IdPrestador)//LFDO Bug 16006
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<TerceroEntity>();
            cliente.ConsultarPrestadorAtencionCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarPrestadorAtencionAsync(IdPrestador);

            return tcs.Task;
        }

        //public  Task<ObservableCollection<ConfiguracionProcedimientoOdontologiaEntity>> ConsultarProcedimientosConfigurados(short idIps)
        //{

        //    var tcs = new TaskCompletionSource<ObservableCollection<ConfiguracionProcedimientoOdontologiaEntity>>();

        //    cliente.ConsultarProcedimientosCondiguradosCompleted += (s, e) =>
        //    {
        //        if (e.Error != null)
        //        {
        //            tcs.TrySetException(e.Error);
        //        }
        //        else if (e.Cancelled)
        //        {
        //            tcs.TrySetCanceled();
        //        }
        //        else
        //        {
        //            tcs.TrySetResult(e.Result);
        //        }
        //    };
        //    cliente.ConsultarProcedimientosCondiguradosAsync(idIps);

        //    return tcs.Task;
        //}

        //public  Task<ObservableCollection<ConfiguracionProcedimientoOdontologiaEntity>> ConsultarProcedimientosConvenio()
        //{
        //    
        //    var tcs = new TaskCompletionSource<ObservableCollection<ConfiguracionProcedimientoOdontologiaEntity>>();

        //    cliente.ConsultarProcedimientosConvenioCompleted += (s, e) =>
        //    {
        //        if (e.Error != null)
        //        {
        //            tcs.TrySetException(e.Error);
        //        }
        //        else if (e.Cancelled)
        //        {
        //            tcs.TrySetCanceled();
        //        }
        //        else
        //        {
        //            tcs.TrySetResult(e.Result);
        //        }
        //    };
        //    cliente.ConsultarProcedimientosConvenioAsync(Variables_Globales.IdPaciente, Variables_Globales.IdConvenio, Variables_Globales.IdIps);

        //    return tcs.Task;
        //}

        public Task<ObservableCollection<SesionesPlanTratamientoEntity>> ConsultarSesionesTratamiento(long IdTratamiento)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<SesionesPlanTratamientoEntity>>();

            cliente.ConsultarSesionesTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarSesionesTratamientoAsync(IdTratamiento);
            return tcs.Task;
        }

        public Task<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>> ConsultarProcedimientosConvenio(int idPaciente, short idConvenio, short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>>();

            cliente.ConsultarProcedimientosConvenioCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarProcedimientosConvenioAsync(idPaciente, idConvenio, idIps);
            return tcs.Task;
        }



        public Task<ObservableCollection<PlanTratamientoEntity>> ConsultarValoresProcedimiento(short IdIps, int idPaciente, PlanesTratamientoCollection Planes, bool gestante, short IdConvenio, short idEspecialidad)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<PlanTratamientoEntity>>();

            cliente.ConsultarValoresProcedimientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarValoresProcedimientoAsync(IdIps, idPaciente, gestante, idEspecialidad, IdConvenio, Planes.ToObservableCollection());

            return tcs.Task;
        }


        public Task<long> GuardarOdontogramaInicial(TratamientoEntity tratamiento, OdontogramasPacienteEntity odontogramaPaciente, List<OdontogramaEntity> odontograma, List<TratamientoImagenEntity> adjuntosImagen, short idIps)
        {
            guardado_En_Proceso = true;
            foreach (OdontogramaEntity pivot in odontograma)
            {
                if (pivot.DienteReferencia1 != null)
                {

                    if (pivot.DienteReferencia1.Identificador == 0)
                    {
                        pivot.DienteReferencia1 = null;
                    }
                }
                if (pivot.DienteReferencia2 != null)
                {

                    if (pivot.DienteReferencia2.Identificador == 0)
                    {
                        pivot.DienteReferencia2 = null;
                    }
                }
                if (pivot.Diagnostico != null)
                {
                    //if (pivot.Diagnostico.Identificador == 0)
                    //{
                    //    pivot.Diagnostico = null;
                    //}
                }

                if (pivot.Procedimiento != null)
                {
                    //if (pivot.Procedimiento.Identificador == 0)
                    //{
                    //    pivot.Procedimiento = null;
                    //}
                }
            }
            odontogramaPaciente.IdIps = idIps;

            inicializarContexto();
            var tcs = new TaskCompletionSource<long>();

            //Se guarda una referencia al evento
            //Para que no se dispara multiples veces
            //Luego le hacemos unsuscribe
            EventHandler<guardarOdontogramaInicialCompletedEventArgs> evento = null;
            evento = delegate(object sender, guardarOdontogramaInicialCompletedEventArgs e)
            {
                cliente.guardarOdontogramaInicialCompleted -= evento;
                guardado_En_Proceso = false;
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };

            cliente.guardarOdontogramaInicialCompleted += evento;


            if (tratamiento.AtencionInicial == null || tratamiento.AtencionInicial == 0)
            {
                tratamiento.AtencionInicial = -1;
            }
            cliente.guardarOdontogramaInicialAsync(tratamiento, odontogramaPaciente, odontograma.ToObservableCollection(), adjuntosImagen.ToObservableCollection());

            return tcs.Task;
        }

        public Task<ObservableCollection<long>> GuardarPlanTratamiento(TratamientoEntity TratamientoEntity,
            short idTipoTratamiento,
            OdontogramasPacienteEntity OdontogramasPacienteEntity,
            ObservableCollection<OdontogramaEntity> odontogramaTratamiento,
            bool Cotizacion,
            PacienteEntity Paciente,
            ComprobanteEntity Comprobante,
            short idIps,
            string usuario,
            short idSede,
            short idConvenio
            )
        {

            foreach (OdontogramaEntity pivot in odontogramaTratamiento)
            {
                if (pivot.DienteReferencia1 != null)
                {
                    if (pivot.DienteReferencia1.Identificador == 0)
                    {
                        pivot.DienteReferencia1 = null;
                    }
                }

                if (pivot.DienteReferencia2 != null)
                {

                    if (pivot.DienteReferencia2.Identificador == 0)
                    {
                        pivot.DienteReferencia2 = null;
                    }
                }

                if (pivot.PlanTratamiento.PrestadorOdontologo == 0)
                {
                    pivot.PlanTratamiento.PrestadorOdontologo = null;

                }
                if (pivot.PlanTratamiento.PrestadorHigienista == 0)
                {
                    pivot.PlanTratamiento.PrestadorHigienista = null;

                }
                if (pivot.PlanTratamiento.FinalidadProcedimiento == 0)
                {
                    pivot.PlanTratamiento.FinalidadProcedimiento = null;

                }


            }
            OdontogramasPacienteEntity.IdIps = idIps;
            OdontogramasPacienteEntity.Usuario = usuario;


            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<long>>();

            EventHandler<GuardarPlanDeTratamientoCompletedEventArgs> evento = null;
            evento = delegate(object sender, GuardarPlanDeTratamientoCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
                cliente.GuardarPlanDeTratamientoCompleted -= evento;
            };

            cliente.GuardarPlanDeTratamientoCompleted += evento;

            cliente.GuardarPlanDeTratamientoAsync(TratamientoEntity,
                OdontogramasPacienteEntity,
                odontogramaTratamiento, Cotizacion, Paciente, idSede, idIps, idConvenio, Comprobante, usuario);

            return tcs.Task;
        }



        public Task<bool> GuardarImagenTratamiento(long idTratamientoPaciente, ObservableCollection<TratamientoImagenEntity> adjuntoImagenes)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<bool>();

            for (int i = 0; i <= adjuntoImagenes.Count - 1; i++)
            {
                adjuntoImagenes[i].Identificador = i;
            }

            cliente.guardarImagenesTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.guardarImagenesTratamientoAsync(idTratamientoPaciente, adjuntoImagenes);
            return tcs.Task;
        }

        public Task<ObservableCollection<ComprobanteEntity>> ListarComprobantes(short idIps, string usuario, short idSede)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ComprobanteEntity>>();

            cliente.ListarComprobantesCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarComprobantesAsync(idIps, usuario, idSede);

            return tcs.Task;
        }

        public Task<ObservableCollection<OdontogramaEntity>> ListarHistorial(long idTratamiento, short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<OdontogramaEntity>>();

            cliente.ListarHistorialOdontogramaCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };

            cliente.ListarHistorialOdontogramaAsync(idTratamiento, idIps);
            return tcs.Task;
        }

        public Task<ObservableCollection<TerceroEntity>> ListarHigienistasPorIps(short IdIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<TerceroEntity>>();

            cliente.ListarHigienistasIpsCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }

            };
            cliente.ListarHigienistasIpsAsync(IdIps);
            return tcs.Task;
        }

        public Task<ObservableCollection<TerceroEntity>> ListarOdontologosPorIps(short IdIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<TerceroEntity>>();

            cliente.ListarOdontologosIpsCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarOdontologosIpsAsync(IdIps);

            return tcs.Task;
        }

        public Task<ObservableCollection<OdontogramaEntity>> ListarOdontogramaTratamiento(Int64 idOdontogramaPaciente, short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<OdontogramaEntity>>();

            cliente.ListarOdontogramaTratamientoPacienteCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarOdontogramaTratamientoPacienteAsync(idOdontogramaPaciente, idIps);

            return tcs.Task;
        }

        public Task<ObservableCollection<OdontogramasPacienteEntity>> ListarOdontogramasSinTratamiento(int IdPaciente, short IdIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<OdontogramasPacienteEntity>>();

            cliente.ListarOdontogramasSinTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarOdontogramasSinTratamientoAsync(IdPaciente, IdIps);

            return tcs.Task;
        }


        public Task<ObservableCollection<FinalidadProcedimientoEntity>> ListarFinalidadesProcedimiento(short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<FinalidadProcedimientoEntity>>();

            cliente.ListarFinalidadProcedimientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };

            cliente.ListarFinalidadProcedimientoAsync(idIps);
            return tcs.Task;
        }

        public Task<ObservableCollection<PacienteConvenioEntity>> ListarConveniosPaciente(short idIps, int idPaciente)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<PacienteConvenioEntity>>();

            cliente.ListarConveniosPacienteCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarConveniosPacienteAsync(idIps, idPaciente);

            return tcs.Task;
        }


        public Task<ObservableCollection<ParametroOdontologicoConvenioEntity>> ListarParametrosConvenio(short IdIps, short idConvenio)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ParametroOdontologicoConvenioEntity>>();

            cliente.ListarParametrosConvenioCompleted += (s, e) =>
            {

                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarParametrosConvenioAsync(IdIps, idConvenio);

            return tcs.Task;
        }

        public Task<ParametroOdontologicoBodegaEntity> ListarParametrosBodega(short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ParametroOdontologicoBodegaEntity>();

            cliente.ListarParametrosBodegaCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ListarParametrosBodegaAsync(idIps);
            return tcs.Task;
        }

        public Task<TratamientoEntity> SeleccionarTratamientoActivo(long idTratamiento)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<TratamientoEntity>();

            cliente.SeleccionarTratamientoActivoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.SeleccionarTratamientoActivoAsync(idTratamiento);

            return tcs.Task;
        }

        public Task<OdontogramasPacienteEntity> SelecionarOdontogramaPaciente(long idOdontogramaPaciente)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<OdontogramasPacienteEntity>();

            cliente.SeleccionarOdontogramaPacienteCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.SeleccionarOdontogramaPacienteAsync(idOdontogramaPaciente);

            return tcs.Task;
        }


        public Task<long> ReciboCajaTratamiento(long idTratamiento)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<long>();

            cliente.ReciboCajaTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ReciboCajaTratamientoAsync(idTratamiento);
            return tcs.Task;
        }

        public Task<decimal> ValorPagoTratamiento(long idTratamiento)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<decimal>();

            cliente.ValorPagoTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ValorPagoTratamientoAsync(idTratamiento);
            return tcs.Task;
        }

        public Task<bool> ValidarusuarioCierraTratamiento(string idUsuario, string Clave)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<bool>();

            cliente.ValidarUsuarioCierraTratamientoCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ValidarUsuarioCierraTratamientoAsync(idUsuario, Clave);
            return tcs.Task;
        }

        public Task<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>> ConsultarProcedimientosConfigurados(short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>>();

            cliente.ConsultarProcedimientosConfiguradosCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarProcedimientosConfiguradosAsync(idIps);
            return tcs.Task;
        }

        public Task<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>> ConsultarDiagnosticosConfigurados(short idIps)
        {
            inicializarContexto();
            var tcs = new TaskCompletionSource<ObservableCollection<ConfigurarDiagnosticoProcedimOtraEntity>>();

            cliente.ConsultarDiagnosticosConfiguradosCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            cliente.ConsultarDiagnosticosConfiguradosAsync(idIps);
            return tcs.Task;
        }
    }
}