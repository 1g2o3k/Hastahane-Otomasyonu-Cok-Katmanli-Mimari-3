using System;
using System.Linq;
using System.Windows.Forms;
using cok_katmanli_mimari_db.BLL;
using cok_katmanli_mimari_db.Models;

namespace cok_katmanli_mimari_db
{
    public partial class Form1 : Form
    {
        private readonly ProductService _service = new ProductService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
        }

        private void LoadProducts()
        {
            var list = _service.GetAllProducts();
            dgvProducts.DataSource = list;
            if (dgvProducts.Columns.Contains("Id"))
                dgvProducts.Columns["Id"].Width = 60;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text;
                if (!decimal.TryParse(txtPrice.Text, out var price))
                {
                    MessageBox.Show("Enter a valid price.");
                    return;
                }

                var newId = _service.CreateProduct(name, price);
                LoadProducts();
                SelectRowById(newId);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text, out var id))
                {
                    MessageBox.Show("Select a product to update.");
                    return;
                }

                var name = txtName.Text;
                if (!decimal.TryParse(txtPrice.Text, out var price))
                {
                    MessageBox.Show("Enter a valid price.");
                    return;
                }

                _service.UpdateProduct(id, name, price);
                LoadProducts();
                SelectRowById(id);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text, out var id))
                {
                    MessageBox.Show("Select a product to delete.");
                    return;
                }

                var ok = MessageBox.Show("Delete selected product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes;
                if (!ok) return;

                _service.DeleteProduct(id);
                LoadProducts();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            if (dgvProducts.CurrentRow.DataBoundItem is Product p)
            {
                txtId.Text = p.Id.ToString();
                txtName.Text = p.Name;
                txtPrice.Text = p.Price.ToString("0.00");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            dgvProducts.ClearSelection();
        }

        private void SelectRowById(int id)
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.DataBoundItem is Product p && p.Id == id)
                {
                    row.Selected = true;
                    dgvProducts.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
    }
}
