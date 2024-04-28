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
    public partial class frmMenu : Form
    {
       public static Usuarios usuario = new Usuarios(); // contem todos os paremtros da classe usuario 
        public frmMenu()
        {

            InitializeComponent();

            using (var  frm = new frmUsuarioLogin())//chamando o formulario login 
                frm.ShowDialog(); 

            usuario.MEnuAcesso = Acessos.GetMenuAcessos(usuario.Id);//menu acesso e uma propriedado da classe usuario 
            // get acesso esta lendo /retornando uma lista de acesso ,esta na classe acesso 
           // ConfigurarAcesso(usuario.MEnuAcesso);
        }

        private void eNDEREÇOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmTecnico())
                frm.ShowDialog();
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CadastroUsuario_Click(object sender, EventArgs e)
        {
            using(var  frm = new frmUsuarios())
            {
                frm.ShowDialog();   
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void AcessoUsuario_Click(object sender, EventArgs e)
        {
            using ( var frm = new frmUsuarios("selecionar"))
            {
                frm.ShowDialog();
            }
        }
        private void ConfigurarAcesso(List<Acessos> usuarioAcessos)//esta recebendo uma lista de acesso 
        {
            foreach(ToolStripMenuItem item in menuStrip1.Items)//lendo o menu se esta atribuido ou nao 
            {
                SetMenu(item, usuarioAcessos);
                foreach(ToolStripMenuItem opcao in item.DropDownItems)
                {
                    SetMenu(opcao, usuarioAcessos);

                    foreach (ToolStripMenuItem subOpcao in opcao.DropDownItems)
                    SetMenu(subOpcao, usuarioAcessos);

                }
            }
        }

        private void SetMenu(ToolStripMenuItem opcao , List<Acessos> usuarioAcessos)//esta recebendo uma opcao do menu e a lista de acesso do usuairo , checando se esta liberado ou nao 
        {
            foreach(var item in usuarioAcessos)
            {
                if(item.NomeOpcao == opcao.Name)
                {
                    if(item.Liberado == 'N')//checando se esta liberado , caso "nao " ele retorna false no menu 
                        opcao.Enabled= false;

                    break;//finalizar o foreach
                }
            }
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            // if (Acessos.OpcaoLiberada("Clientes", usuario.MEnuAcesso))
            using (var frm = new frmClientes())
                frm.ShowDialog();
           // MessageBox.Show("Liberado ");
           // else
               // MessageBox.Show("Acesso Negado");
        }

        private void EmetirNota_Click(object sender, EventArgs e)
        {
            if (Acessos.OpcaoLiberada("EmetirNota", usuario.MEnuAcesso))
                MessageBox.Show("Liberado ");
            else
                MessageBox.Show("Acesso Negado");
        }

        private void Agendamento_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAgendamento())
                frm.ShowDialog();
        }
    }
}
