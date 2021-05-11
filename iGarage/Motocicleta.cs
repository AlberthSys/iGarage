class Motocicleta
{
    private string modelo;
    private string marca;
    private string bastidor;
    private int cilindrada;
    private int version;
    private ushort kw;
    private int codigoMotor;
    private int km;
    Cliente cliente;


    public Motocicleta(string modelo, string marca, string bastidor,
        int cilindrada, int version, ushort kw, int codigoMotor, int km,
        Cliente cliente)
    {
        this.modelo = modelo;
        this.marca = marca;
        this.bastidor = bastidor;
        this.cilindrada = cilindrada;
        this.version = version;
        this.kw = kw;
        this.codigoMotor = codigoMotor;
        this.km = km;
        this.cliente = cliente;
    }

    public string GetModelo()
    {
        return modelo;
    }

    public string GetMarca()
    {
        return marca;
    }

    public string GetBastidor()
    {
        return bastidor;
    }

    public int GetCilindrada()
    {
        return cilindrada;
    }

    public int GetVersion()
    {
        return version;
    }

    public ushort GetKw()
    {
        return kw;
    }

    public int GetCodigoMotor()
    {
        return codigoMotor;
    }

    public int GetKm()
    {
        return km;
    }

    public Cliente GetCliente()
    {
        return cliente;
    }

    public void SetModelo(string modelo)
    {
        this.modelo = modelo;
    }

    public void SetMarca(string marca)
    {
        this.marca = marca;
    }

    public void SetBastidor(string bastidor)
    {
        this.bastidor = bastidor;
    }

    public void SetCilindrada(int cilindrada)
    {
        this.cilindrada = cilindrada;
    }

    public void SetVersion(int version)
    {
        this.version = version;
    }

    public void SetKw(ushort kw)
    {
        this.kw = kw;
    }

    public void SetCodigoMotor(int codigoMotor)
    {
        this.codigoMotor = codigoMotor;
    }

    public void SetKm(int km)
    {
        this.km = km;
    }

    public void SetCliente(Cliente cliente)
    {
        this.cliente = cliente;
    }

    public override string ToString()
    {
        return "Modelo: " + modelo + "\n" +
            "Marca" + marca + "\n" +
            "Bastidor: " + bastidor + "\n" +
            "Cilindrada: " + cilindrada + "\n" +
            "Version: " + version + "\n" +
            "KW: " + kw + "\n" +
            "Código Motor: " + codigoMotor + "\n" +
            cliente.ToString();
    }
}