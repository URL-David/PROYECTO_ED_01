using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROYECTO_ED_01.GenericosLibreria.Estruturas;
using PROYECTO_ED_01.Clases;

namespace PROYECTO_ED_01.Models
{
    public class Pacientes: IComparable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Situacion_Actual { get; set; }
        public string Enfermedad { get; set; }
        public bool Presenta_Enfermedad { get; set; }
        public long Edad { get; set; }
        public long DPI { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int Prioridad { get; set; }
        public int Posicion { get; set; }
        public bool Vacunado { get; set; }

        public Estadisticas EstadisticasGeneral = new Estadisticas();


        public int CalcularPosicion(int aux)
        {
            Posicion = (Nombre.Length + Apellido.Length) + aux;
            return Posicion;
        }

        public int ObtenerPosicion()
        {
            if (Departamento == "Chimaltenango" || Departamento == "Guatemala" || Departamento == "Sacatepéquez")
            {
                Posicion = CalcularPosicion(1);
                return Posicion;
            }
            else if (Departamento == "Quetzaltenango" || Departamento == "Totonicapán" || Departamento == "San Marcos" || Departamento == "Huehuetenango")
            {
                Posicion = CalcularPosicion(2);
                return Posicion;
            }
            else if (Departamento == "Izabal" || Departamento == "Zacapa" || Departamento == "Chiquimula" || Departamento == "Jalapa" || Departamento == "El Progreso")
            {
                Posicion = CalcularPosicion(3);
                return Posicion;
            }
            else if (Departamento == "Escuintla" || Departamento == "Jutiapa" || Departamento == "Santa Rosa" || Departamento == "Suchitepéquez" || Departamento == "Retalhuleu")
            {
                Posicion = CalcularPosicion(4);
                return Posicion;
            }
            else
            {
                Posicion = CalcularPosicion(5);
                return Posicion;
            }
        }

        public bool PresentaEnfermedad()
        {
            if (Enfermedad == "Ninguna")
                return Presenta_Enfermedad = false;
            else
                return Presenta_Enfermedad = true;
        }

        public void CalcularPrioridad()
        {
            if (Situacion_Actual == "Trabajador de establecimientos de salud asistencial que atienden pacientes con COVID-19 (primera línea)*")
                Prioridad = 1;
            else if (Situacion_Actual == "Trabajador de establecimiento de salud asistencial no incluidos en sub-fase 1a y comunitario de apoyo, incluyendo: comadronas, promotores voluntarios y terapeutas tradicionales")
                Prioridad = 2;
            else if (Situacion_Actual == "Estudiantes de ciencias de la salud y afines que realizan prácticas asistenciales en establecimientos de salud")
                Prioridad = 3;
            else if (Situacion_Actual == "Cuerpos de socorro (bomberos y paramédicos de ambulancias, incluyendo cuerpos de socorro CONRED),trabajadores de funerarias y personal que labora en instituciones de adultos mayores (asilos)")
                Prioridad = 4;
            else if (Situacion_Actual == "Personas internadas en hogares o instituciones de adultos mayores (asilos)")
                Prioridad = 5;
            else if (Situacion_Actual == "Trabajadores del sector salud (administrativos)")
                Prioridad = 6;

            else if (Edad >= 70)
                Prioridad = 7;

            else if (Edad >= 60 && Edad <= 69)
                Prioridad = 8;

            else if (Edad >= 50 && Edad <= 59)
                Prioridad = 9;

            else if (Edad >= 18 && Presenta_Enfermedad == true)
                Prioridad = 10;

            else if (Situacion_Actual == "Trabajadores sector educación ( incluye maestros y docentes del nivel preprimario, primario, básico, diversificado y universitario)")
                Prioridad = 11;

            else if (Situacion_Actual == "Trabajadores sector seguridad nacional (incluye PNC, PMT, militares y personal del sistema penitenciario)")
                Prioridad = 12;

            else if (Situacion_Actual == "Trabajadores registrados en las municipalidades y entidades que prestan servicios esenciales de electricidad, agua, recolección de basura, aduanas y migración")
                Prioridad = 13;

            else if (Situacion_Actual == "Autoridades y demás servidores públicos del Ministerio de Educación y trabajadores de las Universidades del país")
                Prioridad = 14;

            else if (Situacion_Actual == "Trabajadores sector justicia, (incluye jueces, personal en tribunales, fiscales, auxiliares fiscales e investigadores del Ministerio Público)")
                Prioridad = 15;

            else if (Edad >= 40 && Edad <= 49)
                Prioridad = 16;

            else if (Edad >= 18 && Edad <= 39)
                Prioridad = 16;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public Comparison<Pacientes> BuscarPrioridad = delegate (Pacientes Paciente1, Pacientes Paciente2)
        {
            return Paciente1.Prioridad.CompareTo(Paciente2.Prioridad);
        };
        public Comparison<Pacientes> BuscarNombre = delegate (Pacientes Paciente1, Pacientes Paciente2)
        {
            return Paciente1.Nombre.CompareTo(Paciente2.Nombre);
        };
        public Comparison<Pacientes> BuscarApellido = delegate (Pacientes Paciente1, Pacientes Paciente2)
        {
            return Paciente1.Apellido.CompareTo(Paciente2.Apellido);
        };
        public Comparison<Pacientes> ConteinsNombre = delegate (Pacientes Paciente1, Pacientes Paciente2)
        {
            if (Paciente1.Nombre.Contains(Paciente2.Nombre))
                return 0;
            else
                return 1;
        };
        public Comparison<Pacientes> ConteinsApellido = delegate (Pacientes Paciente1, Pacientes Paciente2)
        {
            if (Paciente1.Apellido.Contains(Paciente2.Apellido))
                return 0;
            else
                return 1;
        };
        public Comparison<Pacientes> BuscarDPI = delegate (Pacientes Paciente1, Pacientes Paciente2)
        {
            return Paciente1.DPI.CompareTo(Paciente2.DPI);
        };



    }
}
