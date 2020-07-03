using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DBoardPetFan.Common.Core
{
    public static class Utileria
    {
        public static HtmlControl FindHtmlControlByIdInControl(Control control, string id)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl.ID != null && childControl.ID.Equals(id, StringComparison.OrdinalIgnoreCase) && childControl is HtmlControl)
                {
                    return (HtmlControl)childControl;
                }

                if (childControl.HasControls())
                {
                    HtmlControl result = FindHtmlControlByIdInControl(childControl, id);
                    if (result != null) return result;
                }
            }

            return null;
        }

        public static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }

        public static String NombreMes(int nMes)
        {
            String sReturn=string.Empty;
            switch (nMes)
            {
                case 1:sReturn = "Enero";break;
                case 2: sReturn = "Febero"; break;
                case 3: sReturn = "Marzo"; break;
                case 4: sReturn = "Abril"; break;
                case 5: sReturn = "Mayo"; break;
                case 6: sReturn = "Junio"; break;
                case 7: sReturn = "Julio"; break;
                case 8: sReturn = "Agosto"; break;
                case 9: sReturn = "Septiembre"; break;
                case 10: sReturn = "Octubre"; break;
                case 11: sReturn = "Noviembre"; break;
                case 12: sReturn = "Diciembre"; break;
            }
            return sReturn;
        }
    }
}
