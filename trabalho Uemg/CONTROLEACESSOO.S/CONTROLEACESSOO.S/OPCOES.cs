using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROLEACESSOO.S
{
    public class Opcoes
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte Nivel { get; set; }

        //construtor
        public Opcoes(string nome, string descricao, byte nivel) {

            Nome = nome;
            Descricao = descricao;
            Nivel = nivel;
        }

        public static HashSet<Opcoes> Criar(MenuStrip menu)//hashset e uma coleção de objetos "opcoes"
        {
            var hashsetOpcoes = new HashSet<Opcoes>();

            //Nivel 1
            foreach (ToolStripMenuItem item in menu.Items)
            {
                var descricao1 = item.Text;
                if (item.HasDropDownItems)
                {
                    //Nivel 2
                    foreach (ToolStripMenuItem opcao in item.DropDownItems)
                    {
                        var descricao2 = descricao1 + " / " + opcao.Text;
                        if (opcao.HasDropDownItems)
                        {
                            //nivel 3
                            foreach (ToolStripMenuItem subOpcao in opcao.DropDownItems)
                            {
                                var descricao3 = descricao2 + " / " + subOpcao.Text;
                                hashsetOpcoes.Add(new Opcoes(subOpcao.Name, descricao3, 3));
                            }
                        }
                        else
                        {
                            hashsetOpcoes.Add(new Opcoes(opcao.Name, descricao2, 2));
                        }
                    }
                }
                else
                {
                    hashsetOpcoes.Add(new Opcoes(item.Name, descricao1, 1));
                }
            }
                return hashsetOpcoes;
            }

        public static bool SalvarMenu(HashSet<Opcoes> opcoes)
        {
            var sql = "INSERT INTO MenuOpcoes(nome , descricao ,nivel ) VALUES (@nome , @descricao , @nivel) ";

            try
            {
                using (var cn = new SqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                        cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                        cmd.Parameters.Add("@nivel", SqlDbType.TinyInt);

                        foreach (var item in opcoes)
                        {
                            cmd.Parameters["@nome"].Value = item.Nome;
                            cmd.Parameters["@descricao"].Value = item.Descricao;
                            cmd.Parameters["@nivel"].Value = item.Nivel;

                                cmd.ExecuteNonQuery();
                            }

                        }
                    }
                    return true;
                }
                catch(Exception ex)

        {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }


        }
    }
    
