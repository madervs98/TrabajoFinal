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
                MessageBox.Show("Por favor, no dejar campo 'Código' vacio.");
                tb_nombre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_apellido.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Código' vacio.");
                tb_apellido.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_nota.Text))
            {
                MessageBox.Show("Por favor, no dejar campo 'Código' vacio.");
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

        }

        //Eliminar
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int resultado=0;
            if (dgv_datos.CurrentRow.Index != -1)
            {
                if (dgv_datos.CurrentRow.Cells[2].Value.ToString().Trim() != "")
                {
                    resultado = int.Parse(tb_reprobados.Text) - int.Parse(dgv_datos.CurrentRow.Cells[2].Value.ToString());
                    tb_reprobados.Text = resultado.ToString();
                }
                else if (dgv_datos.CurrentRow.Cells[3].Value.ToString().Trim() != "")
                {
                    resultado = int.Parse(tb_aprobadosC.Text) - int.Parse(dgv_datos.CurrentRow.Cells[3].Value.ToString());
                    tb_aprobadosC.Text = resultado.ToString();
                }
                else if (dgv_datos.CurrentRow.Cells[4].Value.ToString().Trim() != "")
                {
                    resultado = int.Parse(tb_aprobadosB.Text) - int.Parse(dgv_datos.CurrentRow.Cells[4].Value.ToString());
                    tb_aprobadosB.Text = resultado.ToString();
                }
                else if (dgv_datos.CurrentRow.Cells[5].Value.ToString().Trim() != "")
                {
                    resultado = int.Parse(tb_aprobadosA.Text) - int.Parse(dgv_datos.CurrentRow.Cells[5].Value.ToString());
                    tb_aprobadosA.Text = resultado.ToString();
                }
            }
            dgv_datos.Rows.RemoveAt(dgv_datos.CurrentRow.Index);
        }

        //Crear contador para cantidad de alumnos aprobados

    }
}
