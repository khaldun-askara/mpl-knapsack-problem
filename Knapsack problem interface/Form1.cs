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
using System.Xml.Serialization;

namespace Knapsack_problem_interface
{
    public partial class frm_knapsack_problem_interface : Form
    {
        private string current_file_name;
        private Items list_of_items = new Items();
        public frm_knapsack_problem_interface()
        {
            InitializeComponent();
            Initialize_dgv_items();
        }

        private void btn_input_add_Click(object sender, EventArgs e)
        {
            List<Item> temp;
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            current_file_name = dlg.FileName;
            dlg.Filter = "XML файлы(*.xml)|*.xml";
            var xs = new XmlSerializer(typeof(List<Item>));
            using (var fs = new FileStream(current_file_name, FileMode.Open))
            {
                try
                {
                    temp = (List<Item>)xs.Deserialize(fs);
                }
                catch (Exception eee)
                {
                    MessageBox.Show("С файлом что-то не так. " + eee.Message);
                    return;
                }
            }
            Initialize_dgv_items();
        }

        private void Initialize_dgv_items()
        {
            dgv_items.Rows.Clear();
            dgv_items.Columns.Add(new DataGridViewTextBoxColumn { Name = "isOld", Visible = false });
            dgv_items.Columns.Add("name", "Предмет");
            dgv_items.Columns.Add("weight", "Вес");
            dgv_items.Columns.Add("cost", "Стоимость");
            if (list_of_items != null)
                foreach (Item item in list_of_items.list_of_items)
                {
                    dgv_items.Rows.Add(item.IsOld, item.name, item.weight, item.cost);
                }
        }

        private void dgv_items_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgv_items.IsCurrentRowDirty)
                return;
            DataGridViewRow curr_row = dgv_items.Rows[e.RowIndex];
            (DataGridViewCell, DataGridViewCell) intCells = 
                (curr_row.Cells["weight"], curr_row.Cells["cost"]);
            int res;
            if (intCells.Item1.Value == null 
                || intCells.Item2.Value == null 
                || curr_row.Cells["name"].Value == null)
            {
                curr_row.ErrorText = "Значения не могут быть пустыми!";
                e.Cancel = true;
                return;
            }
            if (!int.TryParse(intCells.Item1.Value.ToString(), out res))
            {
                intCells.Item1.ErrorText = "Только целочисленные значения!";
                e.Cancel = true;
                return;
            }
            else intCells.Item1.ErrorText = "";
            if (!int.TryParse(intCells.Item2.Value.ToString(), out res))
            {
                intCells.Item2.ErrorText = "Только целочисленные значения!";
                e.Cancel = true;
                return;
            }
            else intCells.Item2.ErrorText = "";

            curr_row.ErrorText = "";
            bool? isOld = (bool?)curr_row.Cells["isOld"].Value;
            if (isOld.HasValue)
                list_of_items.Change(curr_row.Index,
                                    curr_row.Cells["name"].Value.ToString(),
                                    int.Parse(intCells.Item1.Value.ToString()),
                                    int.Parse(intCells.Item2.Value.ToString()));
            else
                list_of_items.Add(curr_row.Cells["name"].Value.ToString(),
                                    int.Parse(intCells.Item1.Value.ToString()),
                                    int.Parse(intCells.Item2.Value.ToString()));
        }
    }
}
