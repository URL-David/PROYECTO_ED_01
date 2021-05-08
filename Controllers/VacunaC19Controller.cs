using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_ED_01.Clases;
using PROYECTO_ED_01.Models;
using GenericosLibreria.Estruturas;

namespace PROYECTO_ED_01.Controllers
{
    public class VacunaC19Controller : Controller
    {
        public static ArbolAVL<Paciente> AVLDPI = new ArbolAVL<Paciente>();
        public static ArbolAVL<Paciente> AVLNombres = new ArbolAVL<Paciente>();
        public static ArbolAVL<Paciente> AVLApellidos = new ArbolAVL<Paciente>();

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
            Paciente AuxPaciente = new Paciente()
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

            return View("IngresoPaciente");

        }

        public ActionResult ListaDePacientes()
        {
            ViewBag.Pacientes = AVLDPI.Mostrar();
            return View();
        }
        public ActionResult RealizarBusqueda(string Buscar, string Texto)
        {
            if (Texto == null)
            {
                Paciente AuxPaciente = new Paciente();
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
                        List<Paciente> ListaError = new List<Paciente>();
                        ViewBag.Pacientes = ListaError;
                        return View("ListaDePacientes");
                    }
                }
            }
            else
            {
                List<Paciente> ListaError = new List<Paciente>();
                ViewBag.Pacientes = ListaError;
            }
            return View("ListaDePacientes");
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