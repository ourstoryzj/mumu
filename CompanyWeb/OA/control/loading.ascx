<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loading.ascx.cs" Inherits="OA_control_loading" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <style type="text/css">
            #load
            {
                position: absolute;
                z-index: 100;
                left: 40%;
                top: 40%;
            }
            #dang
            {
                background-color: #f0f1f1;
                width: 100%;
                height: 100%;
                position: absolute;
                z-index: 10;
                top: 0px;
                left: 0px; /*-moz-opacity: 0.8;
        -khtml-opacity: 0.8;*/
            }
        </style>
        <div id="load">
            <img src="images/loading2.gif" />
        </div>
        <div id="dang" style="filter: alpha(opacity=80); opacity: 0.8;">
            &nbsp;
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                //        var w = ($(document).width() - $("#load").width()) / 2;
                //        var h = ($(document).height() - $("#load").height()) / 2;
                //        $("#load").css("left", w);
                //        $("#load").css("top", h);

            });
        </script>
    </ProgressTemplate>
</asp:UpdateProgress>
