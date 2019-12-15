<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goods_list.aspx.cs" Inherits="OA_goods_list"
    ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="control/loading.ascx" TagName="loading" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <script src="js/JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="c_title">
                    <div class="c_t_name">
                        ● 商品</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>高级搜索： </li>
                            <li>开始时间
                                <asp:TextBox ID="txt_date1" runat="server" Width="65"></asp:TextBox>
                            </li>
                            <li>结束时间
                                <asp:TextBox ID="txt_date2" runat="server" Width="65"></asp:TextBox>
                            </li>
                            <li>上架状态
                                <asp:DropDownList ID="ddl_state_up" runat="server" width="80" >
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未上架" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已上架" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>图片状态
                                <asp:DropDownList ID="ddl_state_img" runat="server" width="80" >
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未上传" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已上传" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>标题优化状态
                                <asp:DropDownList ID="ddl_state_title" runat="server" width="80" >
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未优化" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已优化" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            
                            <li>淘宝主图
                                <asp:DropDownList ID="ddl_hasImg_tb" runat="server" width="80" >
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="有图片" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="没有图片" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>蘑菇街主图
                                <asp:DropDownList ID="ddl_hasImg_mgj" runat="server" width="80" >
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="有图片" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="没有图片" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                             <li>重点商品
                                <asp:DropDownList ID="ddl_state_important" runat="server" width="80" >
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="否" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="是" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>关键词
                                <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button ID="btn_save" runat="server" Text="搜索" OnClick="btn_save_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加商品" OnClientClick="window.location.href = 'goods_add.aspx';return false;" />
                            </li>
                            <li>
                                <asp:Button ID="btn_del" runat="server" Text="批量删除" 
                                    OnClientClick="return to_batch_do();" onclick="btn_del_Click" />
                            </li>
                        </ul>
                        <script>
                            function to_search() {
                                var url = 'goods_list.aspx?date1=' + $("#txt_date1").val() + '&date2=' + $("#txt_date2").val() + '&state_img=' + $("#ddl_state_img").val() + '&state_up=' + $("#ddl_state_up").val() + '&state_title=' + $("#ddl_state_title").val() + '&hasImg_tb=' + $("#ddl_hasImg_tb").val() + '&hasImg_mgj=' + $("#ddl_hasImg_mgj").val() + '&key=' + $("#txt_key").val();
                                window.location.href = url;
                                return false;
                            }
                        </script>
                    </div>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="gid,gimg,gimg2,gstate2,gstate3,gstate1,gurl,gurl2,gprice1,gprice2,gurl_yuan,g_standby1"
                        OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "gid")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品简称" SortExpression="gname">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_name" runat="server" Text='<%# Bind("gname") %>' ToolTip='<%# Eval("gtitle") %>'> </asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("gname") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="淘宝价格" SortExpression="gprice1">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_price_tb" runat="server" Text='暂无' Target="_blank"> </asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_price_tb" runat="server" Text='<%# Bind("gprice1") %>' Width="70"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="蘑菇街价格" SortExpression="gprice2">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_price_mgj" runat="server" Text='暂无' Target="_blank"> </asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_price_mgj" runat="server" Text='<%# Bind("gprice2") %>' Width="70"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="淘宝主图" SortExpression="gimg">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_state_img_tb" runat="server" Text='暂无' ToolTip='<%# Eval("gimg") %>'
                                        Target="_blank"> </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="蘑菇街主图" SortExpression="gimg2">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_state_img_mgj" runat="server" Text='暂无' ToolTip='<%# Eval("gimg2") %>'
                                        Target="_blank"> </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="网供商品URL" SortExpression="gurl_yuan">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_url_yuan" runat="server" Text='暂无' ToolTip='<%# Eval("gurl_yuan") %>'
                                        Target="_blank"> </asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_url_yuan" runat="server" Text='<%# Bind("gurl_yuan") %>' Width="70"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="上架状态" SortExpression="gstate2">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state_up" runat="server" CommandName="state_up"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="图片状态" SortExpression="gstate1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state_img" runat="server" CommandName="state_img"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="优化状态" SortExpression="gstate3">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state_yh" runat="server" CommandName="state_yh"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="重点商品" SortExpression="g_standby1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state_important" runat="server" CommandName="state_important"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注信息" SortExpression="gremark1">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("gremark1")%>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Eval("gremark1") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="添加时间" SortExpression="gdate">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("gdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False" ItemStyle-Font-Bold="true">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbtn_clear" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="编辑"></asp:LinkButton>
                                    <%--<asp:HyperLink ID="hl_history" runat="server" Text="历史" NavigateUrl='<%# "fanxian_list.aspx?key="+ Eval("fx_zhifubao") %>'></asp:HyperLink>--%>
                                    <asp:HyperLink ID="hl_info" runat="server" NavigateUrl='<%# "goods_add.aspx?id="+Eval("gid") %>'
                                        Text="详细"> </asp:HyperLink>
                                    <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="page">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                            PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                            SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
                <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
