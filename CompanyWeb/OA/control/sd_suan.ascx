<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sd_suan.ascx.cs" Inherits="OA_control_sd_suan" %>
<table>
    <tr>
        <td style="color: red;">
            刷单计算公式
        </td>
        <td>
            流量<input id="txt_liuliang" type="text" style="width: 50px;" />*转化率<input id="txt_zhuanhualv"
                type="text" value="3" style="width: 50px;" />%=今日销量<input id="txt_xiaoliang" type="text"
                    style="width: 50px;" />
            <input id="btn_suan" type="button" value="计算" onclick="to_suan();" />
        </td>
    </tr>
</table>
<script>
    function to_suan() {
        if ($("#txt_liuliang").val() == "") {
            alert("请输入流量");
            $("#txt_liuliang").focus();
            return;
        }
        $("#txt_xiaoliang").val(($("#txt_liuliang").val() * $("#txt_zhuanhualv").val()) / 100);
        return;
    }
</script>
