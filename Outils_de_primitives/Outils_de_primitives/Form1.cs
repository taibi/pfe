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
    }
}
