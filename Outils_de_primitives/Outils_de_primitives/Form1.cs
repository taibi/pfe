using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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




            char[] splitters = new char[] { ' ' };
            string[] files;
            try
            {
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                return;
            }
            comboBoxTypePrimitive.Items.Clear();
            foreach (string file in files)
            {

                try
                {
                    string[] laCase2 = Path.GetFileName(file).Split(splitters);
                    comboBoxTypePrimitive.Items.Add(laCase2[0]);

                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.ToString());
                    return;
                }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        /*
   * this fonction help to choise folder where program can find xlsx files
   */
        private void ChoiceFolder(string rep)
        {
            char[] splitters = new char[] { ' ' };
            string[] files;
            try
            {
                files = Directory.GetFiles(rep);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            comboBoxTypePrimitive.Items.Clear();
            foreach (string file in files)
            {

                try
                {
                        string[] laCase2 = Path.GetFileName(file).Split(splitters);
                        comboBoxTypePrimitive.Items.Add(laCase2[0]);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return;
                }
            }
           
        }

        private void radioButtonApprentissage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonApprentissage.Checked)
            {


                char[] splitters = new char[] { ' ' };
                string[] files;
                try
                {
                    files = Directory.GetFiles(LabelApprentissage.Text);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                    return;
                }
                comboBoxSource.Items.Clear();
                foreach (string file in files)
                {

                    try
                    {
                        string[] laCase2 = Path.GetFileName(file).Split(splitters);
                        comboBoxSource.Items.Add(laCase2[0]);

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                        return;
                    }
                }

















            }
            
        }

        private void radioButtonValidation_CheckedChanged(object sender, EventArgs e)
        {
              if (radioButtonValidation.Checked)
            {


                char[] splitters = new char[] { ' ' };
                string[] files;
                try
                {
                    files = Directory.GetFiles(labelValidation.Text);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                    return;
                }
                comboBoxSource.Items.Clear();
                foreach (string file in files)
                {

                    try
                    {
                        string[] laCase2 = Path.GetFileName(file).Split(splitters);
                        comboBoxSource.Items.Add(laCase2[0]);

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                        return;
                    }
                }


        }

    }

        private void radioButtonTest_CheckedChanged(object sender, EventArgs e)
        {
             if (radioButtonTest.Checked)
            {


                char[] splitters = new char[] { ' ' };
                string[] files;
                try
                {
                    files = Directory.GetFiles(labelTest.Text);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                    return;
                }
                comboBoxSource.Items.Clear();
                foreach (string file in files)
                {

                    try
                    {
                        string[] laCase2 = Path.GetFileName(file).Split(splitters);
                        comboBoxSource.Items.Add(laCase2[0]);

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                        return;
                    }
                }


        }

        }


}
}