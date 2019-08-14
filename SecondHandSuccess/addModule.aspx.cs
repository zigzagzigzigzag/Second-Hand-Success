using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addModule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var dataItem = e.Item as ListViewDataItem;
        if (dataItem != null)
        {
            var innerPanel = dataItem.FindControl("test1") as Panel;
            if (innerPanel != null)
            {
                var modCode = (string)ListView1.DataKeys[dataItem.DisplayIndex]["moduleCode"];
                /*System.Drawing.Color colour = #5C6B73;*/
                innerPanel.BackColor =System.Drawing.ColorTranslator.FromHtml("#5C6B73");
            }
        }
    }
}