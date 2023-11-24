using System;
using DatosBoleta;
using Money;

class Test {

    static void imprimirSeparador(){
        Console.WriteLine("----------------------------------------------------------------");
    }
    static void DecididoServicios(ref int opcion)
    {
        bool decidido = false;
            while(decidido == false){
                try{
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Write(">> ");
                    
                    if(opcion == 0 || opcion == 1){
                        decidido = true;

                    }else{
                        Console.WriteLine("Recuerde, 1 para 'Si', 0 para 'Eso, nada más'");
                    }
                } catch(FormatException){
                    Console.WriteLine("Error!, Ingrese un número");
                }     
            }
    }
    static void ImprimirServicios(Dictionary<string, Servicio> servicios){
        Console.WriteLine("\nLISTA DE SERVICIOS QUE PROPORCIONAMOS\n");
        foreach(var servicio in servicios){
            string clave = servicio.Key;
            Console.WriteLine($"{clave} - {servicios[clave].Descripcion} - $ {servicios[clave].PrecioUnitario}");
        }
    }
    static string ElegirConvenio() { 
        ArchivoConvenios archivoConvenios = new ArchivoConvenios();
        List<string> listaConvenios = archivoConvenios.archivoConvenios(".\\data\\Convenio.txt");

        string? convenioElegido;
        bool elegido = false;
        Console.WriteLine("LISTA DE CONVENIOS:");
        foreach(var c in listaConvenios){
            Console.WriteLine($"- {c}");
        }

        while(elegido == false){
            Console.Write("Elige el convenio: ");
            convenioElegido = Console.ReadLine();
            if(convenioElegido == null) convenioElegido = "";
            convenioElegido = convenioElegido.TrimStart(' ');
            convenioElegido = convenioElegido.TrimEnd(' ');


            if(!listaConvenios.Contains(convenioElegido)){
                Console.WriteLine("Lo siento, pero no tenemos un convenio con esa institución.\n");
                continue;
            }else{
                elegido = true;
                return convenioElegido;
            }
        }
        return "";
    }
    static IMetodoPago ManejarTipoPago(int monto){
        Console.WriteLine("¿Cómo cancela?");

        Console.WriteLine("[0] - Efectivo");
        Console.WriteLine("[1] - Débito");
        Console.WriteLine("[2] - Crédito");
        Console.WriteLine("[3] - Convenio\n");
        int opcionPago = -1;
        while(opcionPago >= 4 || opcionPago < 0){
            Console.Write(">> ");
            try{
                opcionPago = Convert.ToInt32(Console.ReadLine());
                if(opcionPago < 0 || opcionPago >= 4){
                    Console.WriteLine("Error!, elija una de las opciones que se le mostraron: ");
                    continue;
                }
                switch(opcionPago){
                    case 0:
                        IMetodoPago efectivo = new Efectivo();
                        return efectivo;
                    case 1:
                        IMetodoPago debito = new Debito();
                        return debito;
                    case 2: 
                        IMetodoPago credito = new Credito();
                        return credito;
                    case 3:
                        string nombre = ElegirConvenio();
                        IMetodoPago convenioMetodo = new Convenio(nombre);
                        return convenioMetodo;
                    default:
                        break;
                }
            }
            catch (FormatException){
                Console.WriteLine("Error!, Ingrese un número");
            }
        }
        return new Efectivo();      // Retorna el metodo de efectivo por defecto. (En rara ocasión pasará por este return)
    }
    
    static void ElegirServicios(ref Dictionary<string, Servicio> servicios, List<Servicio> serviciosSolicitados, Dictionary<string, Profesional> listaProfesionales) {
        int opcion = 1;
        string? peticionCodigo;

        ImprimirServicios(servicios);
        
        imprimirSeparador();
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
            Console.WriteLine($"¿Algo más? ---> 1 para 'Si', 0 para 'Eso, nada más'");
            Console.Write(">> ");
            DecididoServicios(ref opcion);
            imprimirSeparador();
        }
        GC.Collect(); // Todas las referencias originales que tenías los objetos Servicio al inicializarse serán borrados eventualmente. (excepto la lista de servicios disponibles)
    }
    


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
        List<Servicio> serviciosSolicitados = new List<Servicio>();
        imprimirSeparador();
        ElegirServicios(ref servicios, serviciosSolicitados, listaProfesionales);  
        imprimirSeparador();
        Console.WriteLine("Los servicios que has adquirido son:\n");
        foreach (Servicio servicio in serviciosSolicitados){
            Console.WriteLine($"{servicio.Descripcion}\t$ {servicio.PrecioUnitario}"); 
        }
        imprimirSeparador();
        int total = 0;
        foreach(var servicio in serviciosSolicitados){
            total += servicio.PrecioUnitario;
        }
        Console.WriteLine("Serían: $" + total);
        imprimirSeparador();
        IMetodoPago metodoUsado = ManejarTipoPago(total);
        imprimirSeparador();
        cliente.Pagar(total, metodoUsado);
        imprimirSeparador();
        
        
        
        
        
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