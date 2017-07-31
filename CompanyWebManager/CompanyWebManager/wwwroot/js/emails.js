

function show(id) {
    $(id).removeClass("hidden");
}

function saveEmail($btnObj) {
    console.log($btnObj);
    var $tr = $btnObj.closest('tr');
    var myRow = $tr.index();

    var myObj = { "rowNum": myRow };

    $.ajax({
        url: $tr.data('request-url'),
        type: "POST",
        data:  JSON.stringify(myObj) ,
        contentType: "application/json",
        success: function (result) {
            if (result === true) {
                location.reload();
            }
        }
    });
}