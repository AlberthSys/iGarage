﻿using System;
using System.Collections.Generic;
using System.IO;

class GestorCliente
{
    public void GuardarCliente(List<Cliente> clientes)
    {
        try
        {
            StreamWriter datosEscribir = File.CreateText("Clientes.txt");
            foreach (Cliente m in clientes)
            {
                datosEscribir.Write(m.GetNombreCompleto() + ";" + m.GetDireccion() + ";" +
                    m.GetDocID() + ";" + m.GetCompeticion());
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

    public List<Cliente> CargarClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        Cliente aux;
        string linea;
        StreamReader ficheroRead;
        if (!File.Exists("Clientes.txt"))
        {
            return clientes;
        }
        try
        { 
            ficheroRead = File.OpenText("Clientes.txt");
            linea = ficheroRead.ReadLine();

            while(linea != null)
            {
                string[] datos = linea.Split(';');
                string nombreCompleto = datos[0];
                string direccion = datos[1];
                string docID = datos[2];
                bool competicion = Convert.ToBoolean(datos[3]);
                aux = new Cliente(nombreCompleto, direccion, docID, competicion);
                clientes.Add(aux);
            }
            ficheroRead.Close();
        }
        catch (IOException io)
        {
            Console.WriteLine("Error de carga 1: Cliente " + io.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error de carga 2: Cliente " + ex.Message);
        }

        return clientes;
    }
}