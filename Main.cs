using System;
using DatosBoleta;
using Money;
using Interfaz;

class Test {
    static void Main(string[] args){
        InterfazIO ui = new InterfazIO();

        //  Guardar los datos de los archivos de texto
        ArchivoProfesional archivoProfesional = new ArchivoProfesional();
        Dictionary<string, Profesional> listaProfesionales = archivoProfesional.leerProfesionales(".\\data\\Personal.txt");

        ArchivoServicios archivoServicios = new ArchivoServicios();
        Dictionary<string, Servicio> servicios = archivoServicios.leerServicios(".\\data\\Servicios.txt");

        // Detallar los datos del cliente
        Cliente cliente = new Cliente ();

        ui.ObtenerDatosCliente(cliente);

        List<Servicio> serviciosSolicitados = new List<Servicio>();
        
        ui.imprimirSeparador();
        ui.ElegirServicios(servicios, serviciosSolicitados, listaProfesionales);  
        ui.imprimirSeparador();
        
        Console.WriteLine("Los servicios que has adquirido son:\n");
        foreach (Servicio servicio in serviciosSolicitados){
            Console.WriteLine($"{servicio.Descripcion}\t$ {servicio.PrecioUnitario}"); 
        }
        ui.imprimirSeparador();

        int total = 0;
        foreach(var servicio in serviciosSolicitados){
            total += servicio.PrecioUnitario;
        }
        Console.WriteLine("Serían: $" + total);
        
        ui.imprimirSeparador();
        IMetodoPago metodoUsado = ui.ManejarTipoPago(total);
        ui.imprimirSeparador();
        
        cliente.Pagar(total, metodoUsado);
        ui.imprimirSeparador();
        
        
        
        
        
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
    }
}