using Examen_Unidad2.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Unidad2.Modelos.DAO
{
    public class EstadosDAO: Conexion
    {
        SqlCommand comando = new SqlCommand();
        public bool InsertarNuevoEstado(Estados estados)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO ESTADOS ");
                sql.Append(" VALUES (@EstadoTicket); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@EstadoTicket", SqlDbType.NVarChar, 100).Value = estados.EstadoTicket;
                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable GetEstados()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM ESTADOS ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
            }
            return dt;
        }
        public bool ActualizarEstados(Estados estados)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE ESTADOS ");
                sql.Append(" SET ESTADOTICKET = @EstadoTicket ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = estados.Id;
                comando.Parameters.Add("@EstadoTicket", SqlDbType.NVarChar, 80).Value = estados.EstadoTicket;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                return modifico;
            }
            return modifico;
        }
        public bool EliminarEstados(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM ESTADOS ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
                
                elimino = true;
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                return elimino;
            }
            return elimino;
        }
    }
}
