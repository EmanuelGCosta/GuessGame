using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesafioGameNewCentury
{
    public partial class Form1 : Form
    {
        private static SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\source\repos\DesafioGameNewCentury\GuessGameDB.mdf;Integrated Security=True;Connect Timeout=30");

        public static string nome = string.Empty;
        public static string nomeFormatado = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fechar aplicativo?", "Mensagem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nomeInserido = textBox1.Text.Trim();

            // verificando se usuario digitou algo no campo
            if (string.IsNullOrEmpty(nomeInserido))
            {
                MessageBox.Show("Por favor, insira um nome!", "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nome = nomeInserido;
            nomeFormatado = char.ToUpper(nome[0]) + nome.Substring(1).ToLower();

            if (UsuarioExiste(nomeInserido))
            {
                if (MessageBox.Show($"Usuário {nomeFormatado} já existe, deseja continuar?", "Mensagem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AbrirTelaPrincipal();
                }
            }
            else if (MessageBox.Show($"Deseja criar um novo usuário chamado: {nomeFormatado}?", "Mensagem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CriarUsuario(nomeInserido);
                MessageBox.Show("Usuário criado!", "Mensagem de informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AbrirTelaPrincipal();
            }
        }


        private bool UsuarioExiste(string nomeUsuario)
        {
            bool usuarioBool = false ;
            try
            {
                // verificando se usuario ja existe
                connect.Open();
                string query = "SELECT COUNT(*) FROM Jogador WHERE nome = @nome";
                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeUsuario);
                    usuarioBool =  (int)cmd.ExecuteScalar() > 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }

            return usuarioBool;
        }

        private void CriarUsuario(string nomeUsuario)
        {
            try
            {
                // criando usuario novo
                connect.Open();
                string query = "INSERT INTO Jogador (nome) VALUES (@nome)";
                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeUsuario.ToLower());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();    
            }
        }



        private void AbrirTelaPrincipal()
        {
            TelaPrincipal telaSelecao = new TelaPrincipal();
            telaSelecao.Show();
            this.Hide();
        }
    }
}
