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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void entradaDeDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntradaDiario EntradadeDiario = new EntradaDiario();
            EntradadeDiario.MdiParent = this;
            EntradadeDiario.Show();
        }

        private void calculoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 CalculoNotas = new Form2();
            CalculoNotas.MdiParent = this;
            CalculoNotas.Show();
        }
    }
}