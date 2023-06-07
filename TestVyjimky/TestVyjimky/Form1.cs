using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestVyjimky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pocet = 0, preteceniCisla = 0;
            long soucet = 0;
            foreach(string row in textBox1.Lines)
            {
                try
                {
                    if (row[0] == '-')
                    {
                        try
                        {
                            long cislo = long.Parse(row);
                            try
                            {
                                checked { soucet += cislo; }
                                pocet++;
                            }
                            catch (OverflowException)
                            {
                                soucet = long.MinValue;
                                preteceniCisla++;
                            }
                        }
                        catch (FormatException)
                        { }
                        catch (OverflowException)
                        { }
                    }
                } catch(IndexOutOfRangeException)
                { }
            }
            if(preteceniCisla > 0)
            {
                MessageBox.Show("Čísla přesáhla velikost datového typu. Nezapočítali se " + preteceniCisla + " čísla.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                
                if (pocet == 0)
                    throw new DivideByZeroException();
                double vysledek = (double)soucet / pocet;
                label1.Text = "Průměr: " + vysledek;
            } catch(DivideByZeroException)
            {
                label1.Text = "Průměr: - ? -";
            }
        }
    }
}
