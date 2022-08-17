<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmRegistro.aspx.cs" Inherits="TODOOFERTAS.Presentacion.wfrmRegistro" %>

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
            <div class="mb-3">
                Cédula
                <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" MaxLength="8" />
            </div>
            <div class="mb-3">
                Nombre
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                Contraseña
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistro" type="button" class="btn btn-dark" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
            </div>
            <div class="mb-3" style="color:black">
                Ya tienes una cuenta? Inicia sesión 
                <a href="wfrmLogin.aspx" class="link-primary">aquí</a>
            </div>
            <div class="mb-3">
                <label id="txtMensaje" class="form-label" runat="server"></label>
            </div>
        </div>
        <div class="col-lg-2"></div>
    </div>
</asp:Content>
