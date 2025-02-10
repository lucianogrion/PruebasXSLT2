using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.Schema;

namespace PruebasXSLT
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.Schemas.Add("http://www.contoso.com/books", "biblioteca.xsd");
            xmlSettings.ValidationType = ValidationType.Schema;
            xmlSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader books = XmlReader.Create("biblioteca.xml", xmlSettings);
            int i = 0;

            while (books.Read()) {
                Console.WriteLine("Leyendo Linea " + i.ToString());
                i++;
            }

            Console.WriteLine("FIN");


            // Load the style sheet.
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("ahtml.xsl");

            // Execute the transform and output the results to a file.
            xslt.Transform("biblioteca.xml", "books.html");


            //XmlWriter writer = XmlWriter.Create("sarlanga.txt") ;
            //xslt.Transform("libro.xml",writer);

        }


       

    static void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("ERROR: ");
            Console.WriteLine(e.Message);
        }
    }


    }
}
