using iTextSharp.text;
using iTextSharp.text.pdf;
using Proyecto1_Lenguajes.Models.Domain;
using System.IO;
using System.Reflection.Metadata;

namespace Proyecto1_Lenguajes.Models.Utility
{
    public class PDF
    {
        public void GenerarPdfPerParking(string nombre, string message, List<VehiclePerParking> lista, List<UsersPerRole> lista2, double income)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("wwwroot\\assets\\img\\" + nombre + ".pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.ORANGE);
            title.Add("Smart Parking Reports!!");
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Chunk("\n"));

            Paragraph title23 = new Paragraph();
            title23.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title23.Add(message);
            title23.Alignment = Element.ALIGN_CENTER;
            doc.Add(title23);

            doc.Add(new Chunk("\n"));
            Paragraph title2 = new Paragraph();
            title2.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title2.Add("Vehicles per parking lot!!");
            title2.Alignment = Element.ALIGN_CENTER;
            doc.Add(title2);
            doc.Add(new Chunk("\n"));
            for (int i = 0; i < lista.Count; i++)
            {
                doc.Add(new Paragraph("Parking Lot: " + lista[i].NameParkingLot + "  Vehicles Quantity: " + lista[i].VehiclesQuantity + ".")
                { Alignment = Element.ALIGN_CENTER });
            }
            doc.Add(new Chunk("\n"));
            Paragraph title3 = new Paragraph();
            title3.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title3.Add("Users per role!!");
            title3.Alignment = Element.ALIGN_CENTER;
            doc.Add(title3);
            doc.Add(new Chunk("\n"));


            for (int i = 0; i < lista2.Count; i++)
            {
                doc.Add(new Paragraph("Role : " + lista2[i].RoleType + "  Users quantity: " + lista2[i].Users + ".")
                { Alignment = Element.ALIGN_CENTER });
            }
            doc.Add(new Chunk("\n"));
            Paragraph title4 = new Paragraph();
            title4.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title4.Add("Income!!");
            title4.Alignment = Element.ALIGN_CENTER;
            doc.Add(title4);
            doc.Add(new Chunk("\n"));
            doc.Add(new Paragraph("Income generated: " + income) { Alignment = Element.ALIGN_CENTER });
            //  iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("IMAGEN/pl.JPG");
            //  image1.ScalePercent(50f);
            //  image1.ScaleAbsoluteWidth(480);
            //  image1.ScaleAbsoluteHeight(270);
            //  doc.Add(image1);
            doc.Close();
        }



        public void GenerateBill(string name, string usuario, string spot, string parking, string rate, string date)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream(name + ".pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.ORANGE);
            title.Add("Smart Parking Reports!!");
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Chunk("\n"));

            Paragraph title23 = new Paragraph();
            title23.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title23.Add("Bill");
            title23.Alignment = Element.ALIGN_CENTER;
            doc.Add(title23);

            doc.Add(new Chunk("\n"));
            Paragraph title2 = new Paragraph();
            title2.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title2.Add("User!!");
            title2.Alignment = Element.ALIGN_CENTER;

            doc.Add(new Paragraph(name) { Alignment = Element.ALIGN_CENTER });

            doc.Add(new Chunk("\n"));

            Paragraph title3 = new Paragraph();
            title3.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title3.Add("Spot!!");
            title3.Alignment = Element.ALIGN_CENTER;
            doc.Add(title3);
            doc.Add(new Chunk("\n"));



            doc.Add(new Paragraph(spot)
            { Alignment = Element.ALIGN_CENTER });

            doc.Add(new Chunk("\n"));
            Paragraph title4 = new Paragraph();
            title4.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title4.Add("Parking lot!!");
            title4.Alignment = Element.ALIGN_CENTER;
            doc.Add(title4);
            doc.Add(new Chunk("\n"));
            doc.Add(new Paragraph(parking) { Alignment = Element.ALIGN_CENTER });


            Paragraph title35 = new Paragraph();
            title35.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title35.Add("Rate!!");
            title35.Alignment = Element.ALIGN_CENTER;
            doc.Add(title35);
            doc.Add(new Chunk("\n"));

            doc.Add(new Paragraph(rate) { Alignment = Element.ALIGN_CENTER });

            Paragraph title46 = new Paragraph();
            title46.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            title46.Add("Date!!");
            title46.Alignment = Element.ALIGN_CENTER;
            doc.Add(title46);
            doc.Add(new Chunk("\n"));

            doc.Add(new Paragraph(date) { Alignment = Element.ALIGN_CENTER });


            doc.Close();

        }
    }
}


