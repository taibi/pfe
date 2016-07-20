using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outils_de_primitives
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Souece:   http://www.mathworks.com/help/matlab/matlab_external/call-matlab-function-from-c-client.html?requestedDomain=www.mathworks.com
            // Create the MATLAB instance 
            MLApp.MLApp matlab = new MLApp.MLApp();

            // Change to the directory where the function is located 
            //  matlab.Execute(@"cd C:\Users\taib\Desktop\LOG792\primitives_utilities");
            matlab.Execute(@"cd " + Application.StartupPath + "\\matlabUtilities");
            // Define the output 
            object result = null;

            // Call the MATLAB function myfunc
            // matlab.Feval("myfunc", 2, out result, 3.14, 42.0, "world");
            matlab.Feval("extract", 0, out result);
            //     Display result 
            //     object[] res = result as object[];


            //     label1.Text = res[0].ToString();
            //    label2.Text = res[1].ToString(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();

            // Change to the directory where the function is located 
            //  matlab.Execute(@"cd C:\Users\taib\Desktop\LOG792\primitives_utilities");
            matlab.Execute(@"cd " + Application.StartupPath + "\\matlabUtilities");
            // Define the output 
            object result = null;

            // Call the MATLAB function myfunc
            // matlab.Feval("myfunc", 2, out result, 3.14, 42.0, "world");
            matlab.Feval("extract", 0, out result);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
          
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    labelTypePrimitives.Text = folderBrowserDialog1.SelectedPath;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();

            try
            {
                if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
                {
                    labelEvaluation.Text = folderBrowserDialog2.SelectedPath;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog3 = new FolderBrowserDialog();

            try
            {
                if (folderBrowserDialog3.ShowDialog() == DialogResult.OK)
                {
                    LabelApprentissage.Text = folderBrowserDialog3.SelectedPath;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog4 = new FolderBrowserDialog();

            try
            {
                if (folderBrowserDialog4.ShowDialog() == DialogResult.OK)
                {
                    labelValidation.Text = folderBrowserDialog4.SelectedPath;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog5 = new FolderBrowserDialog();

            try
            {
                if (folderBrowserDialog5.ShowDialog() == DialogResult.OK)
                {
                    labelTest.Text = folderBrowserDialog5.SelectedPath;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
    }
}
