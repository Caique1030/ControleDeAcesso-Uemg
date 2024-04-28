using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROLEACESSOO.S
{
    public partial class UsuarioCadastro : Form
    {

        Usuarios usuario = new Usuarios();
        public UsuarioCadastro(Usuarios usuario, Operacao operacao)
        {
            InitializeComponent();
            this.usuario = usuario;

            if (operacao == Operacao.Adicionar && usuario.Id == 0)
            {
                this.Text += "Adicionar ";
            }
            else if(operacao == Operacao.Alterar )
            {

                this.Text += "Alterar ";
            }
            else if (operacao == Operacao.Excluir)
            {

                this.Text += "Excluir ";
                TravarControles();
                btSalvar.Visible = false;
                btOk.Visible = true;
                btOk.Text = " Excluir ";

            }
            else if (operacao == Operacao.Consultar)
            {

                this.Text += "Consultar ";
                TravarControles();
                btSalvar.Visible = false;
                btOk.Visible = true; 
                btOk.Text = " Fechar ";
            }


            //transferindo dados do usuario para o form 
            LBID.Text = usuario.Id.ToString();
            txtEmail.Text = usuario.Email;
            txtNome.Text = usuario.Nome;
            txtNomeCurto.Text = usuario.NomeCurto;
            cmbAtivo.Text = usuario.Ativo == 'S' ? "SIM" : "NAO ";
        }

        private void TravarControles()
        {

            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            txtNomeCurto.Enabled = false;
            cmbAtivo.Enabled  = false;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuarioCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            //transferindo os dados do form para o objeto 
            usuario.Id = Convert.ToInt32(LBID.Text);
            usuario.Email = txtEmail.Text;
            usuario.Nome = txtNome.Text;
            usuario.NomeCurto = txtNomeCurto.Text;
            usuario.Ativo = cmbAtivo.Text[0];

            var result = usuario.Salvar(usuario);
            if (result == "ok")
            {
                MessageBox.Show("Salvo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possivel salvar , tente novamente .\n" + result);
                usuario.Id = -1;
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (btOk.Text == "Fechar")
            {
                this.Close();
            }
            var resposta = MessageBox.Show("Deseja Excluir ? ", "Excluir ",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (resposta == DialogResult.Yes)
            {
                var result = usuario.Excluir(usuario.Id);
                if (result)
                {
                    MessageBox.Show("Excluido");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possivel excluir , tente novamente ");
                    usuario.Id = -1;
                }
            }
        }
    }
}
