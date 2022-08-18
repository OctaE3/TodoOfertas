<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmLoginUsuario.aspx.cs" Inherits="TODOOFERTAS.Presentacion.wfrmLoginUsuario" %>

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
            <p style="font-size: 2em; font-weight: bold; text-align: center">Login Usuario</p>
            <div class="mb-3">
                Cédula (8 números sin punto ni guión)
                <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" MaxLength="8" />
            </div>
            <div class="mb-3">
                Contraseña
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="16" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnIniciarSesion" type="button" class="btn btn-dark" runat="server" Text="Ingresar" OnClick="btnIniciarSesion_Click" />
            </div>
            <asp:CheckBox ID="chkPersistCookie" runat="server" AutoPostBack="false" Checked="true" Visible="false" />
            <div class="mb-3" style="color: black">
                No tienes Cuenta? Registrate 
                <a href="wfrmRegistroUsuario.aspx" class="link-primary">aquí</a>
            </div>
            <div class="mb-3" style="color: black">
                Tienes cuenta de administrador? Inicia sesión
                <a href="wfrmLogin.aspx" class="link-primary">aquí</a>
            </div>
            <div class="mb-3">
                <label id="txtMensaje" class="form-label" runat="server"></label>
            </div>
        </div>
        <div class="col-lg-2"></div>
    </div>
</asp:Content>
