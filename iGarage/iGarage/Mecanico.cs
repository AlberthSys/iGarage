class Mecanico : Persona
{
    private int telefono;
    private int horasContratadas;

    public Mecanico(string nombreCompleto, string direccion, string docID,
        int horasContratadas, int telefono)
        : base(nombreCompleto, direccion, docID)
    {
        this.horasContratadas = horasContratadas;
        this.telefono = telefono;
    }

    public int GetTelefono()
    {
        return telefono;
    }

    public int GetHorasContratadas()
    {
        return horasContratadas;
    }

    public void SetTelefono(int telefono)
    {
        this.telefono = telefono;
    }

    public void SetHorasContratadas(int horasContratadas)
    {
        this.horasContratadas = horasContratadas;
    }

    public override string ToString()
    {
        return base.ToString() + ("Teléfono: " + telefono) + "\n";
    }
}