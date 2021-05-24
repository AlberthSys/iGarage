class OrdenReparacion
{
    int numeroOrden;
    Cliente cliente;
    Mecanico mecanico;
    Motocicleta motocicleta;
    string problema;

    public OrdenReparacion(int numeroOrden, Cliente cliente, Mecanico mecanico,
        Motocicleta motocicleta, string problema)
    {
        this.numeroOrden = numeroOrden;
        this.cliente = cliente;
        this.mecanico = mecanico;
        this.motocicleta = motocicleta;
        this.problema = problema;
    }

    public int GetNumeroOrden()
    {
        return numeroOrden;
    }

    public Cliente GetCliente()
    {
        return cliente;
    }

    public Mecanico GetMecanico()
    {
        return mecanico;
    }

    public Motocicleta GetMotocicleta()
    {
        return motocicleta;
    }

    public string GetProblema()
    {
        return problema;
    }

    public void SetNumeroOrden(int numeroOrden)
    {
        this.numeroOrden = numeroOrden;
    }

    public void SetCliente(Cliente cliente)
    {
        this.cliente = cliente;
    }

    public void SetMecanico(Mecanico mecanico)
    {
        this.mecanico = mecanico;
    }

    public void SetMotocicleta(Motocicleta motocicleta)
    {
        this.motocicleta = motocicleta;
    }

    public void SetProblema(string problema)
    {
        this.problema = problema;
    }

    public override string ToString()
    {
        return "Orden: " + numeroOrden + "\n"
            + "Cliente: " + cliente.GetNombreCompleto() + "\n"
            + "Mecanico: " + mecanico.GetNombreCompleto() + "\n"
            + motocicleta.ToString() +
            "Problema: " + problema + "\n";
    }
}