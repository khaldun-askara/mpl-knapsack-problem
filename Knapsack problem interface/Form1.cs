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
        private Items list_of_items;
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
        }

        private void Initialize_dgv_items()
        {
            dgv_items.Rows.Clear();
            dgv_items.Columns.Add("name", "Предмет");
            dgv_items.Columns.Add("weight", "Вес");
            dgv_items.Columns.Add("cost", "Стоимость");
            if (list_of_items != null)
                foreach (Item item in list_of_items.list_of_items)
                    dgv_items.Rows.Add(item.name, item.weight, item.cost);
        }
    }
}
