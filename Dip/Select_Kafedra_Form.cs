using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dip
{
    public partial class Select_Kafedra_Form : Form
    {
        public Select_Kafedra_Form()    
        {
            InitializeComponent();
            //F3_dgv_select_kafedra.DataSource = DBObject.Entites.Kafedra.ToList();
            //F3_dgv_select_kafedra.Columns["Zakupka"].Visible = false;
            //F3_dgv_select_kafedra.Columns["Name"].HeaderText = "Кафедры:";
            comboBox1.DataSource = DBObject.Entites.Kafedra.ToList().Select(c=> c.Name).ToList();
        }

        // Kafedra kafedra = (Kafedra)F3_dgv_select_kafedra.Rows[e.RowIndex].DataBoundItem;


        //Kafedra kafedra = (Kafedra)F3_dgv_select_kafedra.Rows[e.RowIndex].DataBoundItem;


        private void F3_dgv_select_kafedra_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {

            this.Close();
        }
    }
}
