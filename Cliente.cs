using Money;

namespace DatosBoleta{

    class Cliente : Persona{
        public void Pagar(int monto, IMetodoPago metodoPago){
            metodoPago.Pagar(monto);
        }
    }
}