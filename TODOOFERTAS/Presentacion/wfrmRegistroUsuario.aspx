<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmRegistroUsuario.aspx.cs" Inherits="TODOOFERTAS.Presentacion.wfrmRegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function SoloLetras(e) {
            if (!(/[A-Za-z]/.test(e.key)))
                e.preventDefault();
        }

        function SoloNumeros(e) {
            if (!(/[0-9]/.test(e.key)))
                e.preventDefault();
        }
    </script>

    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <p style="font-size: 2em; font-weight: bold; text-align: center">Registro Usuario</p>
            <div class="mb-3">
                Cédula (8 números sin punto ni guión)
                <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" MaxLength="8" />
            </div>
            <div class="mb-3">
                Nombre
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                Contraseña (máx. 16 carácteres)
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="16" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistro" type="button" class="btn btn-dark" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
            </div>
            <div class="mb-3" style="color:black">
                Ya tienes una cuenta? Inicia sesión 
                <a href="wfrmLoginUsuario.aspx" class="link-primary">aquí</a>
            </div>
            <div class="mb-3">
                <label id="txtMensaje" class="form-label" runat="server"></label>
            </div>
        </div>
        <div class="col-lg-2"></div>
    </div>
</asp:Content>
