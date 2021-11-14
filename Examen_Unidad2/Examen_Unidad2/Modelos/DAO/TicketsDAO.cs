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
    public class TicketsDAO: Conexion
    {
        SqlCommand comando = new SqlCommand();
        public bool InsertarNuevoTicket(Tickets tickets)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TICKETS ");
                sql.Append(" VALUES (@NombreCliente,@FechaInicio,@FechaFinalizacion,@TipoSoporte,@EstadoTicket); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, 80).Value = tickets.NombreCliente;
                comando.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = tickets.FechaInicio;
                comando.Parameters.Add("@FechaFinalizacion", SqlDbType.DateTime).Value = tickets.FechaFinalizacion;
                comando.Parameters.Add("@TipoSoporte", SqlDbType.NVarChar, 100).Value = tickets.TipoSoporte;
                comando.Parameters.Add("@EstadoTicket", SqlDbType.NVarChar, 100).Value = tickets.EstadoTicket;
                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable GetTipos()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TIPOS ");

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
        public DataTable GetTickets()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TICKETS ");
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
        public bool ActualizarTickets(Tickets tickets)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE TICKETS ");
                sql.Append(" SET NOMBRECLIENTE = @NombreCliente, FECHAINICIO = @FechaInicio, FECHAFINALIZACION = @FechaFinalizacion, TIPOSOPORTE = @TipoSoporte,ESTADOTICKET = @EstadoTicket ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = tickets.Id;
                comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, 80).Value = tickets.TipoSoporte;
                comando.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = tickets.FechaInicio;
                comando.Parameters.Add("@FechaFinalizacion", SqlDbType.DateTime).Value = tickets.FechaFinalizacion;
                comando.Parameters.Add("@TipoSoporte", SqlDbType.NVarChar, 100).Value = tickets.TipoSoporte;
                comando.Parameters.Add("@EstadoTicket", SqlDbType.NVarChar, 100).Value = tickets.EstadoTicket;
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
        public bool EliminarTickets(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TICKETS ");
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
