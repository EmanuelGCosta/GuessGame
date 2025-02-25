using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace DesafioGameNewCentury
{
    public partial class TabelaHistorico : Form
    {
        private readonly SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\source\repos\DesafioGameNewCentury\GuessGameDB.mdf;Integrated Security=True;Connect Timeout=30");

        public TabelaHistorico(string dificuldade)
        {
            InitializeComponent();
            ConfigurarDataGrid();
            CarregarHistorico(dificuldade);
        }

        private void CarregarHistorico(string dificuldade)
        {
            labelDificuldade.Text = char.ToUpper(dificuldade[0]) + dificuldade.Substring(1).ToLower();

            try
            {
                connect.Open();
                int id_jogador = Jogo.pegandoID();

                // definindo consulta no banco de dados
                StringBuilder query = new StringBuilder();
                query.Append("SELECT Partida.*, Jogador.nome FROM Partida ");
                query.Append("INNER JOIN Jogador ON Partida.id_jogador = Jogador.id_jogador ");
                query.Append("WHERE Jogador.id_jogador = @idJogador ");


                if (dificuldade != "all")
                    query.Append("AND Partida.dificuldade = @dificuldade");

                using (SqlCommand cmd = new SqlCommand(query.ToString(), connect))
                {
                    cmd.Parameters.AddWithValue("@idJogador", id_jogador);
                    if (dificuldade != "all")
                        cmd.Parameters.AddWithValue("@dificuldade", dificuldade);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataGridHistorico.Rows.Clear(); // limpa dados anteriores

                        while (reader.Read())
                        {
                            // adiciona dados na tabela
                            dataGridHistorico.Rows.Add(
                                reader["id_partida"],
                                reader["id_jogador"],
                                reader["nome"],
                                reader["numero_tentativa"],
                                reader["resultado"],
                                reader["dificuldade"],
                                reader["data_partida"]
                            );
                        }
                    }
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

        private void ConfigurarDataGrid()
        {
            // adicionando colunas no data grid
            dataGridHistorico.ColumnCount = 7;
            string[] colunas = { "ID Partida", "ID Jogador", "Nome", "Número Tentativas", "Resultado", "Dificuldade", "Data Partida" };

            for (int i = 0; i < colunas.Length; i++)
                dataGridHistorico.Columns[i].Name = colunas[i];
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
            this.Close();
        }
    }
}
