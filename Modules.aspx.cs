using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var dataItem = e.Item as ListViewDataItem;
        if (dataItem != null)
        {
            var innerPanel = dataItem.FindControl("panelModule") as Panel;
            if (innerPanel != null)
            {
                var modCode = (string)tableModule.DataKeys[dataItem.DisplayIndex]["moduleCode"];
                innerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#5C6B73");
            }
        }
    }
}