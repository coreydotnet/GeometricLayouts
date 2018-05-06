
function getCoordinates() {
    var row = $('#row').val();
    var column = $('#column').val();

    $.get("api/Triangle/Coordinates?row=" + row + "&column=" + column, function (data, status) {
        if (status == "success") {
            $("#v1x").val(data.vertex1.x);
            $("#v1y").val(data.vertex1.y);
            $("#v2x").val(data.vertex2.x);
            $("#v2y").val(data.vertex2.y);
            $("#v3x").val(data.vertex3.x);
            $("#v3y").val(data.vertex3.y);
        }
    });
}

function getCell() {
    var parameters = [
        "v1x=" + $("#v1x").val(),
        "v1y=" + $("#v1y").val(),
        "v2x=" + $("#v2x").val(),
        "v2y=" + $("#v2y").val(),
        "v3x=" + $("#v3x").val(),
        "v3y=" + $("#v3y").val()
    ];
    $.get("api/Triangle/Cell?" + parameters.join("&"), function (data, status) {
        if (status == "success") {
            $("#row").val(String.fromCharCode(data.row + "A".charCodeAt(0) - 1));
            $("#column").val(data.column);
        }
    });
}
