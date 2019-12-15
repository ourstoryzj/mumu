<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="OA_sh_problem_list"
    ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="control/loading.ascx" TagName="loading" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="content" style="background-color: #F5F6EB">
                    <div class="c_title">
                        <div class="c_t_name" style="">
                            ● 任务列表
                        </div>
                        <div class="c_t_desc">
                            <ul>
                                <li>
                                    <asp:Button ID="btn_totask" runat="server" Text="添加任务" OnClientClick="window.location.href = 'basic_task_add.aspx';return false;" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView4_RowCancelingEdit"
                            OnRowCommand="GridView4_RowCommand" OnRowDataBound="GridView4_RowDataBound" OnRowEditing="GridView4_RowEditing"
                            OnRowUpdating="GridView4_RowUpdating" DataKeyNames="btid,btstate" OnRowDeleting="GridView4_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                    <ItemTemplate>
                                        <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "btid")%>'
                                            onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                    </ItemTemplate>
                                    <ItemStyle Width="25" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("btid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务名称">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("btname") %>'> </asp:Label>
                                        <%--<asp:HyperLink ID="hl_name" runat="server" Target="_blank" Text='<%# Bind("btname") %>'
                                        NavigateUrl='<%# "basic_order_record_add.aspx?bgid="+Eval("bgid") %>'></asp:HyperLink>--%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("btname") %>' Width="150px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务内容">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("btcontent")!=null?(Eval("btcontent").ToString().Length>50?Eval("btcontent").ToString().Substring(0,49):Eval("btcontent").ToString()):"" %>'
                                            ToolTip='<%# Eval("btcontent") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_remark" runat="server" Text='<%# Bind("btcontent") %>' Width="180px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="执行时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("btdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="重复操作">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_chongfu" runat="server" Text='<%# Eval("btspare1")!=null?(Eval("btspare1").ToString()=="1"?"每日":(Eval("btspare1").ToString()=="2"?"每月":(Eval("btspare1").ToString()=="3"?"每年":"无"))):"无" %>'
                                            ToolTip='<%# Eval("btspare1") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date2" runat="server" Text='<%# Convert.ToDateTime(Eval("btdate2").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
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
                                        <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "basic_task_add.aspx?id="+ Eval("btid") %>'></asp:HyperLink>
                                        <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="140px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="page">
                            <webdiyer:AspNetPager ID="AspNetPager3" runat="server" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" OnPageChanged="AspNetPager3_PageChanged" PageIndexBoxType="DropDownList"
                                PageSize="5" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                                SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
                <!-- 返现 -->
                <div class="content" style="background-color: #EFF0DC">
                    <div class="c_title">
                        <div class="c_t_name" style="">
                            ● 待处理售后
                        </div>
                        <div class="c_t_desc">
                            <ul>
                                <li>
                                    <asp:Button ID="Button1" runat="server" Text="添加售后" OnClientClick="window.location.href = 'sh_problem_add.aspx';return false;" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating" DataKeyNames="shid,shstate,dpid" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="序号" SortExpression="shid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("shid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="店铺">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_dianpu" runat="server" Text='<%# Bind("dpid") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单编号" SortExpression="shordercode">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_ordercode" runat="server" Text='<%# Bind("shordercode") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_ordercode" runat="server" Text='<%# Bind("shordercode") %>'
                                            Width="150px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="180px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="买家账号 (点击可联系)" SortExpression="shaccount" HeaderStyle-ForeColor="Red"
                                    ControlStyle-ForeColor="Red">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lb_account" runat="server" Target="_blank" Text='<%# Bind("shaccount") %>'
                                            NavigateUrl="#"></asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_account" runat="server" Text='<%# Bind("shaccount") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="180px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="快递单号 (点击可查询)" SortExpression="shkdcode" HeaderStyle-ForeColor="Red"
                                    ControlStyle-ForeColor="Red">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hl_state" runat="server" Target="_blank" Text='<%# Bind("shkdcode") %>'
                                            NavigateUrl='<%# "http://www.kiees.cn/yto.php?wen="+ Eval("shkdcode") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_kdcode" runat="server" Text='<%# Bind("shkdcode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="180px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="售后原因 (鼠标悬停可显示全部)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_yuanyin" runat="server" Text='<%# Eval("shyuanyin")!=null?(Eval("shyuanyin").ToString().Length>15?Eval("shyuanyin").ToString().Substring(0,14):Eval("shyuanyin").ToString()):"" %>'
                                            ToolTip='<%# Eval("shyuanyin") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_yuanyin" runat="server" Text='<%# Bind("shyuanyin") %>' Width="180px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="售后状态" SortExpression="shstate">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作时间" SortExpression="shdate">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("shdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
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
                                        <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "sh_problem_add.aspx?id="+ Eval("shid") %>'></asp:HyperLink>
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
                                PageSize="5" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                                SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
                <!-- 返现 -->
                <div class="content" style="background-color: #C9CABB">
                    <div class="c_title">
                        <div class="c_t_name" style="">
                            ● 待处理返现
                        </div>
                        <div class="c_t_desc">
                            <ul>
                                <li>
                                    <asp:Button ID="Button2" runat="server" Text="添加返现" OnClientClick="window.location.href = 'fanxian_add.aspx';return false;" /></li>
                            </ul>
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView3_RowCancelingEdit"
                            OnRowCommand="GridView3_RowCommand" OnRowDataBound="GridView3_RowDataBound" OnRowEditing="GridView3_RowEditing"
                            OnRowUpdating="GridView3_RowUpdating" DataKeyNames="fx_id,fx_state,dpid,fx_zhifubao,fx_num"
                            OnRowDeleting="GridView3_RowDeleting">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
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
                            </asp:TemplateField>--%>
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
                            <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" OnPageChanged="AspNetPager2_PageChanged" PageIndexBoxType="DropDownList"
                                PageSize="5" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                                SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
                <!-- 商品 -->
                <div class="content" style="background-color: #F5F6EB">
                    <div class="c_title">
                        <div class="c_t_name" style="">
                            ● 待补单或报名活动商品
                        </div>
                        <div class="c_t_desc">
                            <ul>
                                <li>
                                    <asp:Button ID="Button3" runat="server" Text="添加商品" OnClientClick="window.location.href = 'basic_goods_add.aspx';return false;" /></li>
                            </ul>
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView2_RowCancelingEdit"
                            OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" OnRowEditing="GridView2_RowEditing"
                            OnRowUpdating="GridView2_RowUpdating" DataKeyNames="bgid,opid,hdid,dpid,bgstate,bgkey,bgupdate"
                            OnRowDeleting="GridView2_RowDeleting">
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "bgid")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" SortExpression="bgid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("bgid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="店铺">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_dianpu" runat="server" Text='<%# Bind("dpname") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="商品名称">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lb_account" runat="server" Target="_blank" Text='<%# Eval("bgname")!=null?(Eval("bgname").ToString().Length>20?Eval("bgname").ToString().Substring(0,19):Eval("bgname").ToString()):"" %>'
                                            ToolTip='<%# Eval("bgname") %>' NavigateUrl='<%# Eval("bgurl") %>' ForeColor="Red"></asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("bgname") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="还需补单" HeaderStyle-ForeColor="Red">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_order" runat="server" Text='<%# Bind("opid") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="活动提示" HeaderStyle-ForeColor="Red">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_huodong" runat="server" Text='<%# Bind("hdid") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="90px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="上架时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_update" runat="server" Text='<%# Convert.ToDateTime(Eval("bgupdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'
                                            ForeColor="Red"> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_update" runat="server" Text='<%# Convert.ToDateTime(Eval("bgupdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="130px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="重点">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_key" runat="server" CommandName="iskey"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="添加时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("bgdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="130px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注信息">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("bgremark")!=null?(Eval("bgremark").ToString().Length>10?Eval("bgremark").ToString().Substring(0,9)+"...":Eval("bgremark").ToString()):"" %>'
                                            ToolTip='<%# Eval("bgremark") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_remark" runat="server" Text='<%# Eval("bgremark") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作" ShowHeader="False" ItemStyle-Font-Bold="true">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="更新"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbtn_clear" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="取消"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "basic_order_record_add.aspx?bgid="+Eval("bgid") %>'
                                            Text="添加补单"> </asp:HyperLink>
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "basic_order_record_list.aspx?bgid="+Eval("bgid") %>'
                                            Text="查询补单"> </asp:HyperLink>
                                        <%-- <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "basic_goods_add.aspx?id="+Eval("bgid") %>'
                                        Text="关键词"> </asp:HyperLink>--%>
                                        <asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="编辑"></asp:LinkButton>
                                        <%--<asp:HyperLink ID="hl_history" runat="server" Text="历史" NavigateUrl='<%# "fanxian_list.aspx?key="+ Eval("fx_zhifubao") %>'></asp:HyperLink>--%>
                                        <asp:HyperLink ID="hl_info" runat="server" NavigateUrl='<%# "basic_goods_add.aspx?id="+Eval("bgid") %>'
                                            Text="详细"> </asp:HyperLink>
                                        <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
