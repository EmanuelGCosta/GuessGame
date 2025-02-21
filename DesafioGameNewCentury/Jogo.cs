using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesafioGameNewCentury
{
    public partial class Jogo : Form
    {
        SqlConnection
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\source\repos\DesafioGameNewCentury\GuessGameDB.mdf;Integrated Security=True;Connect Timeout=30");


        public static Dictionary<string, int> dificuldadesTentativas = new Dictionary<string, int>
        {
            {"facil", 6},
            {"medio", 4},
            {"dificil", 2}
        };

        public enum Resultado
        {
            SUCCESS = 1,
            WRONG = 0
        }

        int randomNum = 0;
        int tentativasAtual = dificuldadesTentativas[Dificuldade.dificuldadeEscolhaJogador];

        public Jogo()
        {
            InitializeComponent();

            Random rnd = new Random();
            randomNum = rnd.Next(1, 9);

            Console.WriteLine(randomNum);

            jogoLoad();

            labelTentativas.Text = tentativasAtual.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fechar aplicativo?", "Mesangem de informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void jogoLoad()
        {
            for (int i = 1; i <= 9; i++)
            {
                // busca qualquer controle pelo nome (num1, num2...) dentro do forms
                Button btn = (Button)this.Controls.Find($"num{i}", true).FirstOrDefault();
                if (btn != null)
                {
                    // quando o botao for clicado, numButton_Click será executado
                    btn.Click += numButtonClick;
                }
            }
        }

        private void numButtonClick(object sender, EventArgs e)
        {
            // verificando se é um botao, se nao for 'clickedButton' será null
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // checa se o botao clicado tem o mesmo numero que o numero random
                if (int.Parse(clickedButton.Text) == randomNum)
                {
                    MessageBox.Show("VOCÊ GANHOU 🥳🎉", "Mesangem de informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tentativasAtual--;
                    salvarDados(Resultado.SUCCESS);
                    voltarTelaInicial();
                }
                else
                {
                    Console.WriteLine("errou");

                    // muda a cor do botao e deixa desabilitado
                    clickedButton.BackColor = Color.Red;
                    clickedButton.Text = "X";
                    clickedButton.Enabled = false;

                    // diminui sempre que o usuario erra
                    tentativasAtual--;
                    // imprime na tela do jogo
                    labelTentativas.Text = tentativasAtual.ToString();

                    if (tentativasAtual == 0)
                    {
                        MessageBox.Show("VOCÊ PERDEU 😱😰", "Mesangem de informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        salvarDados(Resultado.WRONG);
                        voltarTelaInicial();
                    }
                }
            }
        }

        private void salvarDados(Enum resultado)
        {
            int id = pegandoID();
            if (checkConnection())
            {
                try
                {
                    connect.Open();


                    // salvando historico da partida
                    string InsertData = "INSERT INTO Partida (id_jogador, numero_tentativa, resultado, dificuldade) VALUES (@id_j, @numero_tent, @result, @dific)";

                    using (SqlCommand cmd = new SqlCommand(InsertData, connect))
                    {
                        Console.Write(id + "   salvar dados");
                        cmd.Parameters.AddWithValue("@id_j", id);
                        cmd.Parameters.AddWithValue("@numero_tent", dificuldadesTentativas[Dificuldade.dificuldadeEscolhaJogador] - tentativasAtual);
                        cmd.Parameters.AddWithValue("@result", Convert.ToInt32(resultado) == 1 ? "Ganhou" : "Perdeu");
                        cmd.Parameters.AddWithValue("@dific", Dificuldade.dificuldadeEscolhaJogador);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no banco de dados: " + ex, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Erro no banco de dados: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
        }


        // funcao unicamente para pegar o id do usuario
        private int pegandoID()
        {
            int id = 0;
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string IdJogador = "SELECT id_jogador FROM Jogador WHERE nome = @nomej";

                    using (SqlCommand cmd = new SqlCommand(IdJogador, connect))
                    {
                        cmd.Parameters.AddWithValue("@nomej", Form1.nome.Trim());
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = int.Parse(reader["id_jogador"].ToString()); ;
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
            return id;
        }

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void voltarTelaInicial()
        {
            TelaPrincipal principal = new TelaPrincipal();
            principal.Show();

            this.Hide();
        }
    }
}
