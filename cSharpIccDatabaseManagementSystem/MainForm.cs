using cSharpIccDatabaseManagementSystem.Models;
using NanoidDotNet;
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
        Video videoSqlQuery = new Video();
        Customer customerSqlQuery = new Customer();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            videoSqlQuery.RetrieveAll(dataGridViewVideoLibrary);

            customerSqlQuery.RetrieveAll(dataGridViewCustomerLibrary);
        }
        // ============================================================================= VIDEO
        private void dataGridViewVideoLibrary_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewVideoLibrary.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewVideoLibrary.SelectedRows[0];

                textBoxVideoInQtyEntry.Text = selectedRow.Cells["Id"].Value.ToString();

                textBoxVideoId.Text = selectedRow.Cells["Id"].Value.ToString();
                textBoxVideoName.Text = selectedRow.Cells["name"].Value.ToString();
                comboBoxVideoType.Text = selectedRow.Cells["type"].Value.ToString();
                textBoxVideoPrice.Text = selectedRow.Cells["price"].Value.ToString();
                textBoxVideoTotalQty.Text = selectedRow.Cells["totalQty"].Value.ToString();
                textBoxVideoQtyIn.Text = selectedRow.Cells["inQty"].Value.ToString();
                textBoxVideoQtyOut.Text = selectedRow.Cells["outQty"].Value.ToString();
            }
        }
        private void buttonDisplayAll_Click(object sender, EventArgs e)
        {
            videoSqlQuery.RetrieveAll(dataGridViewVideoLibrary);
        }
        private void buttonVideoIdSearch_Click(object sender, EventArgs e)
        {
            videoSqlQuery.Id = textBoxVideoIdSearch.Text;

            videoSqlQuery.RetrieveSpecific(dataGridViewVideoLibrary);
        }

        private void buttonAddQtyIn_Click(object sender, EventArgs e)
        {
            videoSqlQuery.Id = textBoxVideoInQtyEntry.Text;
            videoSqlQuery.InQty = (int)numericUpDownQtyIn.Value;

            videoSqlQuery.AddQty();

            videoSqlQuery.RetrieveAll(dataGridViewVideoLibrary);
        }

        private void comboBoxVideoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVideoType.Text == "VCD") textBoxVideoPrice.Text = "20";
            else textBoxVideoPrice.Text = "10";
        }

        private void buttonCreateVideoLiraryRecord_Click(object sender, EventArgs e)
        {
            if (comboBoxVideoType.Text == "VCD") textBoxVideoPrice.Text = "20";
            else textBoxVideoPrice.Text = "10";

            videoSqlQuery.Id = Nanoid.Generate(size: 5);
            videoSqlQuery.Name = textBoxVideoName.Text;
            videoSqlQuery.Type = comboBoxVideoType.Text;
            videoSqlQuery.Price = int.Parse(textBoxVideoPrice.Text);

            videoSqlQuery.Create();

            videoSqlQuery.RetrieveAll(dataGridViewVideoLibrary);
        }

        private void buttonUpdateVideoLibraryRecord_Click(object sender, EventArgs e)
        {
            videoSqlQuery.Id = textBoxVideoId.Text;
            videoSqlQuery.Name = textBoxVideoName.Text;
            videoSqlQuery.Type = comboBoxVideoType.Text;

            videoSqlQuery.Update();

            videoSqlQuery.RetrieveAll(dataGridViewVideoLibrary);
        }

        private void buttonDeleteVideoLibraryRecord_Click(object sender, EventArgs e)
        {
            videoSqlQuery.Id = textBoxVideoId.Text;

            videoSqlQuery.Delete();

            videoSqlQuery.RetrieveAll(dataGridViewVideoLibrary);
        }
        // ==================================================================================== CUSTOMER
        private void dataGridViewCustomerLibrary_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomerLibrary.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCustomerLibrary.SelectedRows[0];

                textBoxCustomerId.Text = selectedRow.Cells["Id"].Value.ToString();
                textBoxCustomerName.Text = selectedRow.Cells["name"].Value.ToString();
                textBoxCustomerMobile.Text = selectedRow.Cells["mobile"].Value.ToString();
                textBoxCustomerEmail.Text = selectedRow.Cells["email"].Value.ToString();
                textBoxCustomerAddress.Text = selectedRow.Cells["address"].Value.ToString();

            }
        }

        private void buttonDisplayAllCustomer_Click(object sender, EventArgs e)
        {
            customerSqlQuery.RetrieveAll(dataGridViewCustomerLibrary);
        }

        private void buttonCustomerSearch_Click(object sender, EventArgs e)
        {
            customerSqlQuery.Id = textBoxCustomerIdSearch.Text;

            customerSqlQuery.RetrieveSpecific(dataGridViewCustomerLibrary);
        }

        private void buttonCreateCustomerLibraryRecord_Click(object sender, EventArgs e)
        {
            customerSqlQuery.Id = Nanoid.Generate(size: 5);
            customerSqlQuery.Name = textBoxCustomerName.Text;
            customerSqlQuery.Mobile = int.Parse(textBoxCustomerMobile.Text);
            customerSqlQuery.Email = textBoxCustomerEmail.Text;
            customerSqlQuery.Address = textBoxCustomerAddress.Text;

            customerSqlQuery.Create();

            customerSqlQuery.RetrieveAll(dataGridViewCustomerLibrary);
        }

        private void buttonUpdateCustomerLibraryRecord_Click(object sender, EventArgs e)
        {
            customerSqlQuery.Id = textBoxCustomerId.Text;
            customerSqlQuery.Name = textBoxCustomerName.Text;
            customerSqlQuery.Mobile = int.Parse(textBoxCustomerMobile.Text);
            customerSqlQuery.Email = textBoxCustomerEmail.Text;
            customerSqlQuery.Address = textBoxCustomerAddress.Text;

            customerSqlQuery.Update();

            customerSqlQuery.RetrieveAll(dataGridViewCustomerLibrary);
        }
    }
}
