using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioGameNewCentury
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();

            NomeJogador.Text = Form1.nomeFormatado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fechar aplicativo?", "Mesangem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dificuldade dificuldade = new Dificuldade();
            dificuldade.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Historico historico = new Historico(this);
            historico.Show();

            this.Hide();
        }

        private void NomeJogador_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
