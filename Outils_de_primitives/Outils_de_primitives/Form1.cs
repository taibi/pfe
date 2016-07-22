using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
           // matlab.Feval("extract", 1, out result, LabelApprentissage.Text+ "//" + comboBoxSource.Text);


           // matlab.Feval("extract", 0, out result, label13.Text,LabelApprentissage.Text, comboBoxSource.Text.Replace('.','_')+".arff");
            matlab.Feval("extract", 0, out result, label13.Text, labelExtraction.Text, comboBoxSource.Text.Replace('.', '_') + ".arff", labelTypePrimitives.Text, comboBoxSource.Text.Split('.')[0], labelZonevisage.Text + comboBoxSource.Text.Split('.')[0]+".arff");
      //      matlab.Feval("extract", 0, out result, label13.Text, labelExtraction.Text, "text.arff");







            /*
            if (radioButtonApprentissage.Checked)
            {
            matlab.Feval("extract", 0, out result, @label13.Text, @LabelApprentissage.Text);
            }
            if (radioButtonValidation.Checked)
            {
                matlab.Feval("extract", 0, out result, @label13.Text, @labelValidation.Text);
            }
            if (radioButtonTest.Checked)
            {
                matlab.Feval("extract", 0, out result, @label13.Text, @labelTest.Text);
            }
            */
            

        }

   

        private void tabPage2_Click(object sender, EventArgs e)
        {

            char[] splitters = new char[] { '.' };
            string[] files;
            try
            {
                files = Directory.GetFiles(labelTypePrimitives.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
          
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                    foreach (XmlElement element in xmlDoc.DocumentElement)
                    {
                        if (element.Name.Equals("appSettings"))
                        {
                            foreach (XmlNode node in element.ChildNodes)
                            {
                                if (node.Attributes[0].Value.Equals("primitives"))
                                {
                                    node.Attributes[1].Value = folderBrowserDialog1.SelectedPath;
                                }
                            }
                        }
                    }
                    xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                    ConfigurationManager.RefreshSection("appSettings");
                    labelTypePrimitives.Text = ConfigurationManager.AppSettings["primitives"];



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

                    
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("evaluation");
                    config.AppSettings.Settings.Add("evaluation", folderBrowserDialog2.SelectedPath);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    labelEvaluation.Text = ConfigurationManager.AppSettings["evaluation"];



                    char[] splitters = new char[] { ' ' };
                    string[] files;
                    try
                    {
                        files = Directory.GetFiles(folderBrowserDialog2.SelectedPath);
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show(ex1.ToString());
                        return;
                    }
                    comboBoxValeurs.Items.Clear();
                    foreach (string file in files)
                    {

                        try
                        {
                            string[] laCase2 = Path.GetFileName(file).Split(splitters);
                            comboBoxValeurs.Items.Add(laCase2[0]);

                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.ToString());
                            return;
                        }
                    }

                 



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




                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("apprentissage");
                    config.AppSettings.Settings.Add("apprentissage", folderBrowserDialog3.SelectedPath);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    LabelApprentissage.Text = ConfigurationManager.AppSettings["apprentissage"];
                    

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

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("validation");
                    config.AppSettings.Settings.Add("validation", folderBrowserDialog4.SelectedPath);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    labelValidation.Text = ConfigurationManager.AppSettings["validation"];
                   

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

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("test");
                    config.AppSettings.Settings.Add("test", folderBrowserDialog5.SelectedPath);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    labelTest.Text = ConfigurationManager.AppSettings["test"];
                    

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
            

            labelTypePrimitives.Text = ConfigurationManager.AppSettings["primitives"];
            labelEvaluation.Text = ConfigurationManager.AppSettings["evaluation"];
            LabelApprentissage.Text = ConfigurationManager.AppSettings["apprentissage"];
            labelValidation.Text = ConfigurationManager.AppSettings["validation"];
            labelTest.Text = ConfigurationManager.AppSettings["test"];
            labelExtraction.Text = ConfigurationManager.AppSettings["extraction"];
            labelZonevisage.Text = ConfigurationManager.AppSettings["zoneVisage"];


            char[] splitters = new char[] { ' ' };
            string[] files;
            try
            {
                files = Directory.GetFiles(labelTypePrimitives.Text);
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





            char[] splittersEval = new char[] { ' ' };
            string[] filesEval;
            try
            {
                filesEval = Directory.GetFiles(labelEvaluation.Text);
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.ToString());
                return;
            }
            comboBoxValeurs.Items.Clear();
            foreach (string fileE in filesEval)
            {

                try
                {
                    string[] laCase2Eval = Path.GetFileName(fileE).Split(splittersEval);
                    comboBoxValeurs.Items.Add(laCase2Eval[0]);

                }
                catch (Exception ex4)
                {
                    MessageBox.Show(ex4.ToString());
                    return;
                }
            }



            char[] splittersExt = new char[] { ' ' };
            string[] filesExt;
            try
            {
                filesExt = Directory.GetFiles(labelExtraction.Text);
            }
            catch (Exception ex5)
            {
                MessageBox.Show(ex5.ToString());
                return;
            }
            comboBoxExt.Items.Clear();
            foreach (string fileExt in filesExt)
            {

                try
                {
                    string[] laCase2Ext = Path.GetFileName(fileExt).Split(splittersExt);
                    comboBoxExt.Items.Add(laCase2Ext[0]);

                }
                catch (Exception ex6)
                {
                    MessageBox.Show(ex6.ToString());
                    return;
                }
            }










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

        private void comboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {   

            if(radioButtonApprentissage.Checked)
            label13.Text = LabelApprentissage.Text + "\\" + comboBoxSource.Text;

            else if(radioButtonValidation.Checked)

                label13.Text = labelValidation.Text + "\\" + comboBoxSource.Text;
            else if(radioButtonTest.Checked)
                label13.Text = labelTest.Text + "\\" + comboBoxSource.Text;
            

            DestinationLabel.Text = label13.Text.Replace('.','_')+".arff";



        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog6 = new FolderBrowserDialog();

            try
            {
                if (folderBrowserDialog6.ShowDialog() == DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("extraction");
                    config.AppSettings.Settings.Add("extraction", folderBrowserDialog6.SelectedPath);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    labelExtraction.Text = ConfigurationManager.AppSettings["extraction"];

                    char[] splittersExt = new char[] { ' ' };
                    string[] filesExt;
                    try
                    {
                        filesExt = Directory.GetFiles(labelExtraction.Text);
                    }
                    catch (Exception ex5)
                    {
                        MessageBox.Show(ex5.ToString());
                        return;
                    }
                    comboBoxTypePrimitive.Items.Clear();
                    foreach (string fileExt in filesExt)
                    {

                        try
                        {
                            string[] laCase2Ext = Path.GetFileName(fileExt).Split(splittersExt);
                            comboBoxTypePrimitive.Items.Add(laCase2Ext[0]);

                        }
                        catch (Exception ex6)
                        {
                            MessageBox.Show(ex6.ToString());
                            return;
                        }
                    }










                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void comboBoxTypePrimitive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog7 = new FolderBrowserDialog();

            try
            {
                if (folderBrowserDialog7.ShowDialog() == DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("zoneVisage");
                    config.AppSettings.Settings.Add("zoneVisage", folderBrowserDialog7.SelectedPath);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    labelZonevisage.Text = ConfigurationManager.AppSettings["zoneVisage"];


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