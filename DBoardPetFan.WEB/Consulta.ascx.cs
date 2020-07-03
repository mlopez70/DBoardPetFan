using DBoardPetFan.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBoardPetFan.WEB
{
    public partial class Consulta : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnExe_Click(object sender, EventArgs e)
        {
            Parametros Param = new Parametros
            {
                Anno = int.Parse(DDLAno.SelectedValue.ToString()),
                Mes = int.Parse(DDLMes.SelectedValue.ToString()),
                Opcion = DDlOpcion.SelectedItem.Text
            };
            Session["Param"] = Param;
            if (DDlOpcion.SelectedItem.Text == "Segmento")
            {
                Response.Redirect("Segmentos.aspx");
            }
        }
    }
}