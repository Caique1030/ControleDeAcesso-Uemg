namespace CONTROLEACESSOO.S
{
    partial class frmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CADASTROToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.TecnicoResponsavel = new System.Windows.Forms.ToolStripMenuItem();
            this.Agendamento = new System.Windows.Forms.ToolStripMenuItem();
            this.Faturamento = new System.Windows.Forms.ToolStripMenuItem();
            this.EmetirNota = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultarFaturamento = new System.Windows.Forms.ToolStripMenuItem();
            this.ComissaoTecnica = new System.Windows.Forms.ToolStripMenuItem();
            this.Acesso = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.ControleAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.AtivarOuInativar = new System.Windows.Forms.ToolStripMenuItem();
            this.AcessoUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.Sair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CADASTROToolStripMenuItem,
            this.Faturamento,
            this.Acesso,
            this.Sair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(332, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // CADASTROToolStripMenuItem
            // 
            this.CADASTROToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clientes,
            this.TecnicoResponsavel,
            this.Agendamento});
            this.CADASTROToolStripMenuItem.Name = "CADASTROToolStripMenuItem";
            this.CADASTROToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.CADASTROToolStripMenuItem.Text = "CADASTRO";
            // 
            // Clientes
            // 
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(202, 22);
            this.Clientes.Text = "CLIENTES";
            this.Clientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // TecnicoResponsavel
            // 
            this.TecnicoResponsavel.Name = "TecnicoResponsavel";
            this.TecnicoResponsavel.Size = new System.Drawing.Size(202, 22);
            this.TecnicoResponsavel.Text = "TECNICO RESPONSAVEL";
            this.TecnicoResponsavel.Click += new System.EventHandler(this.eNDEREÇOToolStripMenuItem_Click);
            // 
            // Agendamento
            // 
            this.Agendamento.Name = "Agendamento";
            this.Agendamento.Size = new System.Drawing.Size(202, 22);
            this.Agendamento.Text = "AGENDAMENTO";
            this.Agendamento.Click += new System.EventHandler(this.Agendamento_Click);
            // 
            // Faturamento
            // 
            this.Faturamento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmetirNota,
            this.CancelarNota,
            this.ConsultarNota,
            this.ConsultarFaturamento,
            this.ComissaoTecnica});
            this.Faturamento.Name = "Faturamento";
            this.Faturamento.Size = new System.Drawing.Size(100, 20);
            this.Faturamento.Text = "FATURAMENTO";
            // 
            // EmetirNota
            // 
            this.EmetirNota.Name = "EmetirNota";
            this.EmetirNota.Size = new System.Drawing.Size(269, 22);
            this.EmetirNota.Text = "EMETIR NOTA FISCAL";
            this.EmetirNota.Click += new System.EventHandler(this.EmetirNota_Click);
            // 
            // CancelarNota
            // 
            this.CancelarNota.Name = "CancelarNota";
            this.CancelarNota.Size = new System.Drawing.Size(269, 22);
            this.CancelarNota.Text = "CANCELAR NOTA FISCAL";
            // 
            // ConsultarNota
            // 
            this.ConsultarNota.Name = "ConsultarNota";
            this.ConsultarNota.Size = new System.Drawing.Size(269, 22);
            this.ConsultarNota.Text = "CONSULTAR NOTA FISCAL";
            // 
            // ConsultarFaturamento
            // 
            this.ConsultarFaturamento.Name = "ConsultarFaturamento";
            this.ConsultarFaturamento.Size = new System.Drawing.Size(269, 22);
            this.ConsultarFaturamento.Text = "CONSULTAR FATURAMENTO DO MES";
            // 
            // ComissaoTecnica
            // 
            this.ComissaoTecnica.Name = "ComissaoTecnica";
            this.ComissaoTecnica.Size = new System.Drawing.Size(269, 22);
            this.ComissaoTecnica.Text = "COMISSÃO TECNICA";
            // 
            // Acesso
            // 
            this.Acesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroUsuario,
            this.ControleAcesso});
            this.Acesso.Name = "Acesso";
            this.Acesso.Size = new System.Drawing.Size(62, 20);
            this.Acesso.Text = "ACESSO";
            // 
            // CadastroUsuario
            // 
            this.CadastroUsuario.Name = "CadastroUsuario";
            this.CadastroUsuario.Size = new System.Drawing.Size(200, 22);
            this.CadastroUsuario.Text = "CADASTRO USUARIO";
            this.CadastroUsuario.Click += new System.EventHandler(this.CadastroUsuario_Click);
            // 
            // ControleAcesso
            // 
            this.ControleAcesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AtivarOuInativar,
            this.AcessoUsuario});
            this.ControleAcesso.Name = "ControleAcesso";
            this.ControleAcesso.Size = new System.Drawing.Size(200, 22);
            this.ControleAcesso.Text = "CONTROLE DE ACESSO ";
            // 
            // AtivarOuInativar
            // 
            this.AtivarOuInativar.Name = "AtivarOuInativar";
            this.AtivarOuInativar.Size = new System.Drawing.Size(183, 22);
            this.AtivarOuInativar.Text = "ATIVAR OU INATIVAR";
            // 
            // AcessoUsuario
            // 
            this.AcessoUsuario.Name = "AcessoUsuario";
            this.AcessoUsuario.Size = new System.Drawing.Size(183, 22);
            this.AcessoUsuario.Text = "ACESSO";
            this.AcessoUsuario.Click += new System.EventHandler(this.AcessoUsuario_Click);
            // 
            // Sair
            // 
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(43, 20);
            this.Sair.Text = "SAIR";
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 368);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CADASTROToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Clientes;
        private System.Windows.Forms.ToolStripMenuItem TecnicoResponsavel;
        private System.Windows.Forms.ToolStripMenuItem Faturamento;
        private System.Windows.Forms.ToolStripMenuItem Acesso;
        private System.Windows.Forms.ToolStripMenuItem Sair;
        private System.Windows.Forms.ToolStripMenuItem Agendamento;
        private System.Windows.Forms.ToolStripMenuItem EmetirNota;
        private System.Windows.Forms.ToolStripMenuItem CancelarNota;
        private System.Windows.Forms.ToolStripMenuItem ConsultarNota;
        private System.Windows.Forms.ToolStripMenuItem ConsultarFaturamento;
        private System.Windows.Forms.ToolStripMenuItem ComissaoTecnica;
        private System.Windows.Forms.ToolStripMenuItem CadastroUsuario;
        private System.Windows.Forms.ToolStripMenuItem ControleAcesso;
        private System.Windows.Forms.ToolStripMenuItem AtivarOuInativar;
        private System.Windows.Forms.ToolStripMenuItem AcessoUsuario;
    }
}

