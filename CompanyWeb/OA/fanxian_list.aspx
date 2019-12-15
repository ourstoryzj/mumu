<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fanxian_list.aspx.cs" Inherits="OA_fanxian_list"
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
                        ● 返现管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>搜索：</li>
                            <li>录入开始时间
                                <asp:TextBox ID="txt_date1" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>录入结束时间
                                <asp:TextBox ID="txt_date2" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>返现开始时间
                                <asp:TextBox ID="txt_date3" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>返现结束时间
                                <asp:TextBox ID="txt_date4" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>店铺
                                <asp:DropDownList ID="ddl_dianpu" runat="server">
                                </asp:DropDownList>
                            </li>
                            <li>状态
                                <asp:DropDownList ID="ddl_state" runat="server">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未返现" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已返现" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="有问题" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>关键词
                                <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button ID="btn_save" runat="server" Text="搜索" OnClick="btn_save_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加返现" OnClientClick="window.location.href = 'fanxian_add.aspx';return false;" />
                            </li>
                            <li>
                                <asp:Button ID="btn_del" runat="server" Text="批量删除" OnClientClick="return to_batch_do();"
                                    OnClick="btn_del_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
                <script>
                    function to_zhifubao(acc, price) {
                        var sfForm = document.createElement("form");
                        document.body.appendChild(sfForm);
                        createInput(sfForm, "hidden", "optEmail", "optEmail", acc);
                        createInput(sfForm, "hidden", "payAmount", "payAmount", price);
                        createInput(sfForm, "hidden", "title", "title", "好评返现");

                        sfForm.method = "post";
                        sfForm.action = "https://shenghuo.alipay.com/send/payment/fill.htm";
                        sfForm.name = "dinggou";
                        sfForm.target = "_blank";
                        //sfForm.accept-charset = "gbk";
                        sfForm.submit();
                        retrun;
                    }
                </script>
                <script type="text/javascript">
                    function createInput(sfForm, type, id, name, value) {
                        var tmpInput = document.createElement("input");
                        tmpInput.type = type;
                        tmpInput.id = id;
                        tmpInput.name = name;
                        tmpInput.value = value;
                        sfForm.appendChild(tmpInput);
                    }
                </script>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="fx_id,fx_state,dpid,fx_zhifubao,fx_num"
                        OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "fx_id")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" SortExpression="fx_id">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("fx_id") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dianpu" runat="server" Text='<%# Bind("dpid") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="返现状态" SortExpression="fx_state">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="支付宝账号（点击返现）" SortExpression="fx_zhifubao" HeaderStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_zhifubao" runat="server" Text='<%# Bind("fx_zhifubao") %>'
                                        CommandName="fanxian"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_zhifubao" runat="server" Text='<%# Bind("fx_zhifubao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="买家账号（点击联系）" SortExpression="fx_account" HeaderStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lbl_account" runat="server" Text='<%# Bind("fx_account") %>'> </asp:Label>--%>
                                    <asp:HyperLink ID="lb_account" runat="server" Target="_blank" Text='<%# Bind("fx_account") %>'
                                        NavigateUrl="#"></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_account" runat="server" Text='<%# Bind("fx_account") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="返现金额" SortExpression="fx_num">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_num" runat="server" Text='<%# Bind("fx_num") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_num" runat="server" Text='<%# Bind("fx_num") %>' Width="80px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="添加时间" SortExpression="fx_date">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("fx_date").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="130px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注信息" SortExpression="fx_remark">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("fx_remark")%>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Eval("fx_remark") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="返现时间" SortExpression="fx_date2">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date2" runat="server" Text='<%# Convert.ToDateTime(Eval("fx_date2").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="130px" />
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
                                    <asp:HyperLink ID="hl_history" runat="server" Text="历史" NavigateUrl='<%# "fanxian_list.aspx?key="+ Eval("fx_zhifubao") %>'></asp:HyperLink>
                                    <asp:HyperLink ID="hl_info" runat="server" NavigateUrl='<%# "fanxian_add.aspx?id="+Eval("fx_id") %>'
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
                        <asp:Label ID="lbl_count" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lbl_zong" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Button ID="btn_zong" runat="server" Text="查看" OnClick="btn_zong_Click" />
                    </div>
                </div>
            </div>
            <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        function to_edit(id) {
            window.parent.location.href = "fanxian_add.aspx?id=" + id;
        }
    </script>
    </form>
</body>
</html>
