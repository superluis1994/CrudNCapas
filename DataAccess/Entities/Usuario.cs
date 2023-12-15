﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Connection;
using common.Attributes;


namespace DataAccess.Entities
{
    public class Usuario
    {
       /** VARIABLES */  
        Connection_Database c = new Connection_Database();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable td = new DataTable();

        public DataTable Mostrar()
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "select id,nombre as Nombre, apellido As Apellido , correo_electronico as Email, fecha_nacimiento as Fecha_Nacimiento from usuarios";
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                td.Load(dr);

            }catch(Exception ex) 
            { 
                string msj = ex.ToString();    
            }
            finally 
            {
                cmd.Connection = c.CloseConnection();   
            }
                return td;
        }
        public void Insertar(AttributesUsuario obj)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                //cmd.CommandText = "SP_Insertar";
                cmd.CommandText = "INSERT INTO usuarios VALUES (@nombre,@apellido,@correo_electronico,@fecha_nacimiento)";
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre",obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido",obj.Apellido);
                cmd.Parameters.AddWithValue("@correo_electronico",obj.Correo_electronico);
                cmd.Parameters.AddWithValue("@fecha_nacimiento",obj.Fecha_nacimiento);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch(Exception ex) 
            {
                string msj =ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }
        public void Modificar(AttributesUsuario obj)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Modificar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@correo_electronico", obj.Correo_electronico);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", obj.Fecha_nacimiento);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }
        public void Eliminar(AttributesUsuario obj)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Eliminar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }
        public DataTable Buscar(string Buscar)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_BuquedaMultiple";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BUSCAR", Buscar);
                dr = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                td.Load(dr);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
            return td;
        }
    }
}
