<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Actos.SitioWeb.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title />
    <link href="Content/inicio.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/inicio.js" ></script>
</head>
<body onload="AnimarR1(), AnimarR2()">
    <div id="r1" class="rectangulo1">
        <asp:Label ID="lblActos" runat="server" CssClass="absoluto actos-posicion-estilo"></asp:Label>
    </div>

    <div class="main">
        <div class="wrapper">
            <div id="r2" class="rectangulo2">
                <div>
                    <asp:HyperLink ID="lnkAgresores" runat="server" />
                </div>
                <div>
                    <asp:HyperLink ID="lnkVictimas" runat="server" />
                </div>
                <div>
                    <asp:HyperLink ID="lnkAntecedentes" runat="server" />
                </div>
            </div>
        </div>
    </div>
</body>
</html>
