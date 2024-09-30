using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string fileName = "test.txt";
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + '\\' + fileName)) // si el archivo existe podemos leerlo
        {
            Load(); // IRIA EN EL START PARA CARGARLO EN EL JUEGO
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //NO GUARDEMOS Y CARGUEMOS SIN NINGUN TIPO DE CONDICION EN CADA DE FRAME, rollo cada cierto tiempo..
   
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    private void Save()
    {
        //guardar
        //la raiz de un directorio 
        StreamWriter streamwriter = new StreamWriter(Application.persistentDataPath + '\\' + fileName); //cuando abrimos un arcgivos con permisos de lectura tenemos un booleano, el apped en TRUE te muestra los guardados anteriores y el FALSE borra la informacion que habia en el archivo y escribe desde el inicio te muestra el guardado ACTUAL
                                                                                                        //para que el archivo no sea tan accesible al usuario -> persistentDataPath
        streamwriter.WriteLine("Archivo de guardado");
        streamwriter.WriteLine(Random.Range(0, 100));
        streamwriter.WriteLine(transform.position.x); //guardar la posicion en x
        streamwriter.WriteLine(transform.position.y); //guardar la posicion en y
        streamwriter.WriteLine(transform.position.z); //guardar la posicion en z

        streamwriter.Close(); // IMPORTANTE!! si no lo cerramos los cambios con permisos de lectura no de guardan
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + '\\' + fileName)) // si el archivo existe podemos leerlo
        {
            //cerrar las zonas de codigo que pueden dar lugar a error
            try
            {
                StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
                streamReader.ReadLine(); //la primera linea no es importante ( "archivo de guardado")
                                         // movemos el cursos del archivo a la siguiente linea , tampoco es importante(random range)
                streamReader.ReadLine(); //leyendo la segunda linea

                float x = float.Parse(streamReader.ReadLine()); //tenemos que parsear y decir: este stream es un float// PARSEAR: pasar de un stream a otro tipo de dato diferente
                float y = float.Parse(streamReader.ReadLine());
                float z = float.Parse(streamReader.ReadLine());

                streamReader.Close(); // sino cerramos el archivo se puede corromper

                transform.position = new Vector3(x, y, z); // establecemos la posicion del gameObject

            }
            catch (System.Exception e) //como no guardamos info en ningun servidor, lo guardamos en LOCAL, no tenemos control sobre los archivos del usuarios. Nos aseguramosde que si algo va mal, este todo controlado.
            {
                //cualquier mensaje, EL TOPO DEL ANIMAL CROSSING
                Debug.Log(e.Message);
            }


        }
    }
} 

