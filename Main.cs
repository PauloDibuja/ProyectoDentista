using System;
using DatosBoleta;
using Money;
class Test {
    static void Main(string[] args){
        Dictionary<string, string> keyValues = new Dictionary<string, string>();
        Dictionary<string, int> values = new Dictionary<string, int>();
        /*
        Cliente cliente = new Cliente("Paulo Lara", "21450403-2", 20);
        IMetodoPago miPago = new Convenio("Hogwarts");
        cliente.Pagar(100000, miPago);
        miPago = new Debito();
        cliente.Pagar(100000, miPago);



        ArchivoProfesional archivoProfesional = new ArchivoProfesional();
        List<Profesional> milist = archivoProfesional.leerProfesionales(".\\data\\Personal.txt");
        foreach (Profesional p in milist){
            Console.WriteLine($"{p.Nombre}, {p.Edad} años, Especialidad: {p.Especialidad}");



        }*/
        /*
        string sucursal = "";
        var sucursales = new List<string>();
        sucursales.Add("Santa Cruz");
        sucursales.Add("Santiago");
        sucursales.Add("Maipú");
        sucursales.Add("Recoleta");
        if(args.Length == 0) return;
        else{
            if(sucursales.Contains(args[0])){
                sucursal = args[0];
                Console.WriteLine($"Bienvenido a nuestro dentista Dibuja's aquí en {sucursal}");
            }else{
                Console.WriteLine($"EH EH, NO TENEMOS SUCURSAL AHÍ PIPIPIPI");
            }
        } 
        */

        ArchivoServicios archivoServicios = new ArchivoServicios();
        List<Servicio> servicios = archivoServicios.leerServicios(".\\data\\Servicios.txt");
        foreach(var servicio in servicios){
            Console.WriteLine($"{servicio.Codigo} - {servicio.Descripcion} - $ {servicio.PrecioUnitario}");

        }
    }
}















