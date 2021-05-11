using System;

class GestorTaller
{
    public void MenuPrincipal()
    {

        Console.WriteLine("*------ iGarage ------*");
        Console.WriteLine("1.- MOTOCICLETAS");
        Console.WriteLine("2.- GESTIÓN CLIENTES.");
        Console.WriteLine("3.- GESTIÓN DE FLUJO DE TESORERIA.");
        Console.WriteLine("4.- ORDEN DE REPARACIÓN.");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
        Console.WriteLine();
    }

    public void MenuMoto()
    {
        Console.WriteLine("     * MOTOCICLETAS *      ");
        Console.WriteLine();
        Console.WriteLine("1.- NUEVA MOTOCICLETA");
        Console.WriteLine("2.- BUSCAR MOTOCICLETA");
        Console.WriteLine("3.- BORRAR MOTOCICLETA");
        Console.WriteLine("4.- GENERAR LISTADO DE MOTOCICLETAS - PDF");
        Console.WriteLine("5.- GENERAR LISTADO DE MOTOCICLETAS - XLSX");
        Console.WriteLine("6.- GENERAR INFORME");
        Console.WriteLine("7.- CONFIGURACIÓN");
    }
}