using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DesafioGameNewCentury
{
    public partial class Jogo : Form
    {
        private static SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\source\repos\DesafioGameNewCentury\GuessGameDB.mdf;Integrated Security=True;Connect Timeout=30");

        // definindo um dicionario com a dificuldade e tentativas totais
        public static readonly Dictionary<string, int> dificuldadesTentativas = new Dictionary<string, int>
        {
            {"facil", 6},
            {"medio", 4},
            {"dificil", 2}
        };

        private int randomNum;
        private int tentativasAtual;

        public Jogo()
        {
            InitializeComponent();

            // numero random 
            Random rnd = new Random();
            randomNum = rnd.Next(1, 9);
            Console.WriteLine(randomNum);

            // pegando a quantidade de tentativas do usuario dependendo da dificuldade que o usuario escolher
            tentativasAtual = dificuldadesTentativas[Dificuldade.dificuldadeEscolhaJogador];

            labelTentativas.Text = tentativasAtual.ToString();

            jogoLoad();
        }

        private void jogoLoad()
        {
            for (int i = 1; i <= 9; i++)
            {
                // pegando todos os botoes de 1 a 9 e armazenando na variavel btn
                Button btn = (Button)this.Controls.Find($"num{i}", true).FirstOrDefault();
                if (btn != null)
                {
                    btn.Click += numButtonClick;
                }
            }
        }

        private void numButtonClick(object sender, EventArgs e)
        {
            // verifica se sender é um button, se sim, quando ele for clicado entrara na condicional 
            if (sender is Button clickedButton)
            {
                // verifica se o usuario acertou o numero aleatorio
                if (int.Parse(clickedButton.Text) == randomNum)
                {
                    clickedButton.BackColor = Color.Green;
                    clickedButton.Enabled = false;
                    MessageBox.Show("VOCÊ GANHOU!!!", "Mensagem de informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tentativasAtual--;
                    salvarDados(Resultado.SUCCESS);
                    voltarTelaInicial();
                }
                else
                {
                    clickedButton.BackColor = Color.Red;
                    clickedButton.Text = "X";
                    clickedButton.Enabled = false;
                    tentativasAtual--;
                    labelTentativas.Text = tentativasAtual.ToString();

                    if (tentativasAtual == 0)
                    {
                        MessageBox.Show($"VOCÊ PERDEU!!!\nNúmero Certo: {randomNum}", "Mensagem de informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        salvarDados(Resultado.WRONG);
                        voltarTelaInicial();
                    }
                }
            }
        }

        private void salvarDados(Resultado resultado)
        {
            int id = pegandoID();

            try
            {
                // salva os dados da partida na tabela
                connect.Open();
                string insertData = "INSERT INTO Partida (id_jogador, numero_tentativa, resultado, dificuldade) VALUES (@id_j, @numero_tent, @result, @dific)";

                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                {
                    cmd.Parameters.AddWithValue("@id_j", id);
                    cmd.Parameters.AddWithValue("@numero_tent", dificuldadesTentativas[Dificuldade.dificuldadeEscolhaJogador] - tentativasAtual);
                    cmd.Parameters.AddWithValue("@result", (int)resultado == 1 ? "Ganhou" : "Perdeu");
                    cmd.Parameters.AddWithValue("@dific", Dificuldade.dificuldadeEscolhaJogador);
                    cmd.ExecuteNonQuery();
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

        public static int pegandoID()
        {
            int id = 0;

            try
            {
                // funcao para pegar o id do usuario
                connect.Open();
                string idJogadorQuery = "SELECT id_jogador FROM Jogador WHERE nome = @nomej";

                using (SqlCommand cmd = new SqlCommand(idJogadorQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@nomej", Form1.nome.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            id = int.Parse(reader["id_jogador"].ToString());
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

            return id;
        }

        private void voltarTelaInicial()
        {
            new TelaPrincipal().Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fechar aplicativo?", "Mensagem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
