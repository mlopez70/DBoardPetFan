using DBoardPetFan.Common.Core;
using DBoardPetFan.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBoardPetFan.WEB
{
    public partial class Segmentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Parametros Param = (Parametros)Session["Param"];

            Label Lbl = (Label)Utileria.FindControlRecursive(this, "LblTitulo");
            Lbl.Text = "Reporte de ventas por Segmento para " + Utileria.NombreMes(Param.Mes) + " del " + Param.Anno.ToString();

            Conexion Conex = new Conexion
            {
                SConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };


            Param.SubOpcion = "Mes";
            DataSet DS = Data.EjecutaConsulta(Conex, Param);
            SegmentoMes.Columnas = DefineColumnas_Mes();
            SegmentoMes.Titulo = "Ventas por Segmento por Mes";
            SegmentoMes.DatosDetalle = DS;
            SegmentoMes.TDetalle = 1;
            SegmentoMes.TGrafica = 0;
            SegmentoMes.sDiv = "SegMes";
            SegmentoMes.THeader = 2;
            SegmentoMes.TitHeader = Utileria.NombreMes(Param.Mes) + Param.Anno.ToString();
            SegmentoMes.Carga_Datos();


            Param.SubOpcion = "Acumulado";
            DS = Data.EjecutaConsulta(Conex, Param);
            SegmentoAcum.Columnas = DefineColumnas_Mes();
            SegmentoAcum.Titulo = "Ventas acumuladas por Segmento";
            SegmentoAcum.DatosDetalle = DS;
            SegmentoAcum.TDetalle = 1;
            SegmentoAcum.TGrafica = 0;
            SegmentoAcum.THeader = 2;
            SegmentoAcum.sDiv = "SegAcum";
            SegmentoAcum.TitHeader = " Acumulado " + Param.Anno.ToString();
            SegmentoAcum.Carga_Datos();
        }

        private ArrayList DefineColumnas_Mes()
        {
            ArrayList ListaCol = new ArrayList
            {
                new DefColumna
                {
                    Dato = "Cantidad",
                    Formato = "{0:N0}",
                    TituloCabecera = "Cant.",
                    Alinea=DefColumna.Alineacion.Derecha,
                    Acumula=true,
                    FormatoTotal="N0"
                },
                new DefColumna
                {
                    Dato = "Producto",
                    Formato = "",
                    TituloCabecera = "Producto",
                    Alinea=DefColumna.Alineacion.Izquierda,
                    Acumula=false,
                    FormatoTotal="",
                },
                new DefColumna
                {
                    Dato = "Total",
                    Formato = "{0:C2}",
                    TituloCabecera = "Importe",
                    Alinea=DefColumna.Alineacion.Derecha,
                    Acumula=true,
                    FormatoTotal="C2",
                },
                new DefColumna
                {
                    Dato = "%Venta",
                    Formato = "{0:N2}",
                    TituloCabecera = "%",
                    Alinea=DefColumna.Alineacion.Derecha,
                    Acumula=true,
                    FormatoTotal="N2",
                }
            };
            return ListaCol;
        }
    }
}