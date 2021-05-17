using System;
using System.Collections.Generic;

class GestorTaller
{
    private void MenuPrincipal()
    {
        Console.WriteLine();
        Console.WriteLine("        *------ iGarage ------*       ");
        Console.WriteLine();
        Console.WriteLine("1.- MOTOCICLETAS");
        Console.WriteLine("2.- GESTIÓN CLIENTES.");
        Console.WriteLine("3.- GESTIÓN DE FLUJO DE TESORERIA.");
        Console.WriteLine("4.- ORDEN DE REPARACIÓN.");
        Console.WriteLine("E.- SALIR.");
        Console.WriteLine();
    }

    private void MenuMoto()
    {
        Console.WriteLine();
        Console.WriteLine("     * MOTOCICLETAS *      ");
        Console.WriteLine();
        Console.WriteLine("1.- NUEVA MOTOCICLETA");
        Console.WriteLine("2.- MOSTRAR MOTOCICLETAS");
        Console.WriteLine("3.- BUSCAR MOTOCICLETA");
        Console.WriteLine("4.- BORRAR MOTOCICLETA");
        Console.WriteLine("5.- GENERAR LISTADO DE MOTOCICLETAS - PDF");
        Console.WriteLine("6.- GENERAR LISTADO DE MOTOCICLETAS - XLSX");
        Console.WriteLine("7.- GENERAR INFORME");
        Console.WriteLine("8.- CONFIGURACIÓN");
        Console.WriteLine("A.- Menú iGarage");
    }

    public void Ejecutar() //MENU PRINCIPAL
    {
        GestorMoto g = new GestorMoto();
        GestorCliente c = new GestorCliente();
        List<Motocicleta> motocicletas = GestorMoto.CargarMoto();
        List<Cliente> clientes = GestorCliente.CargarClientes();
        bool salir = false;
        do
        {
            MenuPrincipal();
            switch (Seleccion("Seleccione una opción: "))
            {
                case "1":
                    Motocicleta(motocicletas, clientes);
                    break;
                case "2":
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
        c.GuardarCliente(clientes);
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

    private void Motocicleta(List<Motocicleta> motocicletas, List<Cliente> clientes)//SEGUNDO  MENU
    {
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
                    Mostrar(motocicletas, clientes);
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

    private static void AddMoto(List<Motocicleta> motocicletas,
        List<Cliente> clientes)
    {
        bool competicion = false;
        Console.WriteLine();
        Console.WriteLine("*AÑADIR MOTOCICLETA*");
        Console.WriteLine();
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine().ToUpper();
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
        } while (op != "1" || op != "2" && op == "");

        if (op == "1")
        {
            Console.WriteLine();
            Console.WriteLine("NUEVO CLIENTE");
            Console.Write("Nombre Completo: ");
            string nombre = Console.ReadLine().ToUpper();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Documento Identidad: ");
            string docID = Console.ReadLine().ToUpper().Trim();
            Console.Write("Modo Competicion S/N: ");
            string competicionAux = Console.ReadLine().ToUpper();
            
            if (competicionAux == "S")
            {
                competicion = true;
                Cliente aux = new Cliente(nombre, direccion, docID,
                competicion);
                clientes.Add(aux);
                Motocicleta motocicleta = new Motocicleta(modelo, marca, bastidor,
                    cilindrada, version, kw, codigoMotor, km, aux);
                motocicletas.Add(motocicleta);
            }
            if (competicionAux == "N")
            {
                competicion = false;
                Cliente aux = new Cliente(nombre, direccion, docID,
                competicion);
                clientes.Add(aux);
                Motocicleta motocicleta = new Motocicleta(modelo, marca, bastidor,
                    cilindrada, version, kw, codigoMotor, km, aux);
                motocicletas.Add(motocicleta);
            }
        }
        if (op == "2")
        {
            bool encontrado = false;
            Console.WriteLine();
            Console.WriteLine("BUSQUEDA CLIENTE");
            Console.Write("Nombre Completo: ");
            string buscarNombre = Console.ReadLine().ToLower();

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].GetNombreCompleto().ToLower().Contains(buscarNombre))
                {
                    Console.WriteLine("Nombre: " + clientes[i].GetNombreCompleto());
                    Console.WriteLine("Direccion: " + clientes[i].GetDireccion());
                    Console.WriteLine("Documento Identidad: " + clientes[i].GetDocID());
                    Console.WriteLine("Seleccionar este cliente S/N: ");
                    string select = Console.ReadLine().ToUpper();

                    if (select == "S")
                    {
                        Motocicleta motocicleta = new Motocicleta(modelo, marca, bastidor,
                            cilindrada, version, kw, codigoMotor, km, clientes[i]);
                        motocicletas.Add(motocicleta);
                    }
                    else if(select == "N")
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

    private void Mostrar(List<Motocicleta> motocicletas, List<Cliente> clientes)
    {
        foreach (Motocicleta m in motocicletas)
        {
            Console.WriteLine(m);
        }
        Console.WriteLine();

        foreach (Cliente c in clientes)
        {
            Console.WriteLine(c);
        }
    }

}