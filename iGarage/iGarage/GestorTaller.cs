using System;
using System.Collections.Generic;
using System.IO;

class GestorTaller
{
    private void MenuPrincipal()
    {
        Console.WriteLine();
        Console.WriteLine("        *------ iGarage ------*       ");
        Console.WriteLine();
        Console.WriteLine("1.- MOTOCICLETAS.");
        Console.WriteLine("2.- GESTIÓN PROVEEDORES.");
        Console.WriteLine("3.- ORDEN DE REPARACIÓN.");
        Console.WriteLine("4.- MOSTRAR CLIENTES.");
        Console.WriteLine("E.- SALIR.");
        Console.WriteLine();
    }

    private void MenuMoto()
    {
        Console.WriteLine();
        Console.WriteLine("           * MOTOCICLETAS *      ");
        Console.WriteLine();
        Console.WriteLine("1.- NUEVA MOTOCICLETA");
        Console.WriteLine("2.- MOSTRAR TODAS LAS MOTOCICLETAS");
        Console.WriteLine("3.- BUSCAR MOTOCICLETA");
        Console.WriteLine("4.- BORRAR MOTOCICLETA");
        Console.WriteLine("5.- GENERAR LISTADO DE MOTOCICLETAS - CSV");
        Console.WriteLine("6.- MODIFICACIÓN DATOS");
        Console.WriteLine("A.- Menú iGarage");
    }

    private void MenuProveedor()
    {
        Console.WriteLine();
        Console.WriteLine("           * PROVEEDORES *      ");
        Console.WriteLine();
        Console.WriteLine("1.- VER PROVEEDORES");
        Console.WriteLine("2.- REALIZAR REMESA XML");
        Console.WriteLine("3.- VER DEUDAS");
        Console.WriteLine("A.- Menú iGarage");
        
    }

    //MENU PRINCIPAL
    public void Ejecutar()
    {
        GestorMoto g = new GestorMoto();
        GestorMotosBorradas f = new GestorMotosBorradas();
        GestorCliente c = new GestorCliente();
        GestorProveedor p = new GestorProveedor();
        List<Motocicleta> motocicletas = GestorMoto.CargarMoto();
        List<Motocicleta> motocicletasBorradas = GestorMotosBorradas.CargarMoto();
        List<Cliente> clientes = GestorCliente.CargarClientes();
        List<Proveedor> proveedores = GestorProveedor.CargarProveedor();
        bool salir = false;
        do
        {
            MenuPrincipal();
            switch (Seleccion("Seleccione una opción: "))
            {
                case "1":
                    Motocicleta(motocicletas, clientes, motocicletasBorradas);
                    break;
                case "2":
                    Proveedor(proveedores);
                    break;
                case "3":
                    break;
                case "4":
                    MostrarCliente(clientes);
                    break;
                case "E":
                    Salir(ref salir);
                    break;
                default:
                    Console.WriteLine("Seleccione una de las anteriores");
                    break;
            }
        } while (!salir);
        g.GuardarMoto(motocicletas);
        f.GuardarMoto(motocicletasBorradas);
        c.GuardarCliente(clientes);
        p.GuardarProveedor(proveedores);
    }

    //MENU MOTOS
    private void Motocicleta(List<Motocicleta> motocicletas, List<Cliente> clientes //SEGUNDO  MENU
       , List<Motocicleta> motocicletasBorradas)
    {
        //Console.Clear();
        bool salir = false;
        do
        {
            MenuMoto();
            switch (Seleccion("Seleccione una opción: "))
            {
                case "1":
                    AddMoto(motocicletas, clientes);
                    break;
                case "2":
                    MostrarMotos(motocicletas, motocicletasBorradas);
                    break;
                case "3":
                    BuscarMoto(motocicletas);
                    break;
                case "4":
                    BorrarMoto(motocicletas, motocicletasBorradas);
                    break;
                case "5":
                    MotoXLSX(motocicletas);
                    break;
                case "6":
                    ModificarMoto(motocicletas, clientes);
                    break;
                case "A":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Seleccione una de las anteriores");
                    break;
            }
        } while (!salir);
    }

    //MENU PROVEEDORES
    private void Proveedor(List<Proveedor> proveedores)//TERCER MENU
    {
        //Console.Clear();
        bool salir = false;
        do
        {
            MenuProveedor();
            switch (Seleccion("Seleccione una opción: "))
            {
                case "1":
                    MostrarProveedores(proveedores);
                    break;
                case "2":
                    RealizarRemesa(proveedores);
                    break;
                case "3":
                    VerDeuda(proveedores);
                    break;
                case "A":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Seleccione una de las anteriores");
                    break;
            }
        } while (!salir);
    }

    private string Seleccion(string aviso)
    {
        Console.Write(aviso);
        string inputOpcion = Console.ReadLine().ToUpper().Trim();
        return inputOpcion;
    }

    private bool Salir(ref bool salir)
    {
        string cadena = "Tu Moto, nuestra pasión";
        char caracter = '_';
        int x = 0;
        Console.Clear();

        int posCentrar = (80 - cadena.Length) / 2;

        for (int i = 0; i < posCentrar; i++)
            Console.Write(" ");
        Console.Write(cadena);

        Console.WriteLine();

        while (x < posCentrar)
        {
            Console.Write(" ");
            x++;
        }

        for (int i = 0; i < cadena.Length; i++)
            Console.Write(caracter);
        
        salir = true;
        return salir;
    }

    private void MostrarProveedores(List<Proveedor> proveedores)
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MOSTRAR PROVEEDORES");
        Console.WriteLine();
        int i = 0;
        foreach (Proveedor p in proveedores)
        {
            i += 1;
            Console.Write(i + ".-");
            Console.WriteLine(p);
        }
    }

    private void RealizarRemesa(List<Proveedor> proveedores)
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("PREPARAR REMESA");
        Console.WriteLine();
        float importe;
        bool salir = false;
        string aux, confirmacion;
        Proveedor[] auxiliarRemesa;
        do
        {
            Console.Write("Nombre del proveedor a incluir:");
            aux = Console.ReadLine();
            for (int i = 0; i < proveedores.Count; i++)
            {
                if (proveedores[i].GetNombreCompleto().Contains(aux))
                {
                    Console.WriteLine(proveedores[i]);
                    Console.Write("¿Desea incluir este proveedor? (S/N): ");
                    confirmacion = Console.ReadLine().ToUpper();
                    if (confirmacion == "S")
                    {
                        Console.Write("Importe: ");
                        importe = Convert.ToSingle(Console.ReadLine());
                        //auxiliarRemesa[i].NombreCompleto = proveedores[i].GetNombreCompleto(); 
                    }
                }
            }
        } while (!salir);
    }

    private void VerDeuda(List<Proveedor> proveedores)
    {
        bool deuda = false;
        for (int i = 0; i < proveedores.Count; i++)
        {
            if (proveedores[i].Deuda != 0)
            {
                deuda = true;
                Console.Write((i + 1) + ".- ");
                Console.Write(proveedores[i].GetNombreCompleto() + ": ");
                Console.Write(proveedores[i].Deuda + "€");
                Console.WriteLine();
            }
        }

        if (!deuda)
        {
            Console.WriteLine("No existen deudas actualmente");
        }
    }

    private static void AddMoto(List<Motocicleta> motocicletas,
        List<Cliente> clientes)
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("AÑADIR MOTOCICLETA");
        Console.WriteLine();
        bool competicion = false;
        bool aceptado = false;
        string matricula = "";
       
        Console.Write("Matricula: ");
        matricula = Console.ReadLine().ToUpper();
        matricula = matricula.Replace(" ", String.Empty);
        matricula = matricula.Trim();
        for (int i = 0; i < motocicletas.Count; i++)
        {
            if (matricula == motocicletas[i].GetMatricula())
            {
                Console.WriteLine("Vehículo ya registrado");
                aceptado = true;
            }
        }
        if (!aceptado)
        {


            Console.Write("Modelo: ");
            string modelo = Console.ReadLine().ToUpper();
            modelo = modelo.Replace(" ", String.Empty);
            Console.Write("Marca: ");
            string marca = Console.ReadLine().ToUpper();
            Console.Write("Bastidor: ");
            string bastidor = Console.ReadLine().ToUpper();
            Console.Write("Cilindrada: ");
            int cilindrada = Convert.ToInt32(Console.ReadLine());
            Console.Write("Version: ");
            int version = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kw: ");
            ushort kw = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Codigo Motor: ");
            int codigoMotor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Km: ");
            int km = Convert.ToInt32(Console.ReadLine());
            string op = "";
            do
            {
                Console.Write("1.Crear nuevo cliente / 2.Asignar a Cliente: ");
                op = Console.ReadLine();
            } while (op != "1" && op != "2");

            if (op == "1")
            {
                Console.WriteLine();
                Console.WriteLine("NUEVO CLIENTE");
                Console.WriteLine();
                Console.Write("Nombre Completo: ");
                string nombre = Console.ReadLine().ToUpper();
                Console.Write("Dirección: ");
                string direccion = Console.ReadLine().ToUpper();
                Console.Write("Documento Identidad: ");
                string docID = Console.ReadLine().ToUpper().Trim();
                Console.Write("Telefono: ");
                int telefono = Convert.ToInt32(Console.ReadLine());
                Console.Write("Modo Competicion S/N: ");
                string competicionAux = Console.ReadLine().ToUpper();

                if (competicionAux == "S")
                {
                    competicion = true;
                    Cliente aux = new Cliente(nombre, direccion, docID,
                    competicion, telefono);
                    clientes.Add(aux);
                    Motocicleta motocicleta = new Motocicleta(matricula, modelo, marca, bastidor,
                        cilindrada, version, kw, codigoMotor, km, aux);
                    motocicletas.Add(motocicleta);
                }
                if (competicionAux == "N")
                {
                    competicion = false;
                    Cliente aux = new Cliente(nombre, direccion, docID,
                    competicion, telefono);
                    clientes.Add(aux);
                    Motocicleta motocicleta = new Motocicleta(matricula, modelo, marca, bastidor,
                        cilindrada, version, kw, codigoMotor, km, aux);
                    motocicletas.Add(motocicleta);
                }
            }
            else if (op == "2")
            {
                //Console.Clear();
                bool encontrado = false;
                Console.WriteLine();
                Console.WriteLine("BUSQUEDA CLIENTE");
                Console.WriteLine();
                Console.Write("Nombre Completo: ");
                string buscarNombre = Console.ReadLine().ToLower();

                for (int i = 0; i < clientes.Count; i++)
                {
                    if (clientes[i].GetNombreCompleto().ToLower().Contains(buscarNombre))
                    {
                        Console.WriteLine("Nombre: " + clientes[i].GetNombreCompleto());
                        Console.WriteLine("Documento Identidad: " + clientes[i].GetDocID());
                        Console.WriteLine("Seleccionar este cliente S/N: ");
                        string select = Console.ReadLine().ToUpper();

                        if (select == "S")
                        {
                            Motocicleta motocicleta = new Motocicleta(matricula, modelo,
                                marca, bastidor, cilindrada, version, kw, codigoMotor,
                                km, clientes[i]);
                            motocicletas.Add(motocicleta);
                            encontrado = true;
                        }
                        else if (select == "N")
                        {
                            encontrado = false;
                        }
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("Cliente no encontrado.");
                }
            }
        }
    }

    private void Mostrar(List<Motocicleta> motocicletas)
    {
        int i = 0;
        foreach (Motocicleta m in motocicletas)
        {
            i += 1;
            Console.Write(i + ".- ");
            Console.WriteLine(m);
        }
    }

    private void MostrarCliente(List<Cliente> clientes)
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("CLIENTES");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        foreach (Cliente c in clientes)
        {
            Console.WriteLine(c);
        }
        Console.ForegroundColor = ConsoleColor.Black;
    }

    private void MostrarMotos(List<Motocicleta> motocicletas,
        List<Motocicleta> motocicletasBorradas)
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MOSTRAR MOTOS");
        Console.WriteLine();
        int i = 0;
        Console.Write("¿Visualizar motos borras? (S/N)? ");
        string deseoVisualizar = Console.ReadLine().ToUpper();
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        if (deseoVisualizar == "S")
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Mostrar(motocicletas);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Mostrar(motocicletasBorradas);
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (Motocicleta m in motocicletas)
            {
                i += 1;
                Console.Write(i + ".- ");
                Console.WriteLine(m);
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }

    private void BuscarMoto(List<Motocicleta> motocicletas)
    {
        //Console.Clear();
        bool buscar = false;
        Console.WriteLine();
        Console.WriteLine("BUSQUEDA MOTO");
        Console.WriteLine();
        Console.WriteLine("1.- Búsqueda por matrícula");
        Console.WriteLine("2.- Búsqueda general");
        string input = Console.ReadLine();
        if (input == "1")
        {
            Console.Write("Matricula: ");
            string busquedaMa = Console.ReadLine().ToUpper();
            for (int i = 0; i < motocicletas.Count; i++)
            {
                if (motocicletas[i].GetMatricula() == busquedaMa)
                {
                    buscar = true;
                    Console.WriteLine("¿Visualizar propietario?: (S/N)");
                    string conf = Console.ReadLine().ToUpper();
                    if (conf == "S")
                    {
                        Console.WriteLine(motocicletas[i]);
                        Console.WriteLine(motocicletas[i].GetCliente());
                    }
                    else if(conf == "N")
                    {
                        Console.WriteLine(motocicletas[i]);
                    }
                }
            }
            if (!buscar)
            {
                Console.WriteLine("No encontrado");
            }
        }
        else if (input == "2")
        {
            for (int i = 0; i < motocicletas.Count; i++)
            {
                Console.Write(i + 1);
                Console.Write(".- " + motocicletas[i]);
            }
            Console.Write("Seleccione el número ");
            int numeroBus = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine(motocicletas[numeroBus]);
            Console.WriteLine(motocicletas[numeroBus].GetCliente());
        }
        
    }

    private void BorrarMoto(List<Motocicleta> motocicletas,
        List<Motocicleta> motocicletasBorradas)
    {

        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("BORRAR DATOS");
        Console.WriteLine();
        Mostrar(motocicletas);
        Console.Write("Introduzca el número del índice a borrar: ");
        int posicionBorrar = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine(motocicletas[posicionBorrar]);
        Console.Write("¿Eliminar? (S/N): ");
        string confirmacion = Console.ReadLine().ToUpper();
        if (confirmacion == "S")
        {
            motocicletasBorradas.Add(motocicletas[posicionBorrar]);
            motocicletas.RemoveAt(posicionBorrar);
            Console.WriteLine("Moto eliminada..");
        }
        else
        {
            Console.WriteLine("Acción no completada.");
        }
       

    }

    public void MotoXLSX(List<Motocicleta> myListMotos)
    {
        try
        {
            StreamWriter datosEscribir = File.CreateText("MotosBBDD.csv");
            datosEscribir.Write("MATRICULA;MODELO;MARCA;BASTIDOR;CILINDRADA;" +
                "VERSION;KW;CODIGO MOTOR; KM" + "\n") ;
            foreach (Motocicleta m in myListMotos)
            {
                datosEscribir.Write(m.GetMatricula() + ";" + m.GetModelo() + ";"
                    + m.GetMarca() + ";" + m.GetBastidor() + ";" + m.GetCilindrada() + ";"
                    + m.GetVersion() + ";" + m.GetKw() + ";" + m.GetCodigoMotor() + ";"
                    + m.GetKm() + "\n" /*+ ";" + m.GetCliente().GetNombreCompleto() + ";"
                    + m.GetCliente().GetDireccion() + ";" + m.GetCliente().GetDocID() + ";"
                    + m.GetCliente().GetCompeticion() + ";" + m.GetCliente().GetTelefono() + "\n"*/);
            }
            datosEscribir.Close();
            Console.WriteLine();
            Console.WriteLine("Fichero generado con éxito");
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

        private void ModificarMoto(List<Motocicleta> motocicletas, List<Cliente> clientes)
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MODIFICAR DATOS");
        Console.WriteLine();
        Mostrar(motocicletas);
        Console.Write("Introduzca el número del índice a modificar: ");
        int posicionModificar = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(motocicletas[posicionModificar]);
        Console.WriteLine(motocicletas[posicionModificar].GetCliente());
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Indique el campo completo a modificar: ");
        string campoModificar = Console.ReadLine().ToLower().Trim();
        string aux;
        int auxNum;
        ushort auxShort;
        if (campoModificar == "matricula")
        {
            Console.Write("Nueva matricula: ");
            aux = Console.ReadLine();
            motocicletas[posicionModificar].SetMatricula(aux);
        }
        else if (campoModificar == "modelo")
        {
            Console.Write("Nuevo modelo: ");
            aux = Console.ReadLine();
            motocicletas[posicionModificar].SetModelo(aux);
        }
        else if (campoModificar == "marca")
        {
            Console.Write("Nueva marca: ");
            aux = Console.ReadLine();
            motocicletas[posicionModificar].SetMarca(aux);
        }
        else if (campoModificar == "bastidor")
        {
            Console.Write("Nuevo bastidor: ");
            aux = Console.ReadLine();
            motocicletas[posicionModificar].SetBastidor(aux);
        }
        else if (campoModificar == "cilindrada")
        {
            Console.Write("Nueva cilindrada: ");
            aux = Console.ReadLine();
            try
            {
                auxNum = Convert.ToInt32(aux);
                motocicletas[posicionModificar].SetCilindrada(auxNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Acción no completada, " + ex.Message);
            }
        }
        else if (campoModificar == "version")
        {
            Console.Write("Nueva versión: ");
            aux = Console.ReadLine();
            try
            {
                auxNum = Convert.ToInt32(aux);
                motocicletas[posicionModificar].SetVersion(auxNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Acción no completada, " + ex.Message);
            }
        }
        else if (campoModificar == "kw")
        {
            Console.Write("Nuevo kw: ");
            aux = Console.ReadLine();
            try
            {
                auxShort = Convert.ToUInt16(aux);
                motocicletas[posicionModificar].SetKw(auxShort);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Acción no completada, " + ex.Message);
            }
        }
        else if (campoModificar == "codigomotor" || campoModificar == "codigo motor" )
        {
            Console.Write("Nuevo código: ");
            aux = Console.ReadLine();
            try
            {
                auxNum = Convert.ToInt32(aux);
                motocicletas[posicionModificar].SetCodigoMotor(auxNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Acción no completada, " + ex.Message);
            }
        }
        else if (campoModificar == "km")
        {
            Console.Write("Nuevos km: ");
            aux = Console.ReadLine();
            try
            {
                auxNum = Convert.ToInt32(aux);
                motocicletas[posicionModificar].SetKm(auxNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Acción no completada, " + ex.Message);
            }
        }
        else if (campoModificar == "cliente")
        {
            Cliente clienteAux = new Cliente
                (motocicletas[posicionModificar].GetCliente().GetNombreCompleto(),
                motocicletas[posicionModificar].GetCliente().GetDireccion(),
                motocicletas[posicionModificar].GetCliente().GetDocID(),
                motocicletas[posicionModificar].GetCliente().GetCompeticion(),
                motocicletas[posicionModificar].GetCliente().GetTelefono());
            Console.Write("Indicar campo completo del cliente a modificar: ");
            aux = Console.ReadLine().ToLower();
            if (aux == "nombre")
            {
                Console.Write("Nuevo nombre: ");
                aux = Console.ReadLine().ToUpper();
                clienteAux.SetNombreCompleto(aux);
            }
        }
    }
}