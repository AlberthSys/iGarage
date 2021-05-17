class Horquilla
{
    private int compresion;
    private int extension;
    private int precargaMuelle;
    private int SAGE;
    private int alturaMontaje;
    Motocicleta motocicleta;

    public Horquilla(int compresion, int extension, int precargaMuelle,
        int SAGE, int alturaMontaje, Motocicleta motocicleta)
    {
        this.compresion = compresion;
        this.extension = extension;
        this.precargaMuelle = precargaMuelle;
        this.SAGE = SAGE;
        this.alturaMontaje = alturaMontaje;
        this.motocicleta = motocicleta;
    }

    public Horquilla horquilla { get; set; }

    public int GetCompresion()
    {
        return compresion;
    }

    public int GetExtension()
    {
        return extension;
    }

    public int GetPrecargaMuelle()
    {
        return precargaMuelle;
    }

    public int GetSAGE()
    {
        return SAGE;
    }

    public int GetAlturaMontaje()
    {
        return alturaMontaje;
    }

    public Motocicleta GetMotocicleta()
    {
        return motocicleta;
    }

    public void SetCompresion(int compresion)
    {
        this.compresion = compresion;
    }

    public void SetCExtension(int extension)
    {
        this.extension = extension;
    }

    public void SetPrecargaMuelle(int precargaMuelle)
    {
        this.precargaMuelle = precargaMuelle;
    }

    public void SetSAGE(int SAGE)
    {
        this.SAGE = SAGE;
    }

    public void SetAlturaMontaje(int alturaMontaje)
    {
        this.alturaMontaje = alturaMontaje;
    }

    public void SetMotocicleta(Motocicleta motocicleta)
    {
        this.motocicleta = motocicleta;
    }


    public override string ToString()
    {
        return "Compresión: " + compresion + "\n" +
            "Extensión: " + extension + "\n" +
            "Precarga del Muelle: " + precargaMuelle + "\n" +
            "SAGE: " + SAGE + "\n" +
            "Altura montaje: " + alturaMontaje +"\n" + motocicleta.ToString();
    }
}