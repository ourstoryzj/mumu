using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Hosting;
using System.Security.Permissions;
using System.Text;

/// <summary>
///ExtTree 的摘要说明
/// </summary>
public class ExtTree
{
    private string _XMLpath;
    private static ExtTree extTree = null;
    public static ExtTree Current
    {
        get 
        {
            if (extTree == null)
                extTree = new ExtTree();

            return extTree;
        }
    }
	private ExtTree()
	{
        InitXMLpath();
	}

    private void InitXMLpath()
    {
        string xmlpath = "~/app_data/tree.xml";
        _XMLpath = HostingEnvironment.MapPath(xmlpath);
        FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Write, _XMLpath);
        permission.Demand();
    }

    private DataTable GetAllNodes()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(_XMLpath);
        return ds.Tables[0];
    }

    private DataTable GetAllNodes(string parentid)
    {
        DataTable dt = GetAllNodes();
        DataTable _dt = dt.Clone();
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["parentid"].ToString() == parentid.ToString())
                _dt.Rows.Add(dr.ItemArray);
        }

        return _dt;
    }



    public string CreateExtTreeJSON()
    {
        StringBuilder sb = new StringBuilder();
        CreateExtTreeNode(sb);
        string s= sb.ToString();
        return s.Replace("}{","},{");
    }
    /*
     * Ext Tree JSON 数据部分属性说明：
     * text: 要显示的节点文件
     * id:这个就不用解释了
     * href:链接地址
     * hrefTarget：链接目标框架名称
     * children:子节点 格式：[{节点1},{节点2}...]
     * leaf:当前节点是否为叶子节点。如果为false 则此节点有子节点。
     *                              否则为true,此节点在无子节点
     * */
    private void CreateExtTreeNode(StringBuilder sb)
    {
        DataTable dt = GetAllNodes("0");
        if (dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + dr["title"].ToString() + "',");
                sb.Append("id:'node" + dr["id"].ToString() + "'");
                AddChildrenNode(GetAllNodes(dr["id"].ToString()),sb);
                sb.Append("}");
            }
        }

        sb.Append("]");
    }

    private void AddChildrenNode(DataTable dt,StringBuilder sb)
    {
        if (dt.Rows.Count > 0)
        {
            sb.Append(",leaf:false,children:[");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + dr["title"].ToString() + "',");
                sb.Append("id:'node" + dr["id"].ToString() + "',");
                sb.Append("href:'" + dr["url"].ToString() + "',");
                sb.Append("hrefTarget:'main'");
                AddChildrenNode(GetAllNodes(dr["id"].ToString()), sb);
                sb.Append("}");
            }

            sb.Append("]");
        }
        else
            sb.Append(",leaf:true");
    }
}
