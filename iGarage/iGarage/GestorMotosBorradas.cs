using System.Collections.Generic;
using System.IO;
using System;

class GestorMotosBorradas
{
    public void GuardarMoto(List<Motocicleta> myListMotos)
    {
        try
        {
            StreamWriter datosEscribir = File.CreateText("MotosBorradas.txt");
            foreach (Motocicleta m in myListMotos)
            {
                datosEscribir.Write(m.GetMatricula() + ";" + m.GetModelo() + ";"
                    + m.GetMarca() + ";" + m.GetBastidor() + ";" + m.GetCilindrada() + ";"
                    + m.GetVersion() + ";" + m.GetKw() + ";" + m.GetCodigoMotor() + ";"
                    + m.GetKm() + ";" + m.GetCliente().GetNombreCompleto() + ";"
                    + m.GetCliente().GetDireccion() + ";" + m.GetCliente().GetDocID() + ";"
                    + m.GetCliente().GetCompeticion() + ";" + m.GetCliente().GetTelefono() + "\n");
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

    public static List<Motocicleta> CargarMoto()
    {
        List<Motocicleta> motocicletas = new List<Motocicleta>();
        Cliente aux;
        Motocicleta moto;
        string nombreArchivo = "MotosBorradas.txt";
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
                string matricula = datos[0];
                string modelo = datos[1];
                string marca = datos[2];
                string bastidor = datos[3];
                int cilindrada = Convert.ToInt32(datos[4]);
                int version = Convert.ToInt32(datos[5]);
                ushort kw = Convert.ToUInt16(datos[6]);
                int codigoMotor = Convert.ToInt32(datos[7]);
                int km = Convert.ToInt32(datos[8]);
                string nombreCompleto = datos[9];
                string direccion = datos[10];
                string docID = datos[11];
                bool competicion = Convert.ToBoolean(datos[12]);
                int telefono = Convert.ToInt32(datos[13]);
                aux = new Cliente(nombreCompleto, direccion, docID, competicion, telefono);
                moto = new Motocicleta(matricula, modelo, marca, bastidor, cilindrada,
                    version, kw, codigoMotor, km, aux);
                motocicletas.Add(moto);

                linea = ficheroRead.ReadLine();

            }
            ficheroRead.Close();
        }
        catch (IOException io)
        {
            Console.WriteLine("Error de carga 1 - Moto: " + io.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error de carga 2 - Moto: " + ex.Message);
        }

        return motocicletas;
    }
}
