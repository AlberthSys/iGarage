using System;
using System.Diagnostics.CodeAnalysis;

class Proveedor: Persona
{ 
    string numeroCuenta;

    public Proveedor(string nombreCompleto, string direccion, string docID,
        string numeroCuenta)
        : base(nombreCompleto, direccion, docID)
    {
        this.numeroCuenta = numeroCuenta;
    }

    //public string NumeroCuenta { get; set; }

    public string NumeroCuenta
    {
        get => numeroCuenta;
        set => numeroCuenta = value;
    }

    public override string ToString()
    {
        return base.ToString() + "Numero Cuenta Bancaria: " + numeroCuenta;
    }
}