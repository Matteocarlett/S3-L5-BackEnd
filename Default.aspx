<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="S3_L5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ecommerce</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>

<style>
    .immagini {
        margin-bottom: 50%
    }

    .info {
        position: absolute;
        bottom: 0;
        left: 0;
        width: 100%;
    }
    body{
        background-image:url('https://wallpapers.com/images/hd/asus-rog-4k-gaming-logo-rosso-e-nero-cjd323nj08nsprut.jpg');
        background-repeat:no-repeat;
        background-size:cover;
    }
    .title{
        font-size:1.8rem;
    }
</style>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark ">
            <div class="container">
                <a class="navbar-brand title" href="#">Gamer Shop </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="Default.aspx">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Carrello.aspx">Carrello</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container mt-4">
            <h1 class="text-light">Prodotti</h1>

            <div class="row justify-content-center ">
                <asp:Repeater ID="ArticoliRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card h-100">
                                <div class="d-flex justify-content-center">
                                    <img src='<%# Eval("ImmagineUrl") %>' class="immagini card-img-top img-fluid mt-3 pb-2" alt='<%# Eval("Nome") %>' style='<%# "width: " + Eval("DimensioneImmagine") %>' />
                                </div>
                                <div class="card-body info">
                                    <h5 class="card-title"><%# Eval("Nome") %></h5>
                                    <p class="card-text"><%# Eval("Descrizione") %></p>
                                    <p class="card-text">Prezzo: <%# Eval("Prezzo", "{0:C}") %></p>
                                    <a href='<%# "Dettaglio.aspx?id=" + Eval("Id") %>' class="btn btn-primary">Dettagli</a>
                                    <asp:Button ID="btnAggiungiCarrello" runat="server" Text="Aggiungi al Carrello" CssClass="btn btn-success" OnClick="btnAggiungiCarrello_Click" CommandArgument='<%# Eval("Id") %>' />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>


            </ItemTemplate>
</asp:Repeater>

        </div>
        <p>Totale:
            <asp:Literal ID="litTotale" runat="server" /></p>
        </div>
    </form>
</body>
</html>
