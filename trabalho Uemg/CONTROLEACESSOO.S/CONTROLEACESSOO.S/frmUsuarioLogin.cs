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
    public partial class frmUsuarioLogin : Form
    {
        Usuarios usuario = new Usuarios();  
        bool autenticado = false;
        public frmUsuarioLogin()

        {
            InitializeComponent();
            this.usuario = frmMenu.usuario; //ligando o usuario ao formulario login 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            autenticado = ValidarUsuario();

            if(autenticado)
                this.Close();
        }
        private bool ValidarUsuario()
        {
            usuario.Email = txtUsuario.Text;// usuario email , recebe o textbox usuario 
            var resposta = usuario.LoginUsuario(usuario, txtSenha.Text); //passando os dados para o banco conferir o login do usuario 
            if (resposta == "ok")//caso seja verdade , ira retornar 
                return true;

            else
            {
                MessageBox.Show(resposta);//caso nao seja ira enviar a resposta falsa e as menssagens criadas
                return false;

            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
           Application.Exit();  
        }

        private void frmUsuarioLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmUsuarioLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!autenticado)
                Application.Exit();

            
        }
    }
}
