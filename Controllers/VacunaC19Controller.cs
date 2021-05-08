using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_ED_01.Models;
using PROYECTO_ED_01.Clases;
using PROYECTO_ED_01.GenericosLibreria.Estruturas;
using GenericosLibreria.Estruturas;

namespace PROYECTO_ED_01.Controllers
{
    public class VacunaC19Controller : Controller
    {
        public static ArbolAVL<Pacientes> AVLDPI = new ArbolAVL<Pacientes>();
        public static ArbolAVLRepetidos<Pacientes> AVLNombres = new ArbolAVLRepetidos<Pacientes>();
        public static ArbolAVLRepetidos<Pacientes> AVLApellidos = new ArbolAVLRepetidos<Pacientes>();
        public static TablaHash<Pacientes> AlamcenamientoPacientes = new TablaHash<Pacientes>();
        public static ColaPrioridad<Pacientes> PrioridadPacientes = new ColaPrioridad<Pacientes>();


        public Estadisticas EstadisticasGeneral = new Estadisticas();


        public ActionResult Index()
        {
            return View();
        }

        // Vista Ingresar Paciente
        public ActionResult IngresoPaciente()
        {
            return View();
        }
        // Guardar Paciente
        [HttpPost]
        public ActionResult GuardarPaciente(IFormCollection collection)
        {
            Pacientes AuxPaciente = new Pacientes()
            {         
                Nombre = collection["Nombre"],
                Apellido = collection["Apellido"],
                Situacion_Actual = collection["Situacion_Actual"],
                Enfermedad = collection["Enfermedad"],
                Edad = Convert.ToInt32(collection["Edad"]),
                DPI = Convert.ToInt64(collection["DPI"]),
                Departamento = collection["Departamento"],
                Municipio = collection["Municipio"],

            };

            AuxPaciente.PresentaEnfermedad();
            AuxPaciente.CalcularPrioridad();
                  
            AVLDPI.Add(AuxPaciente, AuxPaciente.BuscarDPI);
            AVLNombres.Add(AuxPaciente, AuxPaciente.BuscarNombre);
            AVLApellidos.Add(AuxPaciente, AuxPaciente.BuscarApellido);

            AlamcenamientoPacientes.Añadir(AuxPaciente, AuxPaciente.ObtenerPosicion(), AuxPaciente.BuscarDPI);

            PrioridadPacientes.Add(AuxPaciente, AuxPaciente.BuscarPrioridad);


            return View("IngresoPaciente");

        }

        public ActionResult ListaDePacientes()
        {
            ViewBag.Pacientes = AVLDPI.Mostrar();
            return View();
        }

        public ActionResult RealizarBusqueda(string Buscar, string Texto)
        {
            if (Texto != null)
            {
                Pacientes AuxPaciente = new Pacientes();
                if (Buscar == "N")
                {
                    AuxPaciente.Nombre = Texto;
                    ViewBag.Pacientes = AVLNombres.Filtrar(AuxPaciente.BuscarNombre, AuxPaciente);
                }
                else if (Buscar == "A")
                {
                    AuxPaciente.Apellido = Texto;
                    ViewBag.Pacientes = AVLApellidos.Filtrar(AuxPaciente.BuscarApellido, AuxPaciente);
                }
                else
                {
                    try
                    {
                        AuxPaciente.DPI = Convert.ToInt64(Texto);
                        ViewBag.Pacientes = AVLNombres.Get(AuxPaciente, AuxPaciente.BuscarDPI);
                    }
                    catch (Exception)
                    {
                        List<Pacientes> ListaError = new List<Pacientes>();
                        ViewBag.Pacientes = ListaError;
                        return View("ListaDePacientes");
                    }
                }
            }
            else
            {
                List<Pacientes> ListaError = new List<Pacientes>();
                ViewBag.Pacientes = ListaError;
            }
            return View("ListaDePacientes");
        }

        public ActionResult MostrarEstadisticas()
        {
            try
            {
                double Porcentaje = ((EstadisticasGeneral.Enespera / EstadisticasGeneral.Vacunados) * 100);
                EstadisticasGeneral.PorcentajeVacunados = Convert.ToString(Porcentaje) + "%";
            }
            catch (Exception)
            {
                EstadisticasGeneral.PorcentajeVacunados = "0.00%";
            }
            return View(EstadisticasGeneral);
        }
        public ActionResult ManualDeUsuario()
        {
            return View();
        }
        public ActionResult ManualInformacionG()
        {
            return View();
        }
        public ActionResult ManualGuia()
        {
            return View();
        }
        public ActionResult ManualBibliografia()
        {
            return View();
        }

        public ActionResult ManualCreditos()
        {
            return View();
        }
        public ActionResult GNuevoP()
        {
            return View();
        }
        public ActionResult GCentrosV()
        {
            return View();
        }
        public ActionResult GListaP()
        {
            return View();
        }
        public ActionResult GPersonasV()
        {
            return View();
        }
        public ActionResult GEmulador()
        {
            return View();
        }
    }
}