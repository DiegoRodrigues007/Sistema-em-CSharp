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


namespace Projeto1
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            limparCampos();
            txtNome.Focus();
            habilitarBotoes();
            btnNovo.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            desabilitaCampos();
            desabilitaBotoes();
            btnNovo.Enabled = true;

            try
            {
                if (!txtNome.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtCpf.Text.Equals("") && !txtTelefone.Text.Equals(""))
                {
                    CadastroCliente cadCliente = new CadastroCliente();
                    cadCliente.Nome = txtNome.Text;
                    cadCliente.Cpf = txtCpf.Text;
                    cadCliente.Telefone = txtTelefone.Text;
                    cadCliente.Endereco = txtEndereco.Text;

                    if (cadCliente.CadastrarClienteNoBancoDeDados())
                    {
                        MessageBox.Show($"O cliente { cadCliente.Nome } foi cadastrado com sucesso!");
                        limparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel realizar o cadastro");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente");
                    limparCampos();
                    txtNome.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao cadastrar clientes: " + ex.Message);
                
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitaCampos();
            desabilitaBotoes();
            btnNovo.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitaBotoes();
            desabilitaCampos();
            limparCampos();
            btnNovo.Enabled = true;
        }

        
        private void desabilitaBotoes()
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
        }

        
        private void habilitarBotoes()
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;
        }

        
        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtCpf.Enabled = true;
            txtTelefone.Enabled = true;
        }

        
        private void desabilitaCampos()
        {
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtCpf.Enabled = false;
            txtTelefone.Enabled = false;
        }
        
        private void limparCampos()
        {
            txtNome.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtTelefone.Text = string.Empty;
        }

        
    }
}
