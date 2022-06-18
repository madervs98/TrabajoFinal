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
    public partial class EntradaDiario : Form
    {
        String Tipo = "";

        public EntradaDiario()
        {
            InitializeComponent();
            t_debito.Text = "0";
            t_credito.Text = "0";
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //Validación
            if (string.IsNullOrEmpty(tb_codigo.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Código' vacio.");
                tb_codigo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_descripcion.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Descripción' vacio.");
                tb_descripcion.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cb_tipo.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Tipo de Pago' vacio.");
                cb_tipo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_precio.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Precio' vacio.");
                tb_precio.Focus();
                return;
            }

            //Seleccionar Tipo de Pago
            float total;
            if(cb_tipo.Text == "Débito")
            {
                total = float.Parse(tb_precio.Text) + float.Parse(t_debito.Text);
                dgv_detalles.Rows.Add(tb_codigo.Text, tb_descripcion.Text, tb_precio.Text, "");
                t_debito.Text = total.ToString();
            }
            else if(cb_tipo.Text == "Crédito")
            {
                total = float.Parse(tb_precio.Text) + float.Parse(t_credito.Text);
                dgv_detalles.Rows.Add(tb_codigo.Text, tb_descripcion.Text, "", tb_precio.Text);
                t_credito.Text = total.ToString();
            }

            //Limpiar Campos
            tb_codigo.Clear();
            tb_descripcion.Clear();
            Tipo = cb_tipo.Text = "";
            tb_precio.Clear();
            tb_codigo.Focus();

        }

        //Seleccionar
        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tipo = cb_tipo.Text;
        }

        //Eliminar
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            float resultado= 0;
            if(dgv_detalles.CurrentRow.Index != -1)
            {
                if (dgv_detalles.CurrentRow.Cells[2].Value.ToString().Trim() != "")
                {
                    resultado = float.Parse(t_debito.Text) - float.Parse(dgv_detalles.CurrentRow.Cells[2].Value.ToString());
                    t_debito.Text = resultado.ToString();
                }
                else if (dgv_detalles.CurrentRow.Cells[3].Value.ToString().Trim() != "")
                {
                    resultado = float.Parse(t_credito.Text) - float.Parse(dgv_detalles.CurrentRow.Cells[3].Value.ToString());
                    t_credito.Text = resultado.ToString();
                }
            }
            dgv_detalles.Rows.RemoveAt(dgv_detalles.CurrentRow.Index);
        }
    }
}
