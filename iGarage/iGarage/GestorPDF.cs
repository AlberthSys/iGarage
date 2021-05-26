using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

class GestorPDF
{
    public GestorPDF(Motocicleta motocicleta, Mecanico mecanico, Cliente cliente,
        string nombrePDF, string problema, int numeroOrden)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Document d = new Document(iTextSharp.text.PageSize.LETTER, 10, 10,
            10, 10);
        PdfWriter p = PdfWriter.GetInstance(d, new FileStream(nombrePDF +".pdf",
            FileMode.Create));
        d.Open();
        BaseFont b = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250,
            BaseFont.EMBEDDED);
        Font fontMecanico = new Font(b, 10, 1, BaseColor.ORANGE);
        Font fontMoto = new Font(b, 10, 1, BaseColor.BLUE);
        Font fontTIT = new Font(b, 12, 1, BaseColor.GREEN);
        Font fontTITULO = new Font(b, 25, 1, BaseColor.RED);
        Font fontOrden = new Font(b, 12, 1, BaseColor.BLUE);
        Font fontProblema = new Font(b, 10, 1, BaseColor.BLACK);
        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("logo.jpg");
        imagen.BorderWidth = 0;
        imagen.Alignment = Element.ALIGN_CENTER;
        float percentage = 0.0f;
        percentage = 150 / imagen.Width;
        imagen.ScalePercent(percentage * 100);
        string iGarage = "iGarage";
        d.Add(new Paragraph("                                     " + iGarage + "\n", fontTITULO));
        d.Add(new Paragraph("                                     " +"-----------" + "\n", fontTITULO));
        d.Add(new Paragraph("\n"));
        d.Add(new Paragraph("Numero Orden: " + numeroOrden + "\n", fontOrden));
        d.Add(new Paragraph("\n"));
        d.Add(new Paragraph("MOTOCICLETA"+ "\n", fontTIT));
        d.Add(new Paragraph(motocicleta.ToString(), fontMoto));
        d.Add(new Paragraph("\n"));
        d.Add(new Paragraph("CLIENTE" + "\n", fontTIT));
        d.Add(new Paragraph(cliente.ToString(), fontMoto));
        d.Add(new Paragraph("\n"));
        d.Add(new Paragraph("MECANICO" + "\n", fontTIT));
        d.Add(new Paragraph(mecanico.ToString(), fontMecanico));
        d.Add(new Paragraph("\n"));
        d.Add(new Paragraph("PROBLEMA" + "\n", fontTIT));
        d.Add(new Paragraph(problema, fontProblema));
        d.Add(imagen);
        d.Close();
        p.Close();
    }
}
