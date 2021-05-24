using System;
using System.Collections.Generic;
using System.IO;

class GestorMecanico
{
    public void GuardarMecanico(List<Mecanico> mecanicos)
    {
        try
        {
            StreamWriter datosEscribir = File.CreateText("Mecanicos.txt");
            foreach (Mecanico m in mecanicos)
            {
                datosEscribir.Write(m.GetNombreCompleto() + ";" + m.GetDireccion() + ";" +
                    m.GetDocID() + ";" + m.GetHorasContratadas() + ";" + m.GetTelefono() + "\n");
            }
            datosEscribir.Close();
        }
        catch (IOException io)
        {
            Console.WriteLine(io.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static List<Mecanico> CargarMecanicos()
    {
        List<Mecanico> mecanicos = new List<Mecanico>();
        Mecanico aux;
        string linea;
        StreamReader ficheroRead;
        if (!File.Exists("Mecanicos.txt"))
        {
            return mecanicos;
        }
        try
        {
            ficheroRead = File.OpenText("Mecanicos.txt");
            linea = ficheroRead.ReadLine();

            while (linea != null)
            {
                string[] datos = linea.Split(';');
                string nombreCompleto = datos[0];
                string direccion = datos[1];
                string docID = datos[2];
                int horasContratadas = Convert.ToInt32(datos[3]);
                int telefono = Convert.ToInt32(datos[4]);
                aux = new Mecanico(nombreCompleto, direccion, docID, horasContratadas, telefono);
                mecanicos.Add(aux);
                linea = ficheroRead.ReadLine();
            }
            ficheroRead.Close();
        }
        catch (IOException io)
        {
            Console.WriteLine("Error de carga 1: Mecanico " + io.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error de carga 2: Mecanico " + ex.Message);
        }

        return mecanicos;
    }
}