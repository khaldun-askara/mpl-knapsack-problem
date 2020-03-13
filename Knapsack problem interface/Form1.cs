using System;
using Knapsack;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            btn_solve.Enabled = false;
        }

        private void Color_dgv(bool[] colors)
        {
            for (int i = 0; i < colors.Length; i++)
                if (colors[i])
                    foreach (DataGridViewCell cell in dgv_items.Rows[i].Cells)
                        cell.Style.BackColor = Color.LightGreen;
                else
                    foreach (DataGridViewCell cell in dgv_items.Rows[i].Cells)
                        cell.Style.BackColor = Color.White;
        }

        private void btn_solve_enable()
        {
            int capacity;
            if (txtB_capacity.Text == null || txtB_capacity.Text == "" || !int.TryParse(txtB_capacity.Text, out capacity))
            {
                btn_solve.Enabled = false;
                return;
            }
            if (cmB_select.SelectedItem == null)
            {
                btn_solve.Enabled = false;
                return;
            }
            btn_solve.Enabled = true;
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
            list_of_items = new Items(temp);
            Update_dgv_items();
        }

        private void Update_dgv_items()
        {
            dgv_items.Rows.Clear();
            if (list_of_items != null)
                foreach (Item item in list_of_items.list_of_items)
                {
                    dgv_items.Rows.Add(item.IsOld, item.name, item.weight, item.cost);
                }
        }
        private void Initialize_dgv_items()
        {
            dgv_items.Columns.Add(new DataGridViewTextBoxColumn { Name = "isOld", Visible = false });
            dgv_items.Columns.Add("name", "Предмет");
            dgv_items.Columns.Add("weight", "Вес");
            dgv_items.Columns.Add("cost", "Стоимость");
            Update_dgv_items();
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "XML файлы(*.xml)|*.xml";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            current_file_name = dlg.FileName;

            var xs = new XmlSerializer(typeof(List<Item>));
            using (var fs = new FileStream(current_file_name, FileMode.Create))
            {
                try
                {
                    xs.Serialize(fs, list_of_items.list_of_items);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
            MessageBox.Show("Успешно сохранено");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btn_solve_enable();
        }
        private void btn_solver_add_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Type[] types = new Type[0];
            //Assembly a = Assembly.LoadFile(dlg.FileName);
            //types = a.ExportedTypes.ToArray();
            //types = a.GetTypes();
            try
            {
                Assembly a = Assembly.LoadFile(dlg.FileName);
                types = a.GetTypes();
            }
            catch
            {
                MessageBox.Show("Выбрана некорректная библиотека");
                return;
            }
            //try
            //{
            //    Assembly a = Assembly.LoadFile(dlg.FileName);
            //    types = a.ExportedTypes.ToArray();
            //}
            //catch
            //{
            //    MessageBox.Show("Выбрана некорректная библиотека");
            //    return;
            //}
            foreach (var t in types)
            {
                if (t.GetInterface("ISolver") == null)
                    continue;
                var constr = t.GetConstructor(new Type[0]);
                if (constr != null)
                {
                    var solver = constr.Invoke(new object[0]) as ISolver;
                    if (solver != null)
                        cmB_select.Items.Add(new ComboBoxItem(solver));
                    return;
                }
            }
            MessageBox.Show("В библиотеке нет подходящего класса");
        }

        private void cmB_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_solve_enable();
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {
            int capacity = int.Parse(txtB_capacity.Text);
            var solver = ((ComboBoxItem)cmB_select.SelectedItem).solver;
            bool[] result = solver.Solve(capacity, list_of_items.GetArrays().Item1, list_of_items.GetArrays().Item2);
        }
    }

    class ComboBoxItem
    {
        public ISolver solver;
        public ComboBoxItem(ISolver solver)
        {
            this.solver = solver;
        }
        public override string ToString()
        {
            return solver.GetName();
        }
    }
}
