using System;

namespace DatosBoleta{

    class ArchivoServicios{

    public List<Servicio> leerServicios(string archivo){

        List<Servicio> servicios = new List<Servicio>();

        String? linea;
            try{
                StreamReader sr = new StreamReader(archivo);
                linea = sr.ReadLine();
                
                while (linea != null){

                    string[] datos;
                    datos = linea.Split(";");

                    if (datos.Length == 4){
                        Servicio servicio = new Servicio(datos[1], datos[0], Convert.ToInt32(datos[2]));
                        servicios.Add(servicio);
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