using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;


namespace Baningwithmysql
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument PrintDoc = new PrintDocument();
            //Set PrinterName as the selected printer in the printers list 
            PrintDoc.PrinterSettings.PrinterName =
           comboBox1.SelectedItem.ToString();
            //Add PrintPage event handler 
            PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            //Print the document 
            PrintDoc.Print();


        }

        public void PrintPageMethod(object sender, PrintPageEventArgs ppev)
        {
            //Get the Graphics object 
            Graphics g = ppev.Graphics;
            //Create a font verdana with size 14 
            Font font = new Font("Verdana", 20);
            //Create a solid brush with red color 
            SolidBrush brush = new SolidBrush(Color.Red);
            // Create a rectangle 
            Rectangle rect = new Rectangle(50, 50, 200, 200);
            //Draw text 
            g.DrawString("Hello, Printer! ", font, brush, rect);
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(printer.ToString());
            }

        }
    }
}
