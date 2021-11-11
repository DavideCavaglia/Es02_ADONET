using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADOSQLServer2017_ns;
using System.Data;
using System.Data.SqlClient;

namespace Es02_ADONET
{
    public class clsDB
    {
        ADOSQLServer2017 ado;
        public clsDB (string dbNome)
        {
            this.ado = new ADOSQLServer2017(dbNome);
        }

        public DataTable CaricaMarche()
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT IdMarca, Marca FROM Marche";
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

        public DataTable CaricaModelli(string IdMarca)
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT IdAuto, Modello FROM Modelli  WHERE idMarca= @IdMarca";
             
            cmd.Parameters.AddWithValue("@idMarca", IdMarca);
            dt = ado.EseguiQuery(cmd);
            return dt;
        }

       

        internal string leggiUrl(string idModello)
        {
            string url;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Immagine FROM Modelli  WHERE IdAuto= @idModello";

            cmd.Parameters.AddWithValue("@idModello", idModello);
            url = ado.EseguiScalar(cmd).ToString();
            return url;
        }
    }
}