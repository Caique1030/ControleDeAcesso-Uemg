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
    public partial class frmUsuariosAcesso : Form
    {
        public frmUsuariosAcesso(Usuarios usuario)
        {
            InitializeComponent();
            //transferi os dados do objeto usuario para o form
            lblID.Text = usuario.Id.ToString();
            lblEmail.Text = usuario.Email;
            lblNomeCurto.Text = usuario.NomeCurto;

            var listaAcessos = Acessos.GetMenuAcessos(Convert.ToInt32(lblID.Text));
            ConfigurarGrade(listaAcessos);


        }
        private void ConfigurarGrade(List<Acessos>listaAcessos)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial ", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            //id da opcao do menu 
            dataGridView1.Columns.Add("id_opcao","id");
            dataGridView1.Columns["id_opcao"].Visible = false;

            dataGridView1.Columns.Add("nome", "Nome");
            dataGridView1.Columns["nome"].Visible = false;

            dataGridView1.Columns.Add("descricao", "Descricao");
            dataGridView1.Columns["descricao"].Width = 380;
            dataGridView1.Columns["descricao"].ReadOnly = false; 

            dataGridView1.Columns.Add("nivel", "Nivel");
            dataGridView1.Columns["nivel"].Visible = false;


            //Id do Registro do acesso 
            dataGridView1.Columns.Add("id_registro", "Id do registro ");
            dataGridView1.Columns["id_registro"].Visible = false;

            dataGridView1.Columns.Add("id_usuario", "Usuário");
            dataGridView1.Columns["id_usuario"].Visible = false;

            //situaçao corrente 
            dataGridView1.Columns.Add("liberado", "Liberado");
            dataGridView1.Columns["liberado"].Visible = false;

            dataGridView1.Columns.Add("liberadoAdic", "Adicionar");
            dataGridView1.Columns["liberadoAdic"].Visible = false;

            dataGridView1.Columns.Add("liberadoAlt", "Alterar");
            dataGridView1.Columns["liberadoAlt"].Visible = false;

            dataGridView1.Columns.Add("liberadoExclu", "Excluir");
            dataGridView1.Columns["liberadoExclu"].Visible = false;

            dataGridView1.Columns.Add("liberadoConsul", "Consultar");
            dataGridView1.Columns["liberadoConsul"].Visible = false;

            //adicionando uma coluna na datagrid
           /*var acesso = new DataGridViewCheckBoxColumn();
            acesso.Name = "acesso";
            acesso.HeaderText = "Liberar";
            acesso.Width = 60;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);
           */

            var acesso = new DataGridViewCheckBoxColumn();
            acesso.Name = "acessoAdicionar";
            acesso.HeaderText = "Adic";
            acesso.Width = 60;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);

            acesso = new DataGridViewCheckBoxColumn();
            acesso.Name = "acessoAlterar";
            acesso.HeaderText = "Alt";
            acesso.Width = 60;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);

            acesso = new DataGridViewCheckBoxColumn();
            acesso.Name = "acessoExcluir";
            acesso.HeaderText = "Excl";
            acesso.Width = 60;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);

            acesso = new DataGridViewCheckBoxColumn();
            acesso.Name = "acessoConsultar";
            acesso.HeaderText = "Consult";
            acesso.Width = 60;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);



            try
            {
                foreach (var item in listaAcessos)
                {
                    //adicionando linhas e passando as colunas no datagrid. os dados estao vindo da lista de acesso 
                    dataGridView1.Rows.Add(item.IdOpcao,item.NomeOpcao,item.DescricaoOpcao,item.NivelOpcao,item.IdRegistro
                        ,Convert.ToInt32(lblID.Text),item.Liberado,
                        item.LiberadoAdicionar , item.LiberadoAlterar, item.LiberadoExcluir, item.LiberadoConsultar, item.LiberadoAdicionar =='S'?true:false, item.LiberadoAlterar == 'S' ? true : false
                        , item.LiberadoExcluir == 'S' ? true : false, item.LiberadoConsultar == 'S' ? true : false);   
                }
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                    }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UsuariosAcesso_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EndEdit();
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            var listaAcesso = new List<Acessos>();//declarando a lista de acesso 
            foreach (DataGridViewRow row in dataGridView1.Rows)//percorrendo o data grid 
            {
                
                var chkAdic = Convert.ToBoolean(row.Cells["acessoAdicionar"].Value) ? 'S' : 'N';
                var chkAlt = Convert.ToBoolean(row.Cells["acessoAlterar"].Value) ? 'S' : 'N';
                var chkExclu = Convert.ToBoolean(row.Cells["acessoExcluir"].Value) ? 'S' : 'N';
                var chkConsult = Convert.ToBoolean(row.Cells["acessoConsultar"].Value) ? 'S' : 'N';


                if (Convert.ToChar(row.Cells["liberadoAdic"].Value) != chkAdic || Convert.ToChar(row.Cells["liberadoAlt"].Value)!= chkAlt 
                        || Convert.ToChar(row.Cells["liberadoExclu"].Value)!=chkExclu 
                        || Convert.ToChar(row.Cells["liberadoConsul"].Value)!=chkConsult)
                   {
                    listaAcesso.Add(new Acessos(Convert.ToInt32(row.Cells["id_opcao"].Value),//checando o id  
                    Convert.ToInt32(row.Cells["id_registro"].Value),chkAdic,chkAlt,chkConsult,chkExclu));//convertendo os dados para a lista para cada coluna  , para o list
                   }           
            }
            var id_usuario = Convert.ToInt32(lblID.Text);//declarando o id do usario para o Label 
            if(listaAcesso.Count > 0)//conferindo se a quantidade de id e maior do que 0 , se for menor nao ira salvar 
            {
                if (new Acessos().Salvar(id_usuario, listaAcesso) == "ok")//instacia o objeto usario para usar o metodo salvar ,verifico tambem o retorno 
                {
                    MessageBox.Show("Acessos Salvos! ");
                    Close();
                }
                else
                    MessageBox.Show("Não foi possivel salvar! \n  Tente novamente ou tente mais tarde !");
            }
            this.Close();
        }
    }
}
