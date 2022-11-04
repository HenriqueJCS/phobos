using MySql.Data.MySqlClient;//
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DAL
{
	public class UsuarioDAL:Conexao
	{
		//CRUD

		//CREATE
		public void Cadastrar(UsuarioDTO objCad)
		{
			try
			{
				Conectar();
				cmd = new MySqlCommand("INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,DataNacimentoUsuario,UsuarioTP) VALUES " +
                    "(@NomeUsuario,@EmailUsuario,@SenhaUsuario,@DataNacimentoUsuario,@UsuarioTP)", conn);
				cmd.Parameters.AddWithValue("@NomeUsuario", objCad.NomeUsuario);
				cmd.Parameters.AddWithValue("@EmailUsuario", objCad.EmailUsuario);
				cmd.Parameters.AddWithValue("@SenhaUsuario", objCad.SenhaUsuario);
				cmd.Parameters.AddWithValue("@DataNacimentoUsuario", objCad.DataNacimentoUsuario);
				cmd.Parameters.AddWithValue("@UsuarioTP", objCad.UsuarioTP);
				cmd.ExecuteNonQuery();

            }
			catch (Exception ex)
			{

				throw new Exception("erro ao cadastrar !!" + ex.Message);
			}
			finally
			{
				Desconectar();
			}
		}
	
	
	//READ
	public List<UsuarioListDTO> Listar()
		{
			try
			{
				Conectar();
				cmd = new MySqlCommand("SELECT NomeUsuario,EmailUsuario,Descricao FROM usuario INNER JOIN tipousuario ON usuario.UsuarioTP = tipousuario.Id; ", conn);
				dr = cmd.ExecuteReader();
				//ponteiro - lista vazia
				List<UsuarioListDTO> Lista = new List<UsuarioListDTO>();
				while (dr.Read())
				{
					UsuarioListDTO obj = new UsuarioListDTO();
					obj.NomeUsuario = dr["Nome"].ToString();
                    obj.EmailUsuario = dr["Email"].ToString();
                    obj.Descricao = dr["Descrição"].ToString();

					//adicionar a lista
					Lista.Add(obj);
                }
				return Lista;
			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao listar registros !!"+ex.Message);
			}
			finally
			{
				Desconectar();
			}
		}
	
	//Update
	public void Editar(UsuarioDTO objEdit)
	{
			try
			{
				Conectar();
				cmd = new MySqlCommand("UPDATE usuario SET NomeUsuario = @Nome,EmailUsuario = @Email, SenhaUsuario = @Senha,DataNacimentoUsuario = @DataNacimentoUsuario , UsuarioTP = @UsuarioTP WHERE IdUsuario = @Id", conn);
				cmd.Parameters.AddWithValue("@Nome", objEdit.NomeUsuario);
				cmd.Parameters.AddWithValue("@Email", objEdit.EmailUsuario);
                cmd.Parameters.AddWithValue("@DataNacimentoUsuario", objEdit.DataNacimentoUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTP", objEdit.UsuarioTP);
				cmd.Parameters.AddWithValue("@Id", objEdit.IdUsuario);
				cmd.ExecuteNonQuery();

            }
			catch (Exception ex)
			{

				throw new Exception("Erro ao editar usuario !!" + ex.Message);
			}
			finally
			{
				Desconectar();
			}

	}
	
	//Delete
	public void Excluir(int objDel)


		{
			try
			{
				Conectar();
				cmd = new MySqlCommand("DELETE FROM Usuario WHERE IdUsuario = @Id", conn);
				cmd.Parameters.AddWithValue("@Id", objDel);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao eliminar registro !!"+ex.Message);
			}
			finally 
			{ Desconectar();
			}
		}
	
	//Autenticar
	public UsuarioAutenticaDTO Autenticar(string objNome, string objSenha)
		{
			try
			{
				Conectar();
				cmd = new MySqlCommand("SELECT `NomeUsuario`,`SenhaUsuario`,`UsuarioTP` FROM `usuario` WHERE NomeUsuario = @NomeUsuario AND SenhaUsuario = @SENHA", conn);
				cmd.Parameters.AddWithValue("@NomeUsuario", objNome);
                cmd.Parameters.AddWithValue("@SENHA", objSenha);
                dr = cmd.ExecuteReader();
				UsuarioAutenticaDTO obj = null;
				if (dr.Read())
				{
					UsuarioAutenticaDTO objAut = new UsuarioAutenticaDTO();
					obj = new UsuarioAutenticaDTO();
					objAut.NomeUsuario = dr["Nome"].ToString();
					objAut.SenhaUsuario = dr["Senha"].ToString();
					objAut.UsuarioTP = Convert.ToInt32(dr["UsuarioTP"]);
				}
				return obj;
			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao Autentificar !!"+ex.Message);
			}
			finally
			{
				Desconectar();
			}
		}
	
	//buscar Id

	public UsuarioDTO BuscaPorId(int Id)
		{
			try
			{
				Conectar();
				cmd = new MySqlCommand("SELECT * FROM `usuario` WHERE Idusuario = @IdUsuario", conn);
				cmd.Parameters.AddWithValue("@IdUsuario", Id);
				dr = cmd.ExecuteReader();
				UsuarioDTO obj = null;

				if (dr.Read())
				{
					obj = new UsuarioDTO();
					obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    obj.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    obj.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    obj.DataNacimentoUsuario = Convert.ToDateTime(dr["DataNacimentoUsuario"]);
                    obj.UsuarioTP = Convert.ToInt32(dr["UsuarioTP"]);
                }
				return obj;
			
			}
			catch (Exception ex)
			{

				throw new Exception("Busca Inadequada !!"+ex.Message);
			}
			finally
			{
				Desconectar();
			}
		}
	
	}
	
}
