<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmInsertarPromocion.aspx.cs" Inherits="TODOOFERTAS.Presentacion.wfrmInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function SoloNumeros(e) {
            if (!(/[0-9]/.test(e.key)))
                e.preventDefault();
        }
    </script>

    <h3 style="margin-top: 2%">Promoción</h3>
    <div class="row" style="margin-top: 2%">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <p style="font-size: 2em; font-weight: bold; text-align: center">Promoción</p>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Id de Promoción</label>
                <input type="text" class="form-control" id="txtIdProm" runat="server">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Título</label>
                <input type="text" class="form-control" id="txtTitulo" runat="server">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Producto</label>
                <input type="text" class="form-control" id="txtProducto" runat="server">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Descripción</label>
                <textarea class="form-control" id="txtDescripcion" rows="3" runat="server"></textarea>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Precio Original</label>
                <input type="number" class="form-control" id="txtPrecioOriginal" runat="server">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Precio con Descuento</label>
                <input type="number" class="form-control" id="txtPrecioDescuento" runat="server" disabled>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Porcentaje de Descuento</label>
                <input type="number" class="form-control" id="txtPorcentajeDescuento" runat="server">
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Imagen del Producto</label>
                <input class="form-control" type="text" id="txtImagen" runat="server">
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Fecha de Finalización de la Promoción</label>
                <input class="form-control" type="date" id="txtFecha" runat="server">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Detalles</label>
                <textarea class="form-control" id="txtDetalles" rows="3" runat="server"></textarea>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Condiciones</label>
                <textarea class="form-control" id="txtCondiciones" rows="3" runat="server"></textarea>
            </div>
            <div class="mb-3" style="display: flex; justify-content: center; align-items: center;">
                <asp:Button ID="btnInsertar" Style="margin-left: 1%; margin-right: 1%;" type="button" class="btn btn-success" runat="server" OnClick="btnInsertar_Click" Text="Agregar" />
                <asp:Button ID="btnEliminar" Style="margin-left: 1%; margin-right: 1%;" type="button" class="btn btn-danger" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                <asp:Button ID="btnModificar" Style="margin-left: 1%; margin-right: 1%;" type="button" class="btn btn-warning" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
            </div>
            <div class="mb-3">
                <label id="txtMensaje" class="form-label" runat="server"></label>
            </div>
            <div class="mb-3">
                <asp:ListBox ID="lstPromocion" class="form-control" runat="server" OnSelectedIndexChanged="lstPromocion_Click" AutoPostBack="True"></asp:ListBox>
            </div>
        </div>
        <div class="col-lg-2"></div>
    </div>
</asp:Content>
