using System;
using DatosBoleta;
using Money;
using System.Text.RegularExpressions;

namespace Interfaz{
    class InterfazIO{
        public void imprimirSeparador(){
            Console.WriteLine("----------------------------------------------------------------");
        }
        
        public string NombreCliente(){
            string? nombre = "";
            do{
                Console.Write("¿Cuál es su nombre?\n>> ");
                nombre = Console.ReadLine();

                if(nombre == "" || nombre == null){
                    Console.WriteLine("Por favor, ingrese su nombre.\n");
                    imprimirSeparador();
                } else if(nombre.All(c => char.IsLetter(c) || c == ' ') == false){
                    Console.WriteLine("Por favor, su nombre no puede tener números o símbolos.\n");
                    imprimirSeparador();
                    nombre = "";
                }
            }while(nombre == null || nombre == "");
            return nombre;
        }
        
        public string RUTCliente(){
            string? rut = "";
            string regexrRutCompleto = @"^\d{1,8}-[0-9kK]$";
            Regex expr = new Regex(regexrRutCompleto);
            do{
                Console.Write("¿Cuál es su RUT? (Sin puntos, con guión y número verificador)\n>> ");
                rut = Console.ReadLine();
                if(rut == "" || rut == null){
                    Console.WriteLine("Por favor, ingrese su RUT.\n");
                    imprimirSeparador();
                }else if(expr.IsMatch(rut) == false){
                    rut = "";
                    Console.WriteLine("Profe ql tonto, escriba bien su RUT");
                }
            }while(rut == null || rut == "");
            return rut;
        }

        public string DireccionCliente(){
            string? direccion = "";
            do{
                Console.Write("¿Cuál es su dirección?\n>> ");
                direccion = Console.ReadLine();
                if(direccion == null || direccion == ""){
                    Console.WriteLine("Por favor, dígame su dirección.");
                    imprimirSeparador();
                }
            }while(direccion == null || direccion == "");
            return direccion;
        }

        public string CiudadCliente(){
            string? ciudad = "";
            do{
                Console.Write("¿En qué ciudad?\n>> ");
                ciudad = Console.ReadLine();
                if(ciudad == null || ciudad == ""){
                    Console.WriteLine("Por favor, dígame su ciudad.");
                    imprimirSeparador();
                }
            }while(ciudad == null || ciudad == "");
            return ciudad;
        }

        public void ObtenerDatosCliente(Cliente cliente){
            // Nombre del cliente
            
            string nombreCliente = NombreCliente();
            string rutCliente = RUTCliente();

            //
        }
        public void DecididoServicios(ref int opcion)
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
        public void ImprimirServicios(Dictionary<string, Servicio> servicios){
            Console.WriteLine("\nLISTA DE SERVICIOS QUE PROPORCIONAMOS\n");
            foreach(var servicio in servicios){
                string clave = servicio.Key;
                Console.WriteLine($"{clave} - {servicios[clave].Descripcion} - $ {servicios[clave].PrecioUnitario}");
            }
        }
        public string ElegirConvenio() { 
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
        public IMetodoPago ManejarTipoPago(int monto){
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
        public void ElegirServicios(Dictionary<string, Servicio> servicios, List<Servicio> serviciosSolicitados, Dictionary<string, Profesional> listaProfesionales) {
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
    }
}