
function GetNetworkAjaxDotNet() {
    $.ajax({
        url: 'Home/GetNetworkData',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            var parsedData = JSON.parse(data); // json is assumed valid, no need for checking
            document.getElementById('network').innerHTML = "";
            var container = document.getElementById('network');
            var graphData = null;
            console.log(parsedData);
            if (parsedData["error"] == null) {
                graphData = {
                    nodes: parsedData["nodes"],
                    edges: parsedData["edges"]
                };
                console.log("Error has occured!\n");
            } else {
                var errorNode = {
                    id: 1,
                    title: parsedData["error"]["info"]["usrInfo"],
                    label: parsedData["error"]["info"]["systemMessage"],
                    color: {
                        background: "#2A0A0A"
                    },
                    font: {
                        color: "#FFFFFF",
                        face: "arial",
                        align: "center"
                    }
                };

                graphData = {
                    nodes: errorNode,
                    edges: null
                };
            }
            //TODO: opciókat is átadni szerver oldalról.
            var options = {
                configure: {
                    enabled: true,
                    showButton: true,
                    filter: true
                },
                nodes: {
                    borderWidth: 2,
                    borderWidthSelected: 3,
                    heightConstraint: false,
                    margin: 5,
                    shadow: false,
                    font: {
                        color: "#FFFFFF",
                        face: "arial",
                        align: "center"
                    },
                    color: {
                        background: "#0000FF", // dark blue-ish
                        highlight: "#2E2EFE", // light blue
                        hover: "#0101DF" // dark blue
                    },
                },
                edges: {
                    smooth: {
                        type: "dynamic",
                        roundness: 0.6,
                    },
                    hoverWidth: 1.7,
                    arrows: {
                        to: {
                            enabled: true,
                            scaleFactor: 1.5,
                            type: "arrow"
                        },
                        middle: false,
                        from: false
                    },
                    arrowStrikethrough: false,
                    chosen: true,
                    color: {
                        color: "#610B0B", // dark red-ish
                        highlight: "#190707", // dark red
                        hover: "#2A0A0A" // befor dark red, but after dark red-ish
                    },
                    shadow: false,
                },
                interaction: {
                    hover: true,
                    dragNodes: true,
                    dragView: true,
                    multiselect: true,
                    hideEdgesOnDrag: true,
                    hideNodesOnDrag: false,
                    keyboard: false,
                    multiselect: true,
                    navigationButtons: false,
                    zoomView:true
                }
            };

            var network = new vis.Network(container, graphData, parsedData["options"]);
        },
        error: function (xhr, ajaxOptions, thrownError) { alert("Hiba! "+xhr.responseText+ " "+thrownError); },
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