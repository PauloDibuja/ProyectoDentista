using System;

namespace DatosBoleta{
    class Servicio{

       
        private string descripcion;
        private string codigo;
        private int precioUnitario;
        private Profesional profesional;

        public Servicio(string descripcion, string codigo, int precioUnitario, Profesional profesional){

            this.descripcion = descripcion;
            this.codigo = codigo;
            this.precioUnitario = precioUnitario;
            this.profesional = profesional;
        }

        public Servicio(string descripcion, string codigo, int precioUnitario){

            this.descripcion = descripcion;
            this.codigo = codigo;
            this.precioUnitario = precioUnitario;
            this.profesional = new Profesional();
        }

        public string Descripcion{
            get {return descripcion;}
            set{descripcion = value;}
        }

        public string Codigo{
            get {return codigo;}
            set{codigo = value;}
        }

        public int PrecioUnitario{

            get {return precioUnitario;}
            set{precioUnitario = value;}

        }

        public Profesional Profesional{
            get{return profesional;}
            set{profesional = value;}
        }
    }
}
