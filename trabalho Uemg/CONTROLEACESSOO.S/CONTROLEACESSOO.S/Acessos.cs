using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLEACESSOO.S
{
    public class Acessos
    {
        //Join no banco de dados
        public int IdOpcao { get; set; }
        public string NomeOpcao { get; set; }
        public string DescricaoOpcao { get; set; }
        public byte NivelOpcao { get; set; }
        public char Liberado { get; set; }
        public int IdRegistro { get; set; }
        public char LiberadoAdicionar { get; set; }
        public char LiberadoAlterar { get; set; }
        public char LiberadoExcluir { get; set; }
        public char LiberadoConsultar { get; set; }



        public Acessos() { }

        public Acessos(int idOpcao, string nomeOpcao, string descricaoOpcao, byte nivelOpcao, char liberado, int idRegitro, char liberadoAdicionar
            , char liberadoAlterar, char liberadoExcluir, char liberadoConsultar)
        {
            this.IdOpcao = idOpcao;
            NomeOpcao = nomeOpcao;
            DescricaoOpcao = descricaoOpcao;
            NivelOpcao = nivelOpcao;
            Liberado = liberado;
            IdRegistro = idRegitro;
            LiberadoAdicionar = liberadoAdicionar;
            LiberadoAlterar = liberadoAlterar;
            LiberadoExcluir = liberadoExcluir;
            LiberadoConsultar = liberadoConsultar;

        }

        public Acessos(int idOpcao, int idRegistro, char liberadoAdicionar
            , char liberadoAlterar, char liberadoExcluir, char liberadoConsultar)
        {
            IdOpcao = idOpcao;
            // Liberado = liberado;
            IdRegistro = idRegistro;
            LiberadoAdicionar = liberadoAdicionar;
            LiberadoAlterar = liberadoAlterar;
            LiberadoExcluir = liberadoExcluir;
            LiberadoConsultar = liberadoConsultar;
        }
        public static List<Acessos> GetMenuAcessos(int id_usuario)
        {
            var sql = "SELECT o.id, o.nome nomeOpcao , o.descricao descricaoOpcao, o.nivel , ISNULL(a.Liberado,'N')liberado," +
                " ISNULL(a.id,0) id_registro,ISNULL(a.LiberadoAdicionar,'N')liberadoAdicionar," +
                "ISNULL(a.LiberadoAlterar,'N')liberadoAlterar, " +
                "ISNULL(a.LiberadoExcluir,'N')liberadoExcluir,ISNULL(a.LiberadoConsultar,'N')liberadoConsultar FROM MenuOpcoes o LEFT JOIN(SELECT id_usuario,id_opcao,liberado,id ," +
                "liberadoAdicionar,liberadoAlterar ,liberadoExcluir,liberadoConsultar FROM MenuAcesso WHERE id_usuario=@id_usuario) a ON o.id = a.id_opcao";
            var listaAcesso = new List<Acessos>();
            try
            {
                using (var cn = new SqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var da = new SqlDataAdapter(sql, cn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id_usuario", id_usuario);
                        using (var dt = new DataTable())
                        {
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)//percorre o datatable e transforma em lista
                            {
                                listaAcesso.Add(new Acessos((int)row["id"], (string)row["nomeOpcao"], (string)row["descricaoOpcao"],
                                    (byte)row["nivel"], Convert.ToChar(row["liberado"]), (int)row["id_Registro"], Convert.ToChar(row["liberadoAdicionar"]),
                                    Convert.ToChar(row["liberadoAlterar"]), Convert.ToChar(row["liberadoExcluir"]), Convert.ToChar(row["liberadoConsultar"]))); //lista de objetos , passado para o objeto acesso 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listaAcesso;
        }


        public string Salvar(int idUsuario, List<Acessos> listaAcessos)//Metodo Salvar os campos liberados para o usuario 
        {
            try
            {
                using (var cn = new SqlConnection(Program.strConn))
                {
                    cn.Open();
                    foreach (var item in listaAcessos)//passando pela lista
                    {
                        var sql = "";
                        if (item.IdRegistro == 0)//verificando se a propriedade registro e 0 
                        
                            sql = "INSERT INTO MEnuAcesso (id_opcao ,id_usuario,liberado,liberadoAdicionar,liberadoAlterar,liberadoExcluir,liberadoConsultar) " +
                                "VALUES (@id_opcao,@id_usuario,@liberado,@liberadoAdicionar,@liberadoAlterar,@liberadoExcluir,@liberadoConsultar)";
                        else
                            sql = "UPDATE MEnuAcesso SET id_opcao=@id_opcao, id_usuario=@id_usuario , Liberado=@liberado,LiberadoAdicionar=@liberadoAdicionar,LiberadoAlterar=@liberadoAlterar,LiberadoExcluir=@liberadoExcluir,LiberadoConsultar=@liberadoConsultar" +
                                " WHERE id=@id";

                            using (var cmd = new SqlCommand(sql, cn))
                            {
                                if (item.IdRegistro > 0)
                                    cmd.Parameters.AddWithValue("@id", item.IdRegistro);

                                cmd.Parameters.AddWithValue("@id_opcao", item.IdOpcao);
                                cmd.Parameters.AddWithValue("@id_usuario",idUsuario);
                                cmd.Parameters.AddWithValue("@liberado", item.Liberado);
                                cmd.Parameters.AddWithValue("@liberadoAdicionar", item.LiberadoAdicionar);
                                cmd.Parameters.AddWithValue("@liberadoAlterar", item.LiberadoAlterar);
                                cmd.Parameters.AddWithValue("@liberadoExcluir", item.LiberadoExcluir);
                                cmd.Parameters.AddWithValue("@liberadoConsultar", item.LiberadoConsultar);

                            cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    return "ok";
                }
                catch (Exception ex)
                 {
                return ex.Message;
                }
            }

        public static bool OpcaoLiberada(string opcao , List<Acessos> usuarioAcessos)
        {
            foreach (var item  in usuarioAcessos)
            {
                if(item.NomeOpcao == opcao)
                {
                    if (item.Liberado == 'S')
                        return true;
                    break;

                }
            }
            return false;

        }

        public static bool LiberadoOpcaoConsultar(string opcaoMenu, List<Acessos> usuarioAcessos)
        {
            foreach (var item in usuarioAcessos)
            {
                if (item.NomeOpcao == opcaoMenu)
                {
                    if (item.LiberadoConsultar == 'S')
                        return true;

                }
            }
                return false;
            
        }

        public static bool LiberadoOpcaoAdicionar(string opcaoMenu, List<Acessos> usuarioAcessos)
        {
            foreach (var item in usuarioAcessos)
            {
                if (item.NomeOpcao == opcaoMenu)
                {
                    if (item.LiberadoAdicionar == 'S')
                    
                        return true;
                    
                }
                
            }
            return false;
        }

        public static bool LiberadoOpcaoAlterar(string opcaoMenu, List<Acessos> usuarioAcessos)
        {
            foreach (var item in usuarioAcessos)
            {
                if (item.NomeOpcao == opcaoMenu)
                {
                    if (item.LiberadoAlterar == 'S')
                    
                        return true;
                    
                }
                
            }
            return false;
        }

        public static bool LiberadoOpcaoExcluir(string opcaoMenu, List<Acessos> usuarioAcessos)
        {
            foreach (var item in usuarioAcessos)
            {
                if (item.NomeOpcao == opcaoMenu)
                {
                    if (item.LiberadoExcluir == 'S')
                    
                        return true;
                    
                }
                
            }
            return false;
        }

    }
    }

