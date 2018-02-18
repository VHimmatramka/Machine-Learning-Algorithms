<%@page import="com.controller.SendData"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
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
			for (var i = 0; i < errors.length; i++) {
				console.log(errors[i]);
			}
			var canvas = document.getElementById('myChart');
			var data = {
			    labels: ["1", "2", "3", "4", "5", "6", "7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32"],
			    datasets: [
			        {
			            label: "Accuracy "+accuracy,
			            fill: false,
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
			            pointRadius: 5,
			            pointHitRadius: 10,
			            data: [errors[0], errors[1], errors[2], errors[3], errors[4], errors[5], errors[6], errors[7], errors[8], errors[9], errors[10], errors[11], errors[12], errors[13], errors[14], errors[15], errors[16], errors[17], errors[18], errors[19], errors[20], errors[21], errors[22], errors[23], errors[24], errors[25], errors[26], errors[27], errors[28], errors[29], errors[30], errors[31]],
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