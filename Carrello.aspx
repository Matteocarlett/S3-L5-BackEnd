<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="S3_L5.Carrello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrello</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<style>
    body {
        background-image: url('https://wallpapers.com/images/hd/asus-rog-4k-gaming-logo-rosso-e-nero-cjd323nj08nsprut.jpg');
        background-repeat: no-repeat;
        background-size: cover;
    }

    .title {
        font-size: 1.8rem;
    }
</style>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark">
            <div class="container">
                <a class="navbar-brand title" href="#">Gamer Shop</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="Default.aspx">Home</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container mt-4 text-light">
            <h1>Carrello</h1>
            <table class="table">
                <thead>
                    <tr class="text-light">
                        <th>Nome</th>
                        <th></th>
                        <th>Prezzo</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptCarrello" runat="server">
                        <ItemTemplate>
                            <tr class="text-light">
                                <td><%# Eval("Nome") %> </td>
                                <td>
                                    <asp:Image ID="imgProdotto" runat="server" ImageUrl='<%# Eval("ImmagineUrl") %>' Height="50" Width="50" />
                                </td>
                                <td><%# Eval("Prezzo", "{0:C}") %></td>
                                <td>
                                    <asp:Button ID="btnRimuovi" runat="server" Text="Rimuovi" CssClass="btn btn-danger" OnClick="btnRimuovi_Click" CommandArgument='<%# Eval("Id") %>' /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
            <p>
                Totale:
                <asp:Literal ID="litTotale" runat="server" />
            </p>
            <asp:Button ID="btnSvuotaCarrello" runat="server" Text="Svuota Carrello" CssClass="btn btn-danger" OnClick="btnSvuotaCarrello_Click" />
        </div>
    </form>
</body>
</html>
