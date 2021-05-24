using System;
using System.Collections.Generic;
using System.IO;

class GestorProveedor
{
    public void GuardarProveedor(List<Proveedor> proveedores)
    {
        try
        {
            StreamWriter datosEscribir = File.CreateText("Proveedores.txt");
            foreach (Proveedor p in proveedores)
            {
                datosEscribir.Write(p.GetNombreCompleto() + ";" + p.GetDireccion() + ";" +
                    p.GetDocID() + ";" + p.NumeroCuenta + ";" + p.Deuda + "\n");
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

    public static List<Proveedor> CargarProveedor()
    {
        List<Proveedor> proveedores = new List<Proveedor>();
        Proveedor aux;
        string linea;
        StreamReader ficheroRead;
        if (!File.Exists("Proveedores.txt"))
        {
            return proveedores;
        }
        try
        {
            ficheroRead = File.OpenText("Proveedores.txt");
            linea = ficheroRead.ReadLine();

            while (linea != null)
            {
                string[] datos = linea.Split(';');
                string nombreCompleto = datos[0];
                string direccion = datos[1];
                string docID = datos[2];
                string numeroCuenta = datos[3];
                float deuda = float.Parse(datos[4]);
                aux = new Proveedor(nombreCompleto, direccion, docID, numeroCuenta
                    , deuda);
                proveedores.Add(aux);
                linea = ficheroRead.ReadLine();
            }
            ficheroRead.Close();
        }
        catch (IOException io)
        {
            Console.WriteLine("Error de carga 1: Proveedor " + io.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error de carga 2: Proveedor " + ex.Message);
        }

        return proveedores;
    }
}