<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Consulta.ascx.cs" Inherits="DBoardPetFan.WEB.Consulta" %>
<div>
        <table style="width: 100%">
            <tr>
                <td style="padding: 50px">
                    <table style="width: 100%; text-align: center; vertical-align: middle">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Año"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Mes"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Grafica"></asp:Label></td>
                            <td rowspan="2" style="text-align: center; vertical-align: middle">
                                <asp:Button ID="BtnExe" runat="server" Text="Procesar" CssClass="btn btn-success" OnClick="BtnExe_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DDLAno" runat="server">                                    
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="DDLMes" runat="server">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="DDlOpcion" runat="server">
                                    <asp:ListItem Value="1">Segmento</asp:ListItem>
                                    <asp:ListItem Value="1">Productos</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>

                    </table>
                </td>
            </tr>         
        </table>

    </div>