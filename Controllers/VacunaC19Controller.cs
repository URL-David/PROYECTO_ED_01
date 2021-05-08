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
    }
}