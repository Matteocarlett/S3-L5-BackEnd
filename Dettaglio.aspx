<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="S3_L5.Dettaglio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dettaglio Prodotto</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<style>
    body {
        background-image: url('https://wallpapers.com/images/hd/asus-rog-4k-gaming-logo-rosso-e-nero-cjd323nj08nsprut.jpg');
        background-repeat: no-repeat;
        background-size: cover;
    }
    #imgArticolo{
        width:40%
    }

</style>

<body>
    <form id="form1" runat="server">
        <div class="container ">
            <h1 class="text-light">Dettaglio Prodotto</h1>
            <div class="card">
                <div class="d-flex justify-content-center">
                <asp:Image ID="imgArticolo" runat="server" CssClass="card-img-top" />
                    </div>
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Literal ID="litNome" runat="server" /></h5>
                    <p class="card-text">
                        <asp:Literal ID="litDescrizione" runat="server" /></p>
                    <p class="card-text">Prezzo:
                        <asp:Literal ID="litPrezzo" runat="server" /></p>
                    <asp:Button ID="btnAggiungiCarrello" runat="server" Text="Aggiungi al Carrello" CssClass="btn btn-success" OnClick="btnAggiungiCarrello_Click" />
                    <asp:Button ID="btnVaiDefault" runat="server" Text="Home Negozio" CssClass="btn btn-primary" OnClick="btnVaiDefault_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
