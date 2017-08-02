

function show(id) {
    $(id).removeClass("hidden");
}

function sendRequestToController($btnObj) {
    console.log($btnObj);
    var $tr = $btnObj.closest('tr');
    var myRow = $tr.index();

    console.log(myRow);

    var myObj = { "rowNum": myRow, "saved" : true };

    $.ajax({
        url: $btnObj.data('request-url'),
        type: "GET",
        data:  myObj ,
        //contentType: "application/json",
        success: function (result) {
            if (result === true) {
                location.reload();
            }
        }
    });
}