using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class CommonUIMethodsAndFunctions
    {
        public void setListBoxSelectedIndex(ListBox listbox, int index)
        {
            if (listbox.Items.Count > 0) listbox.SelectedIndex = index;
        }

        public void setComboBoxSelectedIndex(ComboBox comboBox, int index)
        {
            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = index;
        }

        public void setSelectedDataGridViewRow(DataGridView dgv, int rowIndex)
        {
            if (dgv.Rows.Count > 0) dgv.Rows[rowIndex].Selected = true;
        }

        public bool dataGridViewHasData(DataGridView dgv)
        {
            return dgv.Rows.Count > 0;
        }
    }
}
