class Cliente : Persona
{
    private bool competicion;

    public Cliente(string nombreCompleto, string direccion, string docID,
        bool competicion)
        :base(nombreCompleto,direccion,docID)
    {
        this.competicion = competicion;
    }

    public bool GetCompeticion()
    {
        return competicion;
    }

    public void SetCompeticion(bool competicion)
    {
        this.competicion = competicion;
    }

    public override string ToString()
    {
        if (competicion)
        {
            return base.ToString() + "Race";
        }
        else
        {
            return base.ToString();
        }
    }
}