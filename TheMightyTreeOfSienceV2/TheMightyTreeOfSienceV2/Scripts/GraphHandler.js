
function GetNetworkAjaxDotNet() {
    $.ajax({
        url: 'Home/GetNetworkData',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            var parsedData = JSON.parse(data); // json is assumed valid, no need for checking
            document.getElementById('network').innerHTML = "";
            var container = document.getElementById('network');
            var data = {
                nodes: parsedData["nodes"],
                edges: parsedData["edges"]
            };

            //TODO: opciókat is átadni szerver oldalról.
            /*var options = {
                nodes: { borderWidth: 2 },
                interaction: { hover: true }
            };*/

            var options = {
                physics: {
                    barnesHut: {
                        centralGravity: 0.001
                    },
                    minVelocity: 0.75
                },
                interaction: {
                    hover: true,
                    hoverConnectedEdges: true,
                    keyboard: false
                },
                edges: {
                    smooth: {
                        type: 'discrete'
                    },
                    width: 0.4,
                    selectionWidth: 0.5,
                    hoverWidth: 0.5,
                    arrows: { to: true }
                },

                nodes: {
                    shape: 'text',
                    color: '#822309',
                    scaling: {
                        customScalingFunction: function (min, max, total, value) {
                            if (value == 0 || value >= 10) {
                                return 0.08;
                            } else if (value == 1) {
                                return 1;
                            } else if (value == 2) {
                                return 0.7;
                            } else if (value == 3) {
                                return 0.5;
                            } else if (value == 4) {
                                return 0.2;
                            } else if (value == 5) {
                                return 0.13;
                            } else if (value == 6) {
                                return 0.11;
                            } else if (value == 7) {
                                return 0.09;
                            } else if (value == 8) {
                                return 0.07;
                            } else if (value == 9) {
                                return 0.06;
                            }
                        },
                        min: 0,
                        max: 10,
                        label: {
                            enabled: true,
                            min: 0,
                            max: 80,
                            maxVisible: 40,
                            drawThreshold: 20
                        }
                    }
                }
            };

            // ez felel a kis ablakok felugrásáért
            // TODO: rájönni mit miért csinál.
            /*$("#search").click(function () {
                $("#frame").hide("drop", 500);
            });

            $("#search").keydown(function () {
                $("#frame").hide("drop", 500);
            });*/

            var network = new vis.Network(container, data, options);
        },
        error: function (xhr, ajaxOptions, thrownError) { alert("Hiba! "+xhr.responseText+ " "+thrownError); },
    });
}

function Search(sText) {
    $.ajax({
        url: "Home/Search",
        parameter: { searchText: sText },
        method: "GET",
        dataType: "json",
        success: function(data) {
            alert(data);
        },
        error: function (xhr, ajaxOptions, thrownError) { alert("Hiba! "+xhr.responseText+ " "+thrownError); }
    });
}

function TestGraph() {
    alert("test");
    var nodes = new vis.DataSet([
    { id: 1, label: 'html color', color: 'lime' },
    { id: 2, label: 'rgb color', color: 'rgb(255,168,7)' },
    { id: 3, label: 'hex color', color: '#7BE141' },
    { id: 4, label: 'próba node', color: 'rgba(97,195,238,0.8)' },
    { id: 5, label: 'colorObject', color: { background: 'pink', border: 'purple' } },
    { id: 6, label: 'colorObject + highlight', color: { background: '#F03967', border: '#713E7F', highlight: { background: 'red', border: 'black' } } },
    { id: 7, label: 'colorObject + highlight + hover', color: { background: 'cyan', border: 'blue', highlight: { background: 'red', border: 'blue' }, hover: { background: 'white', border: 'red' } } }
    ])

    // create an array with edges
    var edges = new vis.DataSet([
      { from: 1, to: 3 },
      { from: 1, to: 2 },
      { from: 2, to: 4 },
      { from: 2, to: 5 },
      { from: 2, to: 6 },
      { from: 4, to: 7 },
      { from: 4, to: 6 },
      { from: 4, to: 6 },
      { from: 4, to: 6 },
      { from: 4, to: 6 },
    ]);
    // create a network
    var container = document.getElementById('network');
    var data = {
        nodes: nodes,
        edges: edges
    };
    var options = {
        nodes: { borderWidth: 2 },
        interaction: { hover: true }
    }
    var network = new vis.Network(container, data, options);
}