using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;

class Proveedor: Persona
{ 
    string numeroCuenta;
   // int deuda;
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

    public void toXML()
    {
        XmlSerializer xs = new XmlSerializer(typeof(Proveedor));
        TextWriter txt = new StreamWriter(@"proveedor.xml");
        xs.Serialize(txt, this);
        txt.Close();
    }
}