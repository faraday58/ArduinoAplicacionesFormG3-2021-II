using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArduinoAplicacionesFormG3_2021_II
{

    public partial class FormTemperatura : Form
    {
        StreamWriter sw;

        public FormTemperatura()
        {
            InitializeComponent();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Random temperaturaAleatoria = new Random();
                sw = new StreamWriter("tiempoTemperatura.txt");

                int renglones = 100;
                sw.WriteLine("tiempo[s]  Temperatura [C]");
                              
                for(int i=0; i< renglones; i++)
                {
                    string tiempo = i.ToString();
                    string temperatura = temperaturaAleatoria.Next(1000).ToString();
                    dgvDatos.Rows.Add(tiempo,temperatura);
                    
                }


                for (int i=0; i < renglones-1; i++)
                {
                    string tiempo= dgvDatos.Rows[i].Cells[0].Value.ToString() ;
                    string temperatura= dgvDatos.Rows[i].Cells[1].Value.ToString() ;

                    sw.WriteLine(tiempo + "\t \t " + temperatura );
                }
            }
            
            catch(IOException error)
            {
                MessageBox.Show("Error Archivo:" + error.Message);
            }
           catch (Exception error)
            {
                MessageBox.Show("Error:  " + error.Message);
            }
       
            finally
            {
                sw.Close();
            }


        }
    }
}
