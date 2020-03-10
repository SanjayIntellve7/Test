//function loadTwoColumnChart(datapointArray, chartTitle, chartContainerName,Type) {
//    var chartType = $("#chartTypes option:selected").text();

//    let chartdata;
//    if (chartType == "Bar")
//        chartdata = [{ type: "bar", dataPoints: datapointArray.first }, { type: "bar", dataPoints: datapointArray.second }];
//    else if (chartType == "Column")
//        chartdata = [{ type: "column", dataPoints: datapointArray.first }, { type: "column", dataPoints: datapointArray.second }];
//    else if (chartType == "Line")
//        chartdata = [{ type: "line", dataPoints: datapointArray.first }, { type: "line", dataPoints: datapointArray.second }];

//    let chart = new CanvasJS.Chart(chartContainerName,
//        {
//            title: {
//                text: chartTitle
//            },
//            data: chartdata 
//        });
//    chart.render();
//} 


function loadTwoColumnChart(datapointArray, chartTitle, chartContainerName, chartType) {
    console.log(datapointArray + "-" + chartTitle + "-" + chartContainerName + "-" + chartType);
    let chartdata = [{ type: chartType, dataPoints: datapointArray.first }, { type: chartType, dataPoints: datapointArray.second }];
    console.log(chartdata);
    let chart = new CanvasJS.Chart(chartContainerName,
        {
            title: {
                text: chartTitle
            },
            data: chartdata  
        });
    chart.render();
} 

 