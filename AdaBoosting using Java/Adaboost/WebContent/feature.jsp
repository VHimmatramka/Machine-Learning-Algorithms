<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
    <%@page import="com.controller.SendData"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.1.3/Chart.min.js"></script>
</head>
<body>
	<canvas id="myChart" width="400" height="150"></canvas>

	<%
		SendData data = (SendData) session.getAttribute("data");
	%>
	<script type="text/javascript">
		var accuracy="<%out.print(data.accuracy);%>";
		console.log(accuracy);
		var errors = [];
		<%
			double err[] = data.errors;
			for(int i = 0 ; i < err.length ; i++){
		%>
			errors[<%out.print(i);%>] = <%=err[i] %>;
			<%
			}
			%>
			var canvas = document.getElementById('myChart');
			var labels = []; 
			for(var i = 0 ; i < errors.length ; i++){
				labels[i] = i + 1;
			}
			var data = {
			    labels: labels,
			    datasets: [
			        {
			            label: "Accuracy "+accuracy,
			            fill: true,
			            lineTension: 0.1,
			            backgroundColor: "rgba(75,192,192,0.4)",
			            borderColor: "rgba(75,192,192,1)",
			            borderCapStyle: 'butt',
			            borderDash: [],
			            borderDashOffset: 0.0,
			            borderJoinStyle: 'miter',
			            pointBorderColor: "rgba(75,192,192,1)",
			            pointBackgroundColor: "#fff",
			            pointBorderWidth: 1,
			            pointHoverRadius: 5,
			            pointHoverBackgroundColor: "rgba(75,192,192,1)",
			            pointHoverBorderColor: "rgba(220,220,220,1)",
			            pointHoverBorderWidth: 2,
			            pointRadius: 0,
			            pointHitRadius: 10,
			            data: errors,
			        }
			    ]
			};
			var option = {
				showLines: true
			};
			var myLineChart = Chart.Line(canvas,{
				data:data,
			  options:option
			});
			
	</script>
</body>
</html>