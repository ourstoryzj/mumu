using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class OA_control_loading : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public string AUpdatePanelID1
    {
        get { return UpdateProgress1.AssociatedUpdatePanelID; }
        set { UpdateProgress1.AssociatedUpdatePanelID = value; }
    }

    
}