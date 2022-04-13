using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crud_Csharp.Classes;
using MySql.Data.MySqlClient;

namespace Crud_Csharp
{
    public partial class FormCliente : MetroFramework.Forms.MetroForm
    {

        
        public FormCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try // Tente
            {
                // Abrir conexão
                var banco = Banco.Abrir();

                banco.CommandText = "insert into cad_cliente(nome, numero) values(@nome, @numero)";

                // Parametros
                banco.Parameters.AddWithValue("@nome", txtNome.Text);
                banco.Parameters.AddWithValue("@numero", txtNumero.Text);

                // Execute
                banco.ExecuteNonQuery();

                // Limpar parametros
                banco.Parameters.Clear();

                // Fecha Conexão
                banco.Connection.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try // Tente
            {
                // Abrir conexão
                var banco = Banco.Abrir();

                banco.CommandText = "update cad_cliente set nome = @nome, numero = @numero where id = @id";

                // Parametros
                banco.Parameters.AddWithValue("@id", txtId.Text);
                banco.Parameters.AddWithValue("@nome", txtNome.Text);
                banco.Parameters.AddWithValue("@numero", txtNumero.Text);

                // Execute
                banco.ExecuteNonQuery();

                // Limpar parametros
                banco.Parameters.Clear();

                // Fecha Conexão
                banco.Connection.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try // Tente
            {
                // Abrir conexão
                var banco = Banco.Abrir();

                banco.CommandText = "delete from cad_cliente where id = @id";

                // Parametros
                banco.Parameters.AddWithValue("@id", txtId.Text);

                // Execute
                banco.ExecuteNonQuery();

                // Limpar parametros
                banco.Parameters.Clear();

                // Fecha Conexão
                banco.Connection.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try // Tente
            {
                // Abrir conexão
                var banco = Banco.Abrir();

                banco.CommandText = "select * from cad_cliente where id = @id";

                // Parametros
                banco.Parameters.AddWithValue("@id", txtId.Text);

                // Var de leitura
                var dr = banco.ExecuteReader();

                // Consulta
                while (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    txtNumero.Text = Convert.ToString(dr["numero"]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try // Tente
            {
                // Abrir conexão
                var banco = Banco.Abrir();

                banco.CommandText = "select * from cad_cliente";

                var da = new MySqlDataAdapter(banco);

                DataTable dt = new DataTable();

                da.Fill(dt);

                gridClientes.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
