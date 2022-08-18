<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmInicio.aspx.cs" Inherits="TODOOFERTAS.Presentacion.wfrmInicio1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function LetrasYNumeros(e) {
            if (!(/[A-Za-z0-9]/.test(e.key)))
                e.preventDefault();
        }
    </script>

    <div class="row" style="text-align: center">
        <h2>Promociones</h2>
        <br />
    </div>
    <div class="container" style="text-align: center">
        <div class="row">
            <%foreach (var item in this.Item)
                { %>
            <div class="col-lg-3 col-md-3 col-sm-3" style="margin-bottom: 2em">
                <div class="card" style="width: 18rem;">
                    <img style="width: 100%; height: 350px" src="<%=item.Imagen%>" class="card-img-top">
                    <div class="card-body">
                        <h5 class="card-title"><%=item.Producto%></h5>
                        <span style="text-decoration: line-through; color: grey;">$<%=item.PrecioOriginal%></span><span style="margin-left: 5%; color: green;"><%=item.PorcentajeDesc%>% Off</span>
                        <p class="card-text" style="font-size: 1.5em">$<%=item.PrecioPromocion%></p>
                        <p class="card-text" style="font-size: 1.2em">Código: <%=item.Id %></p>
                    </div>
                </div>
            </div>
            <% } %>
        </div>

        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4" style="margin-top: 1.5em">
                <asp:TextBox runat="server" ID="txtIdPromocion" class="form-control" placeholder="Ingrese código de promoción" MaxLength="6" /><asp:Button class="btn btn-primary" ID="btnComprar" Text="Comprar" Style="margin-top: 1em" runat="server" OnClick="btnComprar_Click" />
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
        </div>

        <label id="txtMensaje" class="form-label" runat="server"></label>
    </div>
</asp:Content>
