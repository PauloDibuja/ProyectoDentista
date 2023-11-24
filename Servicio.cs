using System;

namespace DatosBoleta{
    class Servicio{

        private string descripcion;
        private string codigo;
        private int precioUnitario;
        private string especialidadRequerida;
        private Profesional profesionalEncargado = new Profesional();

        public Servicio(string descripcion, string codigo, int precioUnitario, string especialidadRequerida){

            this.descripcion = descripcion;
            this.codigo = codigo;
            this.precioUnitario = precioUnitario;
            this.especialidadRequerida = especialidadRequerida;
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

        public string EspecialidadRequerida{
            get{return especialidadRequerida;}
            set{especialidadRequerida = value;}
        }

        public Profesional ProfesionalEncargado{
            get{return profesionalEncargado;}
            set{profesionalEncargado = value;}
        }

        public static bool operator >>(Servicio ser1, List<Servicio> list){
            foreach(var servicio in list){
                if(servicio.Codigo == ser1.Codigo) return true;
            }
            return false;
        }
    }
}
