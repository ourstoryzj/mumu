<%@ Page Language="C#" AutoEventWireup="true" CodeFile="huashu_list.aspx.cs" Inherits="OA_huashu_list"
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
        <div class="content">
            <div class="c_title">
                <div class="c_t_name">
                    ● 话术管理
                </div>
                <div class="c_t_desc">
                    <ul>
                        <li>（关键词可搜索话术,标题）搜索： </li>
                        <li>开始时间
                        <asp:TextBox ID="txt_date1" runat="server" Width="80"></asp:TextBox>
                        </li>
                        <li>结束时间
                        <asp:TextBox ID="txt_date2" runat="server" Width="80"></asp:TextBox>
                        </li>
                        <%--<li style="display: none;">数量
                        <asp:TextBox ID="txt_num" runat="server" Width="80"></asp:TextBox>
                    </li>--%>
                        <li>状态
                        <asp:DropDownList ID="ddl_state" runat="server">
                            <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                            <asp:ListItem Text="正常" Value="1"></asp:ListItem>
                            <asp:ListItem Text="失效" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        </li>
                        <li>类型
                        <asp:DropDownList ID="ddl_type" runat="server">
                        </asp:DropDownList>
                        </li>
                        <li>关键词
                        <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                        </li>
                        <li>
                            <asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btn_toadd" runat="server" Text="添加话术" OnClientClick="window.location.href = 'huashu_add.aspx';return false;" />
                        </li>
                        <li>
                            <asp:Button ID="btn_del" runat="server" Text="批量删除" OnClientClick="return to_batch_do();"
                                ForeColor="Red" OnClick="btn_del_Click" />
                        </li>
                        <%--<li>导出条数
                        <asp:TextBox ID="txt_num2" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="btn_out" runat="server" Text="导出数据" OnClick="btn_out_Click" />
                    </li>--%>
                    </ul>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating" DataKeyNames="hid,hstate,hfid,hsendemail" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                    <ItemTemplate>
                                        <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "hid")%>'
                                            onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类型">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_type" runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="话术标题">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_title" runat="server" Text='<%# Bind("htitle") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_title" runat="server" Text='<%# Bind("htitle") %>' Width="180px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="话术内容">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_context" runat="server" Text='<%# Eval("hcontext")!=null?( Eval("hcontext").ToString().Length>15?Eval("hcontext").ToString().Substring(0,14):Eval("hcontext").ToString()):"" %>'
                                            ToolTip='<%# Eval("hcontext") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_context" runat="server" Text='<%# Bind("hcontext") %>' Width="180px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="排序">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sort" runat="server" Text='<%# Bind("hsort") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_sort" runat="server" Text='<%# Bind("hsort") %>' Width="100px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="110px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="点击量">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_count" runat="server" Text='<%# Bind("hcount") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="110px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="邮件通知">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_email" runat="server" CommandName="email"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="操作时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("hdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" />
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
                                        <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "huashu_add.aspx?id="+ Eval("hid") %>'></asp:HyperLink>
                                        <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="page">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                                PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                                SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                            <asp:Label ID="lbl_count" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
