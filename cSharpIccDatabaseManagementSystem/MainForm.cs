using cSharpIccDatabaseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIccDatabaseManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddQtyIn_Click(object sender, EventArgs e)
        {

        }

        private void buttonVideoIdSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateVideoLiraryRecord_Click(object sender, EventArgs e)
        {
            try
            {
                Video create = new Video();

                create.Id = Guid.NewGuid();
                create.Name = textBoxVideoName.Text;
                create.Type = comboBoxVideoType.Text;
                create.Price = int.Parse(textBoxVideoPrice.Text);
                create.TotalQty = int.Parse(textBoxVideoTotalQty.Text);
                create.InQty = int.Parse(textBoxVideoQtyIn.Text);
                create.OutQty = int.Parse(textBoxVideoQtyOut.Text);

                create.Create();

                MessageBox.Show("Video Successfully Created!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void buttonUpdateVideoLibraryRecord_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteVideoLibraryRecord_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxVideoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVideoType.Text == "VCD") textBoxVideoPrice.Text = "20";
            else textBoxVideoPrice.Text = "10";
        }
    }
}
