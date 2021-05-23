using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;

class Proveedor: Persona
{ 
    string numeroCuenta;
    float deuda;
    public Proveedor(string nombreCompleto, string direccion, string docID,
        string numeroCuenta, float deuda)
        : base(nombreCompleto, direccion, docID)
    {
        this.numeroCuenta = numeroCuenta;
        this.deuda = deuda;
    }

    //public string NumeroCuenta { get; set; }

    public string NumeroCuenta
    {
        get => numeroCuenta;
        set => numeroCuenta = value;
    }

    public float Deuda
    {
        get => deuda;
        set => deuda = value;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public void toXML()
    {
        XmlSerializer xs = new XmlSerializer(typeof(Proveedor));
        TextWriter txt = new StreamWriter(@"proveedor.xml");
        xs.Serialize(txt, this);
        txt.Close();
    }
}