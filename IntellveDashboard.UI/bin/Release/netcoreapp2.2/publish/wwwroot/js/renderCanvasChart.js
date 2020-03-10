CanvasJS.addColorSet("shades", ["#595DCB", "#4BCB8F", "#31C5D8", "#C0CA33", "#FC4B6C", "#338BE2", "#FFB22B"]);

function drawAlertCountBifurcationChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCountBifurcation?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown);
            $("#AlertCountBifurcationChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCountBifurcationChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            console.log(DataPointsCollection);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") {
                indexLabel_type = "#percent%";
                toolTipContent_type = "{y} (#percent%)";
            }
            else {
                indexLabel_type = "{y}";
                toolTipContent_type = "{name}: <strong>{y}</strong>";
            }

            chartdata.push({
                type: chartType,
                indexLabelPlacement: "outside",
                indexLabel: indexLabel_type,
                toolTipContent: toolTipContent_type,
                dataPoints: DataPointsCollection.first,
            });
            if (DataPointsCollection.second != null)
                chartdata.push({
                    type: chartType,
                    indexLabelPlacement: "outside",
                    indexLabel: indexLabel_type,
                    toolTipContent: toolTipContent_type,
                    dataPoints: DataPointsCollection.second,
                });

            //let colors ;  
            //if (chartType == "funnel")
            //    colors  = ["#595DCB", "#9286E9"];
            //else
            //    colors  = ["#4BCB8F", "#700000"];

            var chart = new CanvasJS.Chart("AlertCountBifurcationChartContainer",
                {
                    exportFileName: "CanvasJS",
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    showInLegend: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a",
                        title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a",
                        title: "Source",
                    },
                    legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();

            /*Export To CSV File*/
            document.getElementById("downloadCSV").addEventListener("click", function () {
                downloadCSV({ filename: "chart-data.csv", chart: chart });
            });
            /*Export To jpg File*/
            document.getElementById("exportChart").addEventListener("click", function () {
                chart.exportChart({ format: "jpg" });
            });

        }, beforeSend: function () {
            $("#AlertCountBifurcationChart-loading-image").show();
        }
    });
}

function drawAlertCountReasonCodeChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCountBasedOnCloseReason?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown);
            $("#ReasonCode-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#ReasonCode-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });

            var chart = new CanvasJS.Chart("AlertCountReasonCodeChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Reason Code",
                    },
                    legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#ReasonCode-loading-image").show();
        }
    });
}

function drawAlertCountStatusChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCountStatus?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown);
            $("#AlertCountStatusChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCountStatusChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("AlertCountStatusChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Status",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertCountStatusChart-loading-image").show();
        }
    });
}

function drawAlertCountOperatorChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetOperatorVsAlertCount?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertCountOperatorChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCountOperatorChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });




            var chart = new CanvasJS.Chart("AlertCountOperatorChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Operators",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertCountOperatorChart-loading-image").show();
        }
    });
}

function drawAlertCountTrendAcknowledgeChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCountTrendAcknowledgeInDelay?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertCountTrendAcknowledgeChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCountTrendAcknowledgeChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });


            var chart = new CanvasJS.Chart("AlertCountTrendAcknowledgeChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Hours(hrs)",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertCountTrendAcknowledgeChart-loading-image").show();
        }
    });
}

function drawAlertCountTrendChart(filter, chartType) {


    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCountTrend?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertCountTrendChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCountTrendChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("AlertCountTrendChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Hours(hrs)",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertCountTrendChart-loading-image").show();
        }
    });
}

function drawAlertCountTrendClosingChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCountTrendInDelayClosing?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertCountTrendClosingChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCountTrendClosingChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("AlertCountTrendClosingChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Hours(hrs)",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertCountTrendClosingChart-loading-image").show();
        }
    });
}

function drawAlertResponseTimeRangeChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertResponseTimeRange?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertResponseTimeRangeChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertResponseTimeRangeChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("AlertResponseTimeRangeChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Response Time Range",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertResponseTimeRangeChart-loading-image").show();
        }
    });
}

function drawAlertCloserTimeRangeChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertCloserTimeRange?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertCloserTimeRangeChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertCloserTimeRangeChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });




            var chart = new CanvasJS.Chart("AlertCloserTimeRangeChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Closer Time Range",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertCloserTimeRangeChart-loading-image").show();
        }
    });
}

function drawFrequentMostAlertGeneratingBranchesChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetFrequentMostAlertGeneratingBranches?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#FrequentMostAlertGeneratingBranchesChart-loading-image").hide();
            alert("Something went wrong!");
        },
        height: 460,
        success: function (result) {
            $("#FrequentMostAlertGeneratingBranchesChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("FrequentMostAlertGeneratingBranchesChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Branch Ids",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#FrequentMostAlertGeneratingBranchesChart-loading-image").show();
        }
    });
}

function drawArmDisarmChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetFrequentArmDisArmBranch?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#ArmDisarmChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#ArmDisarmChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });

            var chart = new CanvasJS.Chart("ArmDisarmChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Branch Ids",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#ArmDisarmChart-loading-image").show();
        }
    });
}

function drawEyeballOperatorChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetEyeBallAlertGeneratedByOperator?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#EyeballOperatorChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#EyeballOperatorChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];
            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });

            var chart = new CanvasJS.Chart("EyeballOperatorChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    dataPointWidth: 20,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Eyeball Operators",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#EyeballOperatorChart-loading-image").show();
        }
    });
}

function drawAlertBifurcationBySourceChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertBifurcationBySource?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertBifurcationBySourceChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertBifurcationBySourceChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("AlertBifurcationBySourceChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Source",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertBifurcationBySourceChart-loading-image").show();
        }
    });
}

function drawSystemVsManualChart(filter, chartType) {

    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetSystemVsManualAlerts?Datafilter=" + filter,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#SystemVsManualChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#SystemVsManualChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("SystemVsManualChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,

                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Alert Types",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#SystemVsManualChart-loading-image").show();
        }
    });
}


function drawAlertBifurcationByDeviceTypeFilterChart(filter, chartType, TypeCSV) {
    console.log(filter + "," + chartType + "," + TypeCSV);
    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/Dashboard/GetAlertsBifurcationTypeFilter?Datafilter=" + filter + "&TypeFilter=" + TypeCSV,
        contentType: "application/json",
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR + "-" + textStatus + "-" + errorThrown); $("#AlertBifurcationBySourceChart-loading-image").hide();
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#AlertBifurcationBySourceChart-loading-image").hide();
            var DataPointsCollection = $.parseJSON(result);
            let chartdata = [];

            let indexLabel_type, toolTipContent_type;
            if (chartType == "pie") { indexLabel_type = "#percent%"; toolTipContent_type = "{y} (#percent%)"; }
            else { indexLabel_type = "{y}"; toolTipContent_type = "{name}: <strong>{y}</strong>"; }

            chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.first, });
            if (DataPointsCollection.second != null)
                chartdata.push({ type: chartType, indexLabelPlacement: "outside", indexLabel: indexLabel_type, toolTipContent: toolTipContent_type, dataPoints: DataPointsCollection.second, });



            var chart = new CanvasJS.Chart("AlertBifurcationBySourceChartContainer",
                {
                    colorSet: "shades",
                    theme: "light1", // "light1", "light2", "dark1", "dark2"
                    animationEnabled: true,
                    axisY: {
                        gridColor: "#ecf1f1",
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Number of Alerts",
                    }, axisX: {
                        lineThickness: 1,
                        lineColor: "#9a9a9a", title: "Source",
                    }, legend: {
                        cursor: "pointer",
                        itemclick: function (e) {
                            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                e.dataSeries.visible = false;
                            }
                            else {
                                e.dataSeries.visible = true;
                            }
                            chart.render();
                        }
                    },
                    data: chartdata
                });
            chart.render();
        }, beforeSend: function () {
            $("#AlertBifurcationBySourceChart-loading-image").show();
        }
    });
}

/*Download csv functions */
function convertChartDataToCSV(args) {
    var result, ctr, keys, columnDelimiter, lineDelimiter, data;

    data = args.data || null;
    if (data == null || !data.length) {
        return null;
    }

    columnDelimiter = args.columnDelimiter || ',';
    lineDelimiter = args.lineDelimiter || '\n';

    keys = Object.keys(data[0]);

    result = '';
    result += keys.join(columnDelimiter);
    result += lineDelimiter;

    data.forEach(function (item) {
        ctr = 0;
        keys.forEach(function (key) {
            if (ctr > 0) result += columnDelimiter;
            result += item[key];
            ctr++;
        });
        result += lineDelimiter;
    });
    return result;
}

function downloadCSV(args) {
    var data, filename, link;
    var csv = "";
    for (var i = 0; i < args.chart.options.data.length; i++) {
        csv += convertChartDataToCSV({
            data: args.chart.options.data[i].dataPoints
        });
    }
    if (csv == null) return;

    filename = args.filename || 'chart-data.csv';

    if (!csv.match(/^data:text\/csv/i)) {
        csv = 'data:text/csv;charset=utf-8,' + csv;
    }

    data = encodeURI(csv);
    link = document.createElement('a');
    link.setAttribute('href', data);
    link.setAttribute('download', filename);
    document.body.appendChild(link); // Required for FF
    link.click();
    document.body.removeChild(link);
}
