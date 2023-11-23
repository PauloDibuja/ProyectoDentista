namespace DatosBoleta
{
    abstract class Persona
    {
        private string nombre = "Sin nombre";
        private int edad = -1;
        private string rut = "00000000-0";
        private string direccion = "-";
        private string sexo = "-";
        private string fono = "---------";
        private string ciudad = "-";
        private string comuna = "-";

        public Persona(string nombre, int edad, string rut, string direccion, string sexo, string fono, string ciudad, string comuna){
            this.nombre = nombre;
            this.edad = edad;
            this.rut = rut;
            this.direccion = direccion;
            this.sexo = sexo;
            this.fono = fono;
            this.ciudad = ciudad;
            this.comuna = comuna;
        }

        public Persona(string nombre, string rut, int edad){
            this.nombre = nombre;
            this.rut = rut;
            this.edad = edad;
        }

        public Persona(string nombre, string rut, string direccion){
            this.nombre = nombre;
            this.rut = rut;
            this.direccion = direccion;
        }

        public Persona(){
            
        }

        // Setters y Getters

        public string Nombre{
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Edad{
            get { return this.edad; }
            set { this.edad = value; }
        }

        public string Rut{
            get { return this.rut; }
            set { this.rut = value; }
        }

        public string Direccion{
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        public string Sexo{
            get { return this.sexo; }
            set { this.sexo = value; }
        }

        public string Fono{
            get { return this.fono; }
            set { this.fono = value; }
        }

        public string Ciudad{
            get { return this.ciudad; }
            set { this.ciudad = value; }
        }

        public string Comuna{
            get { return this.comuna; }
            set { this.comuna = value; }
        }
    }
}