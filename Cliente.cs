using Money;

namespace DatosBoleta{

    class Cliente : Persona{

        public Cliente(string nombre, int edad, string rut, string direccion, string sexo, string fono, string ciudad, string comuna  ) : base(nombre, edad, rut, direccion, sexo, fono, ciudad, comuna){

        }

        public Cliente(string nombre, string rut, int edad) : base(nombre, rut, edad){

        }

        public void Pagar(int monto, IMetodoPago metodoPago){
            metodoPago.Pagar(monto);
        }
    }
}