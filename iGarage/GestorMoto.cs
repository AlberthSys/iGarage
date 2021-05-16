using System.Collections.Generic;
using System.IO;
using System;

class GestorMoto
{
    public void GuardarMoto(List<Motocicleta>myListMotos)
    {
        try
        {
            StreamWriter datosEscribir = File.CreateText("Motos.txt");
            foreach (Motocicleta m in myListMotos)
            {
                datosEscribir.Write(m.GetModelo() + ";" + m.GetMarca() + ";" + m.GetBastidor()
                    + ";" + m.GetCilindrada() + ";" + m.GetVersion() + ";" + m.GetKw()
                    + ";" + m.GetCodigoMotor() + ";" + m.GetKm() + ";" +
                    m.GetCliente().GetNombreCompleto() + ";" + m.GetCliente().GetDireccion() +
                    ";" + m.GetCliente().GetDocID() + ";" + m.GetCliente().GetCompeticion());
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

    public List<Motocicleta> CargarMoto()
    {
        List<Motocicleta> motocicletas = new List<Motocicleta>();
        Cliente aux;
        Motocicleta moto;
        string nombreArchivo = "Motos.txt";
        string linea;
        StreamReader ficheroRead;
        if (!File.Exists(nombreArchivo))
        {
            return motocicletas;
        }
        try
        {
            ficheroRead = File.OpenText(nombreArchivo);
            linea = ficheroRead.ReadLine();
            while (linea != null)
            {
                string[] datos = linea.Split(';');
                string modelo = datos[0];
                string marca = datos[1];
                string bastidor = datos[2];
                int cilindrada = Convert.ToInt32(datos[3]);
                int version = Convert.ToInt32(datos[4]);
                ushort kw = Convert.ToUInt16(datos[5]);
                int codigoMotor = Convert.ToInt32(datos[6]);
                int km = Convert.ToInt32(datos[7]);
                string nombreCompleto = datos[8];
                string direccion = datos[9];
                string docID = datos[10];
                bool competicion = Convert.ToBoolean(datos[11]);
                aux = new Cliente(nombreCompleto, direccion, docID, competicion);
                moto = new Motocicleta(modelo, marca, bastidor, cilindrada,
                    version, kw, codigoMotor, km, aux);
                motocicletas.Add(moto);
                linea = ficheroRead.ReadLine();
            }
            ficheroRead.Close();
        }
        catch(IOException io)
        {
            Console.WriteLine("Error de carga 1 - Moto: " + io.Message);
        }  
        catch(Exception ex)
        {
            Console.WriteLine("Error de carga 2 - Moto: " + ex.Message);
        }

        return motocicletas;
    }
}