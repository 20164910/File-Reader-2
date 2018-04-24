using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OME_File_Reader
{
    public partial class SaveBtn : Form
    {
        public SaveBtn()
        {
            InitializeComponent();
           
        }

        //Open File
        private void selectFileBtn_Click_1(object sender, EventArgs e)
        {
            //declaring an object to open file dialog
            OpenFileDialog ofdlg = new OpenFileDialog();

            //The file filter allows us to only open specific file types, in this case text files only
            ofdlg.Filter = "Text files (*.txt)|*.txt";

            //condition that chaecks if the dialog has been opened
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                //Making use of exceptions to protect the disk should the codes have errors
                try
                {
                    //to enable program to read the text from file
                    //gave any name to stream reader object as long as its not reserved
                    StreamReader readFile = new StreamReader(File.OpenRead(ofdlg.FileName));

                    //enable the rich text box to display content in selected opened text file
                    richTextBox.Text = readFile.ReadToEnd();
                    //closes the StreamReader method to prevent error
                    //when user attempts to click the open button more than once
                    readFile.Dispose();
                }
                catch (IOException error)
                {
                    MessageBox.Show("Error in Reading from disk, please check code: " + error.Message);
                }
            }

        }

        //Save as 
        //Saves the file as a new file if it does not exist
        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            //creates a file object for the savefile dialog
            SaveFileDialog saveFile = new SaveFileDialog();

            //The file filter allows us to only open specific file types, in this case text files only
            saveFile.Filter = "Text files (*.txt)|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //set path to a new variable of whatever file the user chooses
                //path = saveFile.FileName;

                //Making use of exceptions to protect the disk should the codes have errors
                try
                {
                    //enables the user to write the desired file name to be saved
                    StreamWriter createFile = new StreamWriter(saveFile.FileName);
                    //to save whatever is written in the rich text box
                    createFile.Write(richTextBox.Text);
                    //closes the stream writer to get rid of an error when user attempts to click
                    //the create button more than once
                    createFile.Dispose();
                }
                catch (IOException error)
                {
                    MessageBox.Show("Error in saving to disk, please check code: " + error.Message);
                }
            }

        }

        //Clear All
        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();

        }

        private void SaveBtn_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(selectFileBtn, "select file to be read");
           
        }
    }
}
