using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Ofthalmiatrio
{
    internal class PdfMaker
    {
        static Aspose.Pdf.Text.TextState stoixeiats;
        static Aspose.Pdf.Text.TextState generalts;
        static Aspose.Pdf.Text.TextState textts;
        static PdfMaker()
        {

            var font = FontRepository.FindFont("Times New Roman");
            stoixeiats = new Aspose.Pdf.Text.TextState();
            generalts = new Aspose.Pdf.Text.TextState();
            textts = new Aspose.Pdf.Text.TextState();



            stoixeiats.Font = font;
            stoixeiats.Font.IsEmbedded = true;
            stoixeiats.FontSize = 14;
            stoixeiats.FontStyle = FontStyles.Bold;

            generalts.FontSize = 18;
            generalts.Font = font;
            generalts.Font.IsEmbedded = true;
            generalts.FontStyle = FontStyles.Italic;

            textts.FontSize = 12;
            textts.Font = font;
            textts.Font.IsEmbedded = true;
        }
        public static void getCustomer(string path_name, SQLiteDataReader customerCode, SQLiteDataReader productCode)
        {
            //Getting information
            customerCode.Read();
            productCode.Read();
            
            
            // Creating a doc 
            Document doc = new Document();


            // Adding header
            Aspose.Pdf.Text.TextFragment fragment = new Aspose.Pdf.Text.TextFragment();
            Aspose.Pdf.Text.TextSegment inro = new Aspose.Pdf.Text.TextSegment("Data of Customer :                      Ntolias Electronics\n");
            Aspose.Pdf.Text.TextSegment stoixeia;

            stoixeia = new Aspose.Pdf.Text.TextSegment($"\nCustomer : {customerCode["CustomerCode"].ToString()}");

            Aspose.Pdf.Text.TextSegment Receipt = new Aspose.Pdf.Text.TextSegment("\n\n\nReceipt :\n");

            //creating the pages
            Aspose.Pdf.Page page = doc.Pages.Add();
            stoixeia.TextState = stoixeiats;
            inro.TextState = generalts;
            Receipt.TextState = generalts;
            fragment.Segments.Add(inro);
            fragment.Segments.Add(stoixeia);
            fragment.Segments.Add(Receipt);
            Aspose.Pdf.Table data = new Aspose.Pdf.Table();
            data.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black));
            data.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 1f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black));

            //adding the rows

            data.DefaultCellTextState = textts;
            Aspose.Pdf.Row row = data.Rows.Add();
            row.Cells.Add("Customer:");
            row.Cells.Add($" {customerCode["CustomerCode"].ToString()}");

            Aspose.Pdf.Row row2 = data.Rows.Add();
            row2.Cells.Add("Name:");
            row2.Cells.Add($" {customerCode["CustomerName"].ToString()}");

            Aspose.Pdf.Row row3 = data.Rows.Add();
            row3.Cells.Add("Product:");
            row3.Cells.Add($" {customerCode["ProductCode"].ToString()}");

            Aspose.Pdf.Row row4 = data.Rows.Add();
            row4.Cells.Add("Product Quantity:");
            row4.Cells.Add($" {customerCode["Quantity"].ToString()}");

            Aspose.Pdf.Row row5 = data.Rows.Add();
            row5.Cells.Add("Product Price:");
            row5.Cells.Add($" {productCode["Price"].ToString()}");

            decimal price = Convert.ToDecimal(productCode["Price"]);
            decimal quantity = Convert.ToDecimal(customerCode["Quantity"]);
            decimal totalPrice = price * quantity;

            Aspose.Pdf.Row row6 = data.Rows.Add();
            row6.Cells.Add("Total Price:");
            row6.Cells.Add($" {totalPrice}");

            //Aspose.Pdf.Row row6 = data.Rows.Add();
            //row6.Cells.Add("Total Price:");
            //row6.Cells.Add($"{productCode["Price"]*customerCode["Quantity"].ToString()}");


            page.Paragraphs.Add(fragment);
            page.Paragraphs.Add(data);





            //adding the segments into the page

            doc.Save(path_name);


        }

        public static void getProvider(string path_name, SQLiteDataReader providerCode, SQLiteDataReader productCode)
        {
            //Getting information
            providerCode.Read();
            productCode.Read();


            // Creating a doc 
            Document doc = new Document();


            // Adding header
            Aspose.Pdf.Text.TextFragment fragment = new Aspose.Pdf.Text.TextFragment();
            Aspose.Pdf.Text.TextSegment inro = new Aspose.Pdf.Text.TextSegment("Data of Provider :                      Ntolias Electronics\n");
            Aspose.Pdf.Text.TextSegment stoixeia;

            stoixeia = new Aspose.Pdf.Text.TextSegment($"\nProvider : {providerCode["ProviderCode"].ToString()}");

            Aspose.Pdf.Text.TextSegment Receipt = new Aspose.Pdf.Text.TextSegment("\n\n\nReceipt :\n");

            //creating the pages
            Aspose.Pdf.Page page = doc.Pages.Add();
            stoixeia.TextState = stoixeiats;
            inro.TextState = generalts;
            Receipt.TextState = generalts;
            fragment.Segments.Add(inro);
            fragment.Segments.Add(stoixeia);
            fragment.Segments.Add(Receipt);
            Aspose.Pdf.Table data = new Aspose.Pdf.Table();
            data.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black));
            data.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 1f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black));

            //adding the rows

            data.DefaultCellTextState = textts;
            Aspose.Pdf.Row row = data.Rows.Add();
            row.Cells.Add("Provider:");
            row.Cells.Add($" {providerCode["ProviderCode"].ToString()}");

            Aspose.Pdf.Row row2 = data.Rows.Add();
            row2.Cells.Add("Name:");
            row2.Cells.Add($" {providerCode["ProviderName"].ToString()}");

            Aspose.Pdf.Row row3 = data.Rows.Add();
            row3.Cells.Add("Product:");
            row3.Cells.Add($" {providerCode["ProductCode"].ToString()}");

            Aspose.Pdf.Row row4 = data.Rows.Add();
            row4.Cells.Add("Product Quantity:");
            row4.Cells.Add($" {providerCode["Quantity"].ToString()}");

            Aspose.Pdf.Row row5 = data.Rows.Add();
            row5.Cells.Add("Product Real Price:");
            row5.Cells.Add($" {productCode["RealPrice"].ToString()}");

            decimal realprice = Convert.ToDecimal(productCode["RealPrice"]);
            decimal quantity = Convert.ToDecimal(providerCode["Quantity"]);
            decimal totalPrice = realprice * quantity;

            Aspose.Pdf.Row row6 = data.Rows.Add();
            row6.Cells.Add("Total Price:");
            row6.Cells.Add($" {totalPrice}");

            //Aspose.Pdf.Row row6 = data.Rows.Add();
            //row6.Cells.Add("Total Price:");
            //row6.Cells.Add($"{productCode["Price"]*customerCode["Quantity"].ToString()}");


            page.Paragraphs.Add(fragment);
            page.Paragraphs.Add(data);





            //adding the segments into the page

            doc.Save(path_name);


        }


        ////printing the pdf
        //public static bool print(string name)
        //{

        //    // creating the viewer and adding the settings
        //    PdfViewer viewer = new PdfViewer();
        //    viewer.BindPdf(System.IO.Path.Combine(name));
        //    viewer.AutoResize = false;
        //    viewer.AutoRotate = true;
        //    viewer.PrintPageDialog = false;

        //    System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
        //    System.Drawing.Printing.PageSettings pgs = new System.Drawing.Printing.PageSettings();
        //    System.Drawing.Printing.PrintDocument prtdoc = new System.Drawing.Printing.PrintDocument();
        //    ps.PrinterName = prtdoc.PrinterSettings.PrinterName;

        //    System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();

        //    if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {

        //        viewer.PrintDocumentWithSettings(pgs, ps);
        //        return true;
        //    }

        //    return false;
        //}
        //public static void getMedicine(string path_name, SQLiteDataReader medicine_info)
        //{
        //    medicine_info.Read();


        //    // creating a doc 
        //    Document doc = new Document();
        //    // The font we will use in our pdf
        //    var font = FontRepository.FindFont("Arial");
        //    // Adding header
        //    Aspose.Pdf.Text.TextFragment fragment = new Aspose.Pdf.Text.TextFragment();
        //    Aspose.Pdf.Text.TextSegment inro = new Aspose.Pdf.Text.TextSegment("Στοιχεία Φαρμακου :                                     Eye Clinic\n                                                                       ΔΙΠΑΕ");
        //    Aspose.Pdf.Text.TextSegment stoixeia;



        //    // creating the page

        //    Aspose.Pdf.Page page = doc.Pages.Add();



        //    stoixeia = new Aspose.Pdf.Text.TextSegment($"\nID : {medicine_info["id"].ToString()} \nΟνομα Φάρμακου : {medicine_info["onoma"].ToString()}\nΤύπος : {medicine_info["typos"].ToString()}\n\n\n");

        //    stoixeia.TextState = stoixeiats;

        //    inro.TextState = generalts;


        //    Aspose.Pdf.Text.TextSegment symptomata_label = new Aspose.Pdf.Text.TextSegment("Συμπτώματα : \n\n");
        //    symptomata_label.TextState = stoixeiats;
        //    Aspose.Pdf.Text.TextSegment syptomata_text = new Aspose.Pdf.Text.TextSegment(medicine_info["symptomata"].ToString());
        //    syptomata_text.TextState = textts;
        //    Aspose.Pdf.Text.TextSegment promitheftes_label = new Aspose.Pdf.Text.TextSegment("\n\nΠρομηθευτές : \n\n");
        //    promitheftes_label.TextState = stoixeiats;
        //    Aspose.Pdf.Text.TextSegment promitheftes_text = new Aspose.Pdf.Text.TextSegment(medicine_info["promitheftes"].ToString());
        //    promitheftes_text.TextState = textts;


        //    fragment.Segments.Add(inro);
        //    fragment.Segments.Add(stoixeia);
        //    fragment.Segments.Add(symptomata_label);
        //    fragment.Segments.Add(syptomata_text);
        //    fragment.Segments.Add(promitheftes_label);
        //    fragment.Segments.Add(promitheftes_text);

        //    page.Paragraphs.Add(fragment);

        //    doc.Save(path_name);


        //}





    }
}
