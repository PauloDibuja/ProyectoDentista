using System;
using DatosBoleta;
using Money;

class Test {
    static void Main(string[] args){
        #region Abrir archivos .txt y crear Diccionarios
        //Guarda en lista los profesionales disponibles
        ArchivoProfesional archivoProfesional = new ArchivoProfesional();
        Dictionary<string, Profesional> listaProfesionales = archivoProfesional.leerProfesionales(".\\data\\Personal.txt");

        //Guarda en lista los servicios disponibles
        ArchivoServicios archivoServicios = new ArchivoServicios();
        Dictionary<string, Servicio> servicios = archivoServicios.leerServicios(".\\data\\Servicios.txt");
        #endregion

        //Datos del cliente Paulo lara
        Cliente cliente = new Cliente ("Paulo Lara", "21450403-2", 20);
        IMetodoPago miPago = new Convenio("Hogwarts");
        cliente.Pagar(100000, miPago);

        List<Servicio> serviciosSolicitados = new List<Servicio>();

        int opcion = 1;
        string? peticionCodigo;

        #region Imprimir Todos los servicios
        Console.WriteLine("\nLISTA DE SERVICIOS QUE PROPORCIONAMOS\n");
        foreach(var servicio in servicios){
            string clave = servicio.Key;
            Console.WriteLine($"{clave} - {servicios[clave].Descripcion} - $ {servicios[clave].PrecioUnitario}");

        }
        #endregion
        
        #region Elegir Servicios
        while (opcion != 0){

            Console.Write("\nEscriba el codigo del servicio a solicitar: ");
            peticionCodigo = Console.ReadLine();

            // Verificación
            if(peticionCodigo == null || peticionCodigo == ""){
                Console.WriteLine("No me has escrito nada. Ingresa el código, por favor: ");
                continue;
            }else if(!servicios.ContainsKey(peticionCodigo)){
                Console.WriteLine("No existe un servicio con ese código");
                continue;
            }

            Servicio servicioElegido = servicios[peticionCodigo];
            // El nuevo operador verifica si un servicio ya está solicitado, (está en la lista de serviciosSolicitados).
            if(servicioElegido >> serviciosSolicitados == true){
                Console.WriteLine("OYE!!, tu ya pediste este servicio para este día. Elíge uno distinto.");
                continue;
            }
            serviciosSolicitados.Add(servicioElegido);
            // Elige al profesional de acuerdo a su especialidad
            Profesional profesionalElegido = listaProfesionales[servicioElegido.EspecialidadRequerida];
            servicioElegido.ProfesionalEncargado = profesionalElegido;
            
            // Vemos si el usuario quiere adquirir otro servicio más.
            Console.WriteLine($"Muy bien, vas a tener '{servicioElegido.Descripcion}' con el/la Dr(a). {profesionalElegido.Nombre} ... Serían $ {servicioElegido.PrecioUnitario}");
            Console.WriteLine($"¿Algo más?");
            Console.WriteLine("1 para 'Si', 0 para 'Eso, nada más'");
            
            bool decidido = false;
            while(decidido == false){
                try{
                    opcion = Convert.ToInt32(Console.ReadLine());

                    if(opcion == 0 || opcion == 1){
                        Console.WriteLine("");
                        decidido = true;

                    }else{
                        Console.WriteLine("Recuerde, 1 para 'Si', 0 para 'Eso, nada más'");
                    }
                } catch(FormatException){
                    Console.WriteLine("Error!, Ingrese un número");
                }     
            }
        }
        #endregion
        GC.Collect(); 
        // Todas las referencias originales que tenías los objetos Servicio al inicializarse serán borrados eventualmente. (excepto la lista de servicios disponibles)

        Console.WriteLine("Los servicios que has adquirido son:\n\n");
        foreach (Servicio servicio in serviciosSolicitados){
            Console.WriteLine($"{servicio.Descripcion}\t$ {servicio.PrecioUnitario}"); 
        }

        int total = 0;
        foreach(var servicio in serviciosSolicitados){
            total += servicio.PrecioUnitario;
        }

        Console.WriteLine("Serían: $" + total);
        Console.WriteLine("¿Cómo cancela?");

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






























