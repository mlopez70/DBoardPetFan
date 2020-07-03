<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comparativo.ascx.cs" Inherits="DBoardPetFan.WEB.Comparativo" %>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var data = google.visualization.arrayToDataTable(<%=ObtenerInfo()%>);

        var options = {
            title: '<%=Titulo%>',
            is3D: true,
            backgroundColor: { fill: 'Transparent' },
            fillOpacity: 0.7,
            legend: { position: 'labeled', textStyle: { color: "red", fontSize: 14 }},
            tooltip: { textStyle: { color: "red" }, showColorCode: true},
        };
        var chart = new google.visualization.PieChart(document.getElementById('<%=sDiv%>'));
        chart.draw(data, options);
    }
</script>



<div runat="server" id="DGridDatos" style="text-align: center; vertical-align: middle; width: 100%; padding: 5%"> 
    <div runat="server" id="DivHeader" style="text-align: center; vertical-align: middle; width: 100%;padding:20px"></div>
    <div runat="server" id="GraficaDatos" style="text-align: center; vertical-align: middle; width: 100%;"></div>    
    <asp:GridView ID="GrdDetalle" runat="server" CssClass="table table-striped table-bordered" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" ShowFooter="True" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GrdDetalle_RowDataBound">
        <FooterStyle BackColor="#FFFFCC" Font-Bold="True"  ForeColor="Black" />
    </asp:GridView>
</div>
