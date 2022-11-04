using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//

namespace Phobos.DAL
{
    public class Conexao
    {
        //variaveis
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader dr;

        //metodos
        public void Conectar()
        {
            try
            {
                conn = new MySqlConnection("Data Source=localhost; Initial Catalog= phobosdb; Uid=root; Pwd=");
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
