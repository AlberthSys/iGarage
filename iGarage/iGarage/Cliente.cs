class Cliente : Persona
{
    private int telefono;
    private bool competicion;

    public Cliente(string nombreCompleto, string direccion, string docID,
        bool competicion, int telefono)
        :base(nombreCompleto,direccion,docID)
    {
        this.competicion = competicion;
        this.telefono = telefono;
    }

    public int GetTelefono()
    {
        return telefono;
    }

    public bool GetCompeticion()
    {
        return competicion;
    }

    public void SetTelefono(int telefono)
    {
        this.telefono = telefono;
    }

    public void SetCompeticion(bool competicion)
    {
        this.competicion = competicion;
    }

    public override string ToString()
    {
        return base.ToString() + ("Teléfono: " + telefono) + "\n" +
            (competicion ? "Racing" : "Confort") + "\n";
    }
}