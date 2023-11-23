using System;

namespace DatosBoleta{

    class ArchivoProfesional{

    public List<Profesional> leerProfesionales(string archivo){

        List<Profesional> profesionales = new List<Profesional>();

        String? linea;
            try{
                StreamReader sr = new StreamReader(archivo);
                linea = sr.ReadLine();
                
                while (linea != null){

                    string[] datos;
                    datos = linea.Split(";");

                    if (datos.Length == 4){
                        Profesional profesional = new Profesional(datos[0], datos[1], Convert.ToInt32(datos[2]), datos[3]);
                        profesionales.Add(profesional);
                    }
                    linea = sr.ReadLine();
                }
                sr.Close();
            }catch (FileNotFoundException){
                Console.WriteLine("No se encuentra el archivo!");
            }catch(IOException){

            }
            return profesionales;
        }
    }
}