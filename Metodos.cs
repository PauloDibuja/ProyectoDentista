namespace Money{
    class Efectivo : IMetodoPago{

        public void Pagar(int monto){
            Console.WriteLine($"Se ha realizado un pago de $ {monto} en Efectivo");
        }
    }


    class Debito : IMetodoPago{
        public void Pagar(int monto){
            Console.WriteLine($"Se ha realizado un pago de $ {monto} en Debito");
        }
    }


    class Credito : IMetodoPago{
        public void Pagar(int monto){
            Console.WriteLine($"Se ha realizado un pago de $ {monto} en Credito");
        }
    }
    

    class Convenio : IMetodoPago{
        private string nombreConvenio;
        public Convenio(string nombreConvenio) : base(){
            this.nombreConvenio = nombreConvenio;
        }
        public void Pagar(int monto){
            Console.WriteLine($"Se ha realizado un pago de $ {monto} bajo el convenio {this.nombreConvenio}");
        }
    }
}


