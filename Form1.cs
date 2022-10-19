using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Interface
{
    public partial class Form1 : Form
    {
       
        
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void Form1_Load_1(object sender, EventArgs e)
            {
                //inserindo dados CboxModelo
                CboxModelo.Items.Add("Bermudas");
                CboxModelo.Items.Add("Calças");
                CboxModelo.Items.Add("Camisas");
                CboxModelo.Items.Add("Camisetas");
                //inserindo dados CboxTamanho
                CboxTamanho.Items.Add("P");
                CboxTamanho.Items.Add("M");
                CboxTamanho.Items.Add("G");
                CboxTamanho.Items.Add("36");
                CboxTamanho.Items.Add("38");
                CboxTamanho.Items.Add("40");
                CboxTamanho.Items.Add("42");
                //Inserindo dados CboxCor
                CboxCor.Items.Add("Azul");
                CboxCor.Items.Add("Amarelo");
                CboxCor.Items.Add("Preto");
                CboxCor.Items.Add("Vermelho");

            }

            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    MySqlConnection objecon = new MySqlConnection("server=localhost; port=3306; User Id=root; database=lojaDN; password=root");
                    objecon.Open();
                    MessageBox.Show("Conectado! ");
                    objecon.Close();
                }
                catch
                {
                    MessageBox.Show("Não conectou! ");
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                try
            {
                MySqlConnection objecon = new MySqlConnection("server=localhost; port=3306; User Id=root; database=lojaDN; password=root");
                objecon.Open();

                //Comando SQL de inserção
                MySqlCommand objcomm = new MySqlCommand("insert into roupas ( cod_roupas , modelo , tamanho , cor , qtd ) values (notnull , ? , ? , ? , ? );", objecon);

                //Parametros do comando SQL
                objcomm.Parameters.Add("@modelo ", MySqlDbType.VarChar, 20).Value = CboxModelo.SelectedItem.ToString();
                objcomm.Parameters.Add("@tamanho ", MySqlDbType.VarChar, 20).Value = CboxTamanho.SelectedItem.ToString();
                objcomm.Parameters.Add("@cor ", MySqlDbType.VarChar, 20).Value = CboxCor.SelectedItem.ToString();
                objcomm.Parameters.Add("@qtd", MySqlDbType.VarChar, 5).Value = txtQtd.Text;

                //comando para executar a querry
                objcomm.ExecuteNonQuery();

                NewMethod();

                //Fecha a conexão
                objecon.Close();
            }
            catch (Exception erro)
                {
                    MessageBox.Show("Cadastro falhou! " + erro);
                }
            }

        private static void NewMethod()
        {
            MessageBox.Show("Cadastrado com sucesso! ");
        }

        private void button3_Click(object sender, EventArgs e)
            {
                //Botao remover
                try
                {
                    MySqlConnection objecon = new MySqlConnection("server=localhost; port=3307; User Id=root; database=lojaDN; password=usbw");
                    objecon.Open();
                    //Comandos SQL com os paramêtros
                    MySqlCommand objcomm = new MySqlCommand("delete from roupas where cod_roupas = ? ", objecon);
                    objcomm.Parameters.Clear();
                    objcomm.Parameters.Add("@id", MySqlDbType.Int32).Value = txtCod.Text;

                    //Executa a query
                    objcomm.CommandType = CommandType.Text;
                    objcomm.ExecuteNonQuery();

                    //Fecha a conexão
                    objecon.Close();

                    MessageBox.Show("Removido com sucesso! ");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Não foi possível remover! " + erro);
                }
            }
            private void button4_Click(object sender, EventArgs e)
            {
                //Botão Consultar
                try
                {

                    MySqlConnection objecon = new MySqlConnection("server=localhost; port=3307; User Id=root; database=lojinha; password=usbw");
                    objecon.Open();

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao buscar! " + erro);
                }
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }
        }
    }