<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="DBoardPetFan.WEB.Inicio" %>

<%@ Register Src="~/Comparativo.ascx" TagPrefix="uc1" TagName="Comparativo" %>
<%@ Register Src="~/Consulta.ascx" TagPrefix="uc1" TagName="Consulta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <uc1:Consulta runat="server" id="Consulta" />
</asp:Content>
