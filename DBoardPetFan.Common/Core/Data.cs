using DBoardPetFan.Common.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DBoardPetFan.Common.Core
{
    public static class Data
    {
        public static DataSet EjecutaConsulta(Conexion sCon,Parametros Param)
        {
            DataSet DS = new DataSet();
            using (SqlConnection Conex = new SqlConnection(sCon.SConexion))
            {                
                try
                {

                    using (SqlCommand Cmd = new SqlCommand("SP_ReporteVentas", Conex))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add(new SqlParameter("@P_Opcion",Param.Opcion));
                        Cmd.Parameters.Add(new SqlParameter("@P_SOpcion", Param.SubOpcion));
                        Cmd.Parameters.Add(new SqlParameter("@P_Ano", Param.Anno));
                        Cmd.Parameters.Add(new SqlParameter("@P_Mes", Param.Mes));
                        Conex.Open();
                        using (SqlDataAdapter DA = new SqlDataAdapter(Cmd))
                        {
                            DA.Fill(DS);
                        }
                    }
                }
                catch(Exception Ex)
                {
                    Conex.Close();
                    throw Ex;
                }
            }
            return DS;
        }
    }
}
