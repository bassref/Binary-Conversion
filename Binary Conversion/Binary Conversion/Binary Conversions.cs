/* Name: Rephael Edwards
 * Date: September 15th. 2016
 * Professor: Dr. Stringfellow
 * Program Description: This program allows a user to enter a binary number 
 *                      and converst the number to a decimal.
 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Binary_Conversion
{
    public partial class Form1 : Form
    {
        //Precon: Form is created.
        //Postcon:The program is executed.
        //Purpose: To initialize the components of the form.
        public Form1()
        {
            MessageBox.Show("Welcome to Binary Conversions \n");
           
            InitializeComponent();
        }

        //Precon: The convert button is clicked.
        //Postcon:The function to activate the input box is called.
        //Purpose: To call the input box function.
        private void convert_Click(object sender, EventArgs e)
        {            
            inputBox_Click(sender, e);
        }

        //Precon: The convert button is clicked.
        //Postcon:The number is converted.
        //Purpose:To convert a binary number to a decimal.
        private void inputBox_Click(object sender, EventArgs e)
        {
            //variables
            int i = 0;
            int sum = 0;
            int ans = 0, dig;
            var digits = new List<int>();
            int[] numArray;
            int length, textLength;

            // Read in the number that was typed in the text box
            string entry = inputBox.Text;           
            //the value to compare the input to this
            var regex = new Regex ("^[01]+$");

            //if all the digits entered are either 0 or 1
            if (BinaryCheck(entry, "^[01]+$"))
            {
                //clear the message in the error box
                errorBox.Text = String.Empty;
               
                long num = Convert.ToInt64(inputBox.Text);
                textLength = inputBox.TextLength;

                // add each digit to a list
                for (int n = 1; n <= textLength; n++)
                {
                    digits.Add((int)num % 10);
                    num = num / 10;
                }

                // put the list in an array
                numArray = digits.ToArray();
                //get the length of the array
                length = numArray.Length;

                // for each digit, convert it to decimal and add it to the sum
                for (i = 0; i < length; i++)
                {
                    dig = numArray[i];
                    ans = (int)(dig * (Math.Pow(2, i)));
                    sum += ans;
                }
                // output the answer to the UI
                outputBox.Text = sum.ToString();
            }
            else
            {
                outputBox.Text = String.Empty;
                errorBox.Text = "Invalid Entry";
            }
        }

        //Precon: none
        //Postcon:The number entered is checked for invalid entries
        //Purpose:To check the value entered for invalid characters.
        public Boolean BinaryCheck(string text, string regex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, regex,
                RegexOptions.IgnoreCase);
        }
    }      
}

