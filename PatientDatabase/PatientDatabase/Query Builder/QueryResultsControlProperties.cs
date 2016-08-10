using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public partial class QueryResults
    {
        private void setDataGridViewCurrentQuery(DataGridView dgv)
        {
            dgv.Name = "dgv";
            dgv.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            dgv.Columns.Add("cGate", "Gate");
            dgv.Columns.Add("cProperty", "Property");
            dgv.Columns.Add("cCriteria", "Criteria");
            dgv.Columns.Add("cFilter", "Filter");
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns[0].Width = 51;
            dgv.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[3].ReadOnly = true;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.ReadOnly = true;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.MultiSelect = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(846, 360);
            dgv.Location = new Point(6, 6);
            queries.ForEach(q => dgv.Rows.Add(q.getGateText(), q.Property, q.Criteria, q.Filter));
            foreach (DataGridViewRow row in dgv.Rows) row.DefaultCellStyle.BackColor = Color.LightGray;
            dgv.Rows[0].Selected = true;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
    }
}
