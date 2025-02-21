using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesafioGameNewCentury
{

    public partial class Form1 : Form
    {

        SqlConnection
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\source\repos\DesafioGameNewCentury\GuessGameDB.mdf;Integrated Security=True;Connect Timeout=30");


        public static int id_jogador = 0;
        public static string nome = string.Empty;

        public Form1()
        {
            InitializeComponent();
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

            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor insira um nome!", "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string checkName = "SELECT Jogador.nome FROM Jogador WHERE nome = @nomej";

                        using(SqlCommand cmd = new SqlCommand(checkName, connect))
                        {
                            cmd.Parameters.AddWithValue("@nomej", textBox1.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            nome = textBox1.Text;
                            // verificando se usuario ja existe
                            if (table.Rows.Count > 0)
                            {
                                
                                if (MessageBox.Show("Usuário " + char.ToUpper(nome[0]) + nome.Substring(1).ToLower() + " já existe, deseja continuar?", "Mesangem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    TelaPrincipal telaSelecao = new TelaPrincipal();
                                    telaSelecao.Show();

                                    this.Hide();
                                };
                            }
                            else if (MessageBox.Show("Deseja criar um novo usuário chamado: " + char.ToUpper(nome[0]) + nome.Substring(1).ToLower() + "?", "Mesangem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                // criando novo usuario
                                string insertData = "INSERT INTO Jogador (nome) VALUES (@nomej)";

                                using (SqlCommand insertD = new SqlCommand(insertData, connect))
                                {
                                    insertD.Parameters.AddWithValue("@nomej", textBox1.Text.Trim().ToLower());

                                    DateTime today = DateTime.Today;
                                    insertD.Parameters.AddWithValue("@datac", today);

                                    insertD.ExecuteNonQuery();

                                    MessageBox.Show("Usuário criado!", "Mesangem de informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    TelaPrincipal telaSelecao = new TelaPrincipal();
                                    telaSelecao.Show();

                                    this.Hide();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no banco de dados: " + ex, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }


            }

        }

        public bool checkConnection()
        {
            if(connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
