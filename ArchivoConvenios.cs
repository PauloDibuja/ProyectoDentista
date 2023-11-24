using System;

namespace DatosBoleta{

    class ArchivoConvenios{

    public List<string> archivoConvenios(string archivo){

        List<string> convenios = new List<string> ();

        String? linea;
            try{
                StreamReader sr = new StreamReader(archivo);
                linea = sr.ReadLine();
                
                while (linea != null){
                    convenios.Add(linea);
                    linea = sr.ReadLine();
                }
                sr.Close();
            }catch (FileNotFoundException ){
                Console.WriteLine("No se encuentra el archivo");
            }catch (IOException){
                Console.WriteLine("Error al intentar leer el archivo");
            }
            return convenios;
        }
    }
}