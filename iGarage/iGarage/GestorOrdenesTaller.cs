using System;
using System.Collections.Generic;
using System.IO;

class GestorOrdenesTaller
{
    public void GuardarOrdenTaller(List<OrdenReparacion>ordenReparaciones)
    {
        try
        {
            string nombreFichero = "OrdenesReparacion.txt";
            StreamWriter sw = File.CreateText(nombreFichero);
            foreach (OrdenReparacion o in ordenReparaciones)
            {
                sw.Write(o.GetNumeroOrden() + ";"
                    + o.GetCliente().GetNombreCompleto() + ";"
                    + o.GetCliente().GetDireccion() + ";"
                    + o.GetCliente().GetDocID() + ";"
                    + o.GetCliente().GetCompeticion() + ";"
                    + o.GetCliente().GetTelefono() + ";"
                    + o.GetMecanico().GetNombreCompleto() + ";"
                    + o.GetMecanico().GetDireccion() + ";"
                    + o.GetMecanico().GetDocID() + ";"
                    + o.GetMecanico().GetHorasContratadas() + ";"
                    + o.GetMecanico().GetTelefono() + ";"
                    + o.GetMotocicleta().GetMatricula() + ";"
                    + o.GetMotocicleta().GetModelo() + ";"
                    + o.GetMotocicleta().GetMarca() + ";"
                    + o.GetMotocicleta().GetBastidor() + ";"
                    + o.GetMotocicleta().GetCilindrada() + ";"
                    + o.GetMotocicleta().GetVersion() + ";"
                    + o.GetMotocicleta().GetKw() + ";" 
                    + o.GetMotocicleta().GetCodigoMotor() + ";"
                    + o.GetMotocicleta().GetKm() + ";"
                    + o.GetProblema() + "\n"); 
            }
            sw.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Error 0 - GuardarOrdenRep: " + e.Message);
        }
        catch (Exception i)
        {
            Console.WriteLine("Error 1 - GuardarOrdenRep: " + i.Message);
        }
    }

    public static List<OrdenReparacion> CargarOrdenesRep()
    {
        List<OrdenReparacion> ordenReparaciones = new List<OrdenReparacion>();
        OrdenReparacion aux;
        Cliente auxCliente;
        Mecanico auxMecanico;
        Motocicleta auxMoto;
        string linea;
        string nombreFichero = "OrdenesReparacion.txt";
        StreamReader st;
        if (!File.Exists(nombreFichero))
        {
            return ordenReparaciones;
        }
        try
        {
            st = File.OpenText(nombreFichero);
            linea = st.ReadLine();
            while (linea!= null)
            {
                string[] datos = linea.Split(';');
                int numeroOrden = Convert.ToInt32(datos[0]);
                string nombreCompletoCliente = datos[1];
                string direccionCliente = datos[2];
                string docIDCliente = datos[3];
                bool competicion = Convert.ToBoolean(datos[4]);
                int telefonoCliente = Convert.ToInt32(datos[5]);
                string nombreCompletoMecanico = datos[6];
                string direccionMecanico = datos[7];
                string docIDMecanico = datos[8];
                int horasContratadas = Convert.ToInt32(datos[9]);
                int telefonoMecanico = Convert.ToInt32(datos[10]);
                string matricula = datos[11];
                string modelo = datos[12];
                string marca = datos[13];
                string bastidor = datos[14];
                int cilindrada = Convert.ToInt32(datos[15]);
                int version = Convert.ToInt32(datos[16]);
                ushort kw = Convert.ToUInt16(datos[17]);
                int codigoMotor = Convert.ToInt32(datos[18]);
                int km = Convert.ToInt32(datos[19]);
                string problema = datos[20];
                auxCliente = new Cliente(nombreCompletoCliente, direccionCliente,
                    docIDCliente, competicion, telefonoCliente);
                auxMecanico = new Mecanico(nombreCompletoMecanico, direccionMecanico,
                    docIDMecanico, horasContratadas, telefonoMecanico);
                auxMoto = new Motocicleta(matricula, modelo, marca, bastidor, cilindrada,
                   version, kw, codigoMotor, km, auxCliente);
                aux = new OrdenReparacion(numeroOrden, auxCliente, auxMecanico, auxMoto,
                    problema);
                ordenReparaciones.Add(aux);
                linea = st.ReadLine();
            }
            st.Close();
        }
        catch (IOException r)
        
        {
            Console.WriteLine("Error 0 - CargaOrdenRep: " + r.Message);
        }
        catch (Exception t)
        {
            Console.WriteLine("Error 1 - CargaOrdenRep: " + t.Message);
        }

        return ordenReparaciones;
    }
}