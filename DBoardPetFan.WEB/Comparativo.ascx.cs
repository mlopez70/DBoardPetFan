using DBoardPetFan.Common.Core;
using DBoardPetFan.Common.Models;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DBoardPetFan.WEB
{
    public partial class Comparativo : System.Web.UI.UserControl
    {
        public ArrayList Columnas { get; set; }
        public DataSet DatosDetalle { get; set; }
        public int TDetalle { get; set; }
        public int TGrafica { get; set; }
        public String Titulo { get; set; }
        public String sDiv { get; set; }
        public int THeader { get; set; }
        public String TitHeader { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (DatosDetalle != null)
            {
                HtmlGenericControl CtrlGrafica = (HtmlGenericControl)Utileria.FindHtmlControlByIdInControl(this, "GraficaDatos");
                HtmlGenericControl CtrlInfo = (HtmlGenericControl)Utileria.FindHtmlControlByIdInControl(this, "DGridDatos");
                HtmlGenericControl CtrlHeader = (HtmlGenericControl)Utileria.FindHtmlControlByIdInControl(this, "DivHeader");
                Label Lbl = new Label
                {
                    Text = Titulo,
                    CssClass = "btn btn-primary",
                    Width = Unit.Percentage(100)
                };

                CtrlHeader.Controls.Add(Cabecera());
                HtmlGenericControl Ctrl1 = new HtmlGenericControl("div");
                Ctrl1.Attributes.Add("Id", sDiv);
                CtrlGrafica.Controls.Add(Ctrl1);
                CtrlGrafica.Controls.Add(Lbl);
                
            }
        }

        private Table Cabecera()
        {
            Table Tbl = new Table
            {
                Width = Unit.Percentage(100),
                CssClass = "btn-success",
            };
            TableRow Renglon = new TableRow();
            TableCell Celda = new TableCell();
            Celda.ColumnSpan = DatosDetalle.Tables[THeader].Columns.Count;
            Celda.Font.Size = new FontUnit(FontSize.Medium);
            Celda.Font.Bold = true;
            Celda.Text = TitHeader;
            Celda.ForeColor = Color.Black;
            Renglon.Cells.Add(Celda);
            Tbl.Rows.Add(Renglon);
            foreach (DataRow Registro in DatosDetalle.Tables[THeader].Rows)
            {
                 Renglon = new TableRow();
                foreach(DataColumn Columna in DatosDetalle.Tables[THeader].Columns)
                {
                    Celda = new TableCell
                    {
                        Text = Columna.ColumnName,                        
                    };
                    Celda.Font.Size = new FontUnit(FontSize.Medium);
                    Celda.Font.Bold = true;
                    Renglon.Cells.Add(Celda);
                }
                Tbl.Rows.Add(Renglon);
                Renglon = new TableRow();
                foreach (DataColumn Columna in DatosDetalle.Tables[THeader].Columns)
                {
                    Celda = new TableCell
                    {
                        Text = Registro[Columna].ToString()
                    };
                    Renglon.Cells.Add(Celda);
                }
                Tbl.Rows.Add(Renglon);
            }
            return Tbl;
        }

        public void Carga_Datos()
        {
            DefinirColumnasNotebook();
            GrdDetalle.DataSource = DatosDetalle.Tables[TDetalle];
            GrdDetalle.DataBind();
            
        }

        protected String ObtenerInfo()
        {
            String sReturn = String.Empty;
            if (DatosDetalle != null)
            {
                DataTable DT = DatosDetalle.Tables[TGrafica];
                sReturn = "[['Categoria','%'],";
                foreach (DataRow Registro in DT.Rows)
                {
                    sReturn += "[";
                    sReturn += "'" + Registro[0] + "'," + Registro[1];
                    sReturn += "],";
                }
                sReturn += "]";
            }
            return sReturn;
        }

        private void DefinirColumnasNotebook()
        {
            if (GrdDetalle.Columns.Count > 0)
            {
                GrdDetalle.Columns.Clear();
            }
            foreach (DefColumna Columna in Columnas)
            {
                if (Columna.Acumula)
                {
                    foreach (DataRow Registro in DatosDetalle.Tables[TDetalle].Rows)
                    {
                        foreach (DataColumn Colum in Registro.Table.Columns)
                        {
                            if (Colum.ColumnName == Columna.Dato)
                            {
                                Columna.Acumulado += Decimal.Parse(Registro[Colum].ToString());
                            }
                        }
                    }
                }
                BoundField BTemp = new BoundField
                {
                    HeaderText = Columna.TituloCabecera,
                    DataField = Columna.Dato,
                    DataFormatString = Columna.Formato,
                };
                GrdDetalle.Columns.Add(BTemp);
            }
        }

        protected void GrdDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[0].Text = ((DefColumna)Columnas[0]).Acumulado.ToString(((DefColumna)Columnas[0]).FormatoTotal);
                e.Row.Cells[2].Text = ((DefColumna)Columnas[2]).Acumulado.ToString(((DefColumna)Columnas[2]).FormatoTotal);
                e.Row.Cells[3].Text = ((DefColumna)Columnas[3]).Acumulado.ToString(((DefColumna)Columnas[3]).FormatoTotal);
            }
        }
    }
}