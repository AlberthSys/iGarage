class Persona
{
    protected string nombreCompleto;
    protected string direccion;
    protected string docID;

    public Persona(string nombreCompleto, string direccion, string docID)
    {
        this.nombreCompleto = nombreCompleto;
        this.direccion = direccion;
        this.docID = docID;
    }

    public string GetNombreCompleto()
    {
        return nombreCompleto;
    }

    public string GetDireccion()
    {
        return direccion;
    }

    public string GetDocID()
    {
        return docID;
    }

    public void SetNombreCompleto(string nombreCompleto)
    {
        this.nombreCompleto = nombreCompleto;
    }

    public void SetDireccion(string direccion)
    {
        this.direccion = direccion;
    }

    public void SetDocID(string docID)
    {
        this.docID = docID;
    }

    public override string ToString()
    {
        return "Nombre: " + nombreCompleto + "\n" +
            "Direccion: " + direccion + "\n" +
            "DocID: " + docID + "\n";
    }
}