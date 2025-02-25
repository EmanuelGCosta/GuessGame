using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DesafioGameNewCentury
{
    public partial class Historico : Form
    {
        private Form TelaPrincipal;

        // define um dicionario contendo as 3 dificuldades junto com partidas totais e partidas vencidas nessa dificuldade
        Dictionary<string, (int partidasTotais, int partidasVencidas)> historicoJogosDic = new Dictionary<string, (int, int)>
        {
            { "facil", (0, 0) },
            { "medio", (0, 0) },
            { "dificil", (0, 0) }
        };

        private SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\source\repos\DesafioGameNewCentury\GuessGameDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Historico(Form anterior)
        {
            this.TelaPrincipal = anterior;
            InitializeComponent();

            historicoDificuldades();
            ExibirPorcentagem();
        }

        private void historicoDificuldades()
        {
            try
            {
                connect.Open();

                // pegando id do jogador logado
                int id_jogador = Jogo.pegandoID();

                string dificuldadeQuery = "SELECT dificuldade, resultado FROM Partida WHERE Partida.id_jogador = @idJogador";
                using (SqlCommand cmd = new SqlCommand(dificuldadeQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@idJogador", id_jogador);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string dificuldade = (string)reader["dificuldade"];
                            string resultado = (string)reader["resultado"];

                            // verifica se tem a chave dificuldade no dicionario
                            if (historicoJogosDic.ContainsKey(dificuldade))
                            {
                                var (partidasTotais, partidasVencidas) = historicoJogosDic[dificuldade];

                                partidasTotais++;

                                if (resultado == "Ganhou")
                                {
                                    partidasVencidas++;
                                }

                                // atualiza dicionario com tupla
                                historicoJogosDic[dificuldade] = (partidasTotais, partidasVencidas);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex}", "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        // funcao para exibir porcentagem e partidas totais na tela de historico
        private void ExibirPorcentagem()
        {
            foreach (var item in historicoJogosDic)
            {
                string dificuldade = item.Key;
                Label labelPorcentagem = (Label)this.Controls.Find($"Porcent_{dificuldade}", true).FirstOrDefault();
                Label labelTotalPartidas = (Label)this.Controls.Find($"partidas_{dificuldade}", true).FirstOrDefault();
                Label labelRank = (Label)this.Controls.Find($"rank_{dificuldade}", true).FirstOrDefault();

                int partidasTotais = item.Value.partidasTotais;
                int partidasVencidas = item.Value.partidasVencidas;


                double porcentagemVitorias = (partidasTotais > 0) ? ((double)partidasVencidas / partidasTotais) * 100 : 0;

                string rank = ExibirRank(porcentagemVitorias);

                labelTotalPartidas.Text = $"{partidasTotais}";
                labelPorcentagem.Text = $"{porcentagemVitorias:F0}%";
                labelRank.Text = $"{rank}";
            }
        }

        // funcao que retorna o rank que o usuario esta dependendo da porcentagem de vitoria/derrota
        private string ExibirRank(double porcentagemVitorias)
        {
            if (porcentagemVitorias == 100)
                return "S";
            else if (porcentagemVitorias >= 90)
                return "A";
            else if (porcentagemVitorias >= 80)
                return "B";
            else if (porcentagemVitorias >= 70)
                return "C";
            else if (porcentagemVitorias >= 60)
                return "D";
            else
                return "E";
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
            TelaPrincipal.Show();
            this.Close();
        }

        private void btnDificuldade1_Click(object sender, EventArgs e)
        {
            TabelaHistorico tabelaHistorico = new TabelaHistorico("facil");
            tabelaHistorico.Show();
        }

        private void btnDificuldade2_Click(object sender, EventArgs e)
        {
            TabelaHistorico tabelaHistorico = new TabelaHistorico("medio");
            tabelaHistorico.Show();
        }

        private void btnDificuldade3_Click(object sender, EventArgs e)
        {
            TabelaHistorico tabelaHistorico = new TabelaHistorico("dificil");
            tabelaHistorico.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabelaHistorico tabelaHistorico = new TabelaHistorico("all");
            tabelaHistorico.Show();
        }
    }
}
