using System;

namespace DatosBoleta{

    class ArchivoServicios{

    public Dictionary<string, Servicio> leerServicios(string archivo){

        Dictionary<string, Servicio> servicios = new Dictionary<string, Servicio>();

        String? linea;
            try{
                StreamReader sr = new StreamReader(archivo);
                linea = sr.ReadLine();
                
                while (linea != null){

                    string[] datos;
                    datos = linea.Split(";");

                    if (datos.Length == 4){
                        Servicio servicio = new Servicio(datos[1], datos[0], Convert.ToInt32(datos[2]), datos[3]);
                        servicios.Add(datos[0], servicio);
                    }

                    linea = sr.ReadLine();

                }
                sr.Close();
            }catch (Exception ){
                
            }
            return servicios;
        }
    }
}