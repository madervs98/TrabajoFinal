using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            tb_reprobados.Text = "0";
            tb_aprobadosC.Text = "0";
            tb_aprobadosB.Text = "0";
            tb_aprobadosA.Text = "0";
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //Validación
            if (string.IsNullOrEmpty(tb_matricula.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Código' vacio.");
                tb_matricula.Focus();
                return;
            }
            if(string.IsNullOrEmpty(tb_nombre.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Nombre' vacio.");
                tb_nombre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_apellido.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Apellido' vacio.");
                tb_apellido.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_nota.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Nota' vacio.");
                tb_nota.Focus();
                return;
            }

            //Almacenar datos en DGV
            int notas;
            int calif = Convert.ToInt32(tb_nota.Text.ToString());


            if (calif >= 90)
            {
                notas = int.Parse(tb_nota.Text);
                dgv_datos.Rows.Add(tb_matricula.Text, tb_nombre.Text, tb_apellido.Text, tb_nota.Text, "A");
                //tb_aprobadosA.Text = notas.ToString();
            }
            else if (calif >= 80)
            {
                notas = int.Parse(tb_nota.Text);
                dgv_datos.Rows.Add(tb_matricula.Text, tb_nombre.Text, tb_apellido.Text, tb_nota.Text, "B");
                //tb_aprobadosB.Text = notas.ToString();
            }
            else if (calif >= 70)
            {
                notas = int.Parse(tb_nota.Text);
                dgv_datos.Rows.Add(tb_matricula.Text, tb_nombre.Text, tb_apellido.Text, tb_nota.Text, "C");
                //tb_aprobadosC.Text = notas.ToString();
            }            
            else if (calif < 69)
            {
                notas = int.Parse(tb_nota.Text);
                dgv_datos.Rows.Add(tb_matricula.Text, tb_nombre.Text, tb_apellido.Text, tb_nota.Text, "F");
                //tb_reprobados.Text = notas.ToString();
            }

            //Limpiar Campos
            tb_matricula.Clear();
            tb_nombre.Clear();
            tb_apellido.Clear();
            tb_nota.Clear();
            tb_matricula.Focus();
            ActualizarDGV();
        }
        private void ActualizarDGV()
        {
            tb_reprobados.Text = "0";
            tb_aprobadosA.Text = "0";
            tb_aprobadosB.Text = "0";
            tb_aprobadosC.Text = "0";

            foreach (DataGridViewRow row in dgv_datos.Rows)
            {
                if (Convert.ToInt32(row.Cells["Column4"].Value.ToString()) < 69)
                {
                    tb_reprobados.Text = (Convert.ToInt32(tb_reprobados.Text.ToString()) + 1).ToString();
                }
                else if (Convert.ToInt32(row.Cells["Column4"].Value.ToString()) >= 90)
                {
                    tb_aprobadosA.Text = (Convert.ToInt32(tb_aprobadosA.Text.ToString()) + 1).ToString();
                }
                else if (Convert.ToInt32(row.Cells["Column4"].Value.ToString()) >= 80)
                {
                    tb_aprobadosB.Text = (Convert.ToInt32(tb_aprobadosB.Text.ToString()) + 1).ToString();
                }
                else if (Convert.ToInt32(row.Cells["Column4"].Value.ToString()) >= 70)
                {
                    tb_aprobadosC.Text = (Convert.ToInt32(tb_aprobadosC.Text.ToString()) + 1).ToString();
                }

            }
        
        }
        //Eliminar
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_datos.SelectedCells.Count == 1)
            {
                
                dgv_datos.Rows.RemoveAt(dgv_datos.CurrentRow.Index);
                ActualizarDGV();

            }

        }

    }
}
