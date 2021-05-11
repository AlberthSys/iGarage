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

    public string Nombre { get; set; }

    public string Direccion { get; set; }

    public string DocID { get; set; }

    public override string ToString()
    {
        return "Nombre: " + nombreCompleto + "\n" +
            "Direccion: " + direccion + "\n" +
            "DocID: " + docID + "\n";
    }
}