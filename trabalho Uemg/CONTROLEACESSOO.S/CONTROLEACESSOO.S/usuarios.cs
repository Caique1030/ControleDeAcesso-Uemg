using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROLEACESSOO.S
{
    public class Usuarios
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string Nome { get; set; }
        public string NomeCurto { get; set; }
        public char Ativo { get; set; }

        public List<Acessos> MEnuAcesso { get; set; }

        public Usuarios() { 
        }

        public Usuarios(int id, string email, string nome, string nomeCurto, char ativo)
        {
            Id = id;
            Email = email;
            Nome = nome;
            NomeCurto = nomeCurto;
            Ativo = ativo;
        }

        public bool Excluir(int id)
        {
            var sql = "DELETE FROM usuarios WHERE id=@id";
            try
            {
                using (var cn = new SqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                return true;
            }

            
        }
        public string Salvar(Usuarios usuario)
        {
            var sql = "";
            if (usuario.Id == 0)
                sql = "INSERT INTO  usuarios (email , nome , nomeCurto , ativo) VALUES (@email,@nome,@nomeCurto,@ativo)";
            else
                sql = "UPDATE usuarios SET email=@email , nome=@nome, nomeCurto=@nomeCurto, ativo=@ativo  WHERE id=@id";

            try
            {
                using (var cn = new SqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql , cn))
                    {
                        if (usuario.Id > 0)
                        cmd.Parameters.AddWithValue("@id", usuario.Id);
                        cmd.Parameters.AddWithValue("@email", usuario.Email);
                        cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@nomeCurto", usuario.NomeCurto);
                        cmd.Parameters.AddWithValue("@ativo", usuario.Ativo);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch(Exception ex)
            {
                var result = "";
                if (ex.HResult == -2146232060)
                    result = usuario.Email + " Ja existe este email cadastrado , por favor cadastre um novo ";
                else
                    result = ex.Message;
                return result;
            }
        }


        public static DataTable BuscarTodos()
        {
            var sql = "SELECT id , email , nome , nomeCurto , ativo FROM usuarios";
            var dt = new DataTable();
            
            try
            {
                using (var cn = new SqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var da = new SqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public string LoginUsuario(Usuarios usuario , string senha)//metodo criado para autenticar o usuario 
        {
            var sql = "SELECT id , email , nome , nomeCurto ,senha , ativo FROM usuarios WHERE email=@email "; //filtrando pelo email 

            var result = "";

            try
            {
                using (var cn = new SqlConnection(Program.strConn))//abriu conexao do banco 
                {
                    cn.Open();
                    using(var cmd = new SqlCommand(sql, cn)) //abriu comando no banco 
                    {
                        cmd.Parameters.AddWithValue("@email", usuario.Email);//o parametro email foi substituido pelo usuario.email(propriedade do usuario )
                        
                        using (var dr = cmd.ExecuteReader()) //executando o comand 
                        {
                            if (dr.HasRows)//verifica se tem linhas no banco salvas 
                            {
                                if (dr.Read())// verifica se tem registros 
                                {
                                    if (senha == dr["senha"].ToString())//caso tiver , ele ira ler , acompanha senha que foi gravada no banco 
                                    {
                                        usuario.Id = (int)dr["id"];
                                        usuario.Email = dr["email"].ToString();
                                        usuario.Nome = dr["nome"].ToString();
                                        usuario.NomeCurto = dr["nomeCurto"].ToString();// se for igual , ira transferir os dados para o banco 
                                        usuario.Ativo = Convert.ToChar(dr["ativo"]);
                                        result = "ok";
                                    }
                                    else
                                        result = "Usuario ou senha invalidos !";
                                }
                                else
                                    result = "Usuario ou senha invalidos !";// se nao tiver ira exibir esta menssagem de erro 

                            }
                            else
                                result = "Usuario ou senha invalidos !";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }




        }   
    }
    





