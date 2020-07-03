<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Segmentos.aspx.cs" Inherits="DBoardPetFan.WEB.Segmentos" %>

<%@ Register Src="~/Comparativo.ascx" TagPrefix="uc1" TagName="Comparativo" %>
<%@ Register Src="~/Consulta.ascx" TagPrefix="uc1" TagName="Consulta" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="text-align:center;vertical-align:middle;width:100%">
        <tr>
            <td colspan="2">
                <uc1:Consulta runat="server" id="Consulta" />
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:Label ID="LblTitulo" runat="server" Text="Label" CssClass="btn-info" Width="95%" Font-Size="Larger" ForeColor="white"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:Comparativo runat="server" ID="SegmentoMes" />
            </td>
            <td>
                <uc1:comparativo runat="server" id="SegmentoAcum" />
            </td>
        </tr>
    </table>
</asp:Content>
