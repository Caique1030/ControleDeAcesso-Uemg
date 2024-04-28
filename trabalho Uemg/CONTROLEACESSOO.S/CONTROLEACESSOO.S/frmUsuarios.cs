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
    public partial class frmUsuarios : Form
    {

        Usuarios usuario = new Usuarios();
        public frmUsuarios(string opcao="")
        {
            InitializeComponent();
            dataGridView1.DataSource = Usuarios.BuscarTodos();
            ConfigurarGrade();
        
            if (opcao.ToLower() == "selecionar")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton4.Visible = false;

                Selecionar.Visible = true;

                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
                toolStripSeparator3.Visible = false;
                
            }
        }
        private void ConfigurarGrade()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial ", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            //dataGridView1.Columns["id"].Visible = false;

            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["email"].Width = 250;
            dataGridView1.Columns["email"].ReadOnly = true;

            dataGridView1.Columns["nome"].HeaderText = "Nome";
            dataGridView1.Columns["nome"].Width = 310;
            dataGridView1.Columns["nome"].ReadOnly = true;

            dataGridView1.Columns["nomeCurto"].HeaderText = "Nome Curto";
            dataGridView1.Columns["nomeCurto"].Width = 150;
            dataGridView1.Columns["nomeCurto"].ReadOnly = true;

            dataGridView1.Columns["ativo"].HeaderText = "Ativo";
            dataGridView1.Columns["ativo"].Width = 60;
            dataGridView1.Columns["ativo"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ativo"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ativo"].ReadOnly = true;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

       
        
        
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                //transferindo os dados da grade (linha) para o objeto usuario 
            {
                TransferirGradeParaUsuario();
               
                using (var frm = new UsuarioCadastro(usuario, Operacao.Alterar))
                {
                    frm.ShowDialog();
                    if(usuario.Id != -1)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value= usuario.Id;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["email"].Value = usuario.Email;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nome"].Value = usuario.Nome;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nomeCurto"].Value = usuario.NomeCurto;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ativo"].Value = usuario.Ativo;




                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReiniciarUsuario(usuario);
            using (var frm = new UsuarioCadastro(usuario,Operacao.Adicionar))
            {
                frm.ShowDialog();
                dataGridView1.DataSource = Usuarios.BuscarTodos();
            }

        }
        private void ReiniciarUsuario(Usuarios usuario)
        {
            usuario.Id = 0;
            usuario.Email = "";
            usuario.Nome = "";
            usuario.NomeCurto = "";
            usuario.Ativo = 'S';
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                TransferirGradeParaUsuario();
                using (var frm = new UsuarioCadastro(usuario,Operacao.Excluir))
                {
                    frm.ShowDialog();

                    if (usuario.Id != -1)
                        dataGridView1.DataSource = Usuarios.BuscarTodos();
                }
            }
        }
        private void TransferirGradeParaUsuario()
        {
            //transferindo os dados da grade (linha) para o objeto usuario
            usuario.Id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value);
            usuario.Email = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["email"].Value.ToString();
            usuario.Nome = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nome"].Value.ToString();
            usuario.NomeCurto = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nomeCurto"].Value.ToString();
            usuario.Ativo = Convert.ToChar(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ativo"].Value);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                TransferirGradeParaUsuario();
                using (var frm = new UsuarioCadastro(usuario,Operacao.Consultar))
                {
                    frm.ShowDialog();

                    if (usuario.Id != -1)
                        dataGridView1.DataSource = Usuarios.BuscarTodos();
                }
            }
        }

        private void Selecionar_Click(object sender, EventArgs e)
        {

            TransferirGradeParaUsuario();
            using (var frm = new frmUsuariosAcesso(usuario))
            {
                frm.ShowDialog();
            }

        }
    }
}
