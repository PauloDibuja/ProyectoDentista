using System;

namespace DatosBoleta{
    class Profesional : Persona{

        private string especialidad;

        public Profesional(string nombre, string rut, int edad, string especialidad) : base(nombre, rut, edad){
            this.especialidad = especialidad;
        }

        public Profesional() : base(){
            this.especialidad = "--";
        }

        public string Especialidad{
            get {return this.especialidad; }
            set {this.especialidad = value; }
        }

    }
}