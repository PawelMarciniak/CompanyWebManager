$(document).ready(function() {
    autocompleteRow($(".product"));
});

var autocompleteRow = function (input) {
    var $input = $(input);
    $input.autocomplete({
        source: function(request, response) {
            $.ajax({
                url: $input.data('request-url'),
                type: "GET",
                dataType: "json",
                data: { name: request.term },

                success: function(data) {
                    response($.map(data,
                        function(item) {
                            return { label: item.label, value: item.label, id: item.id, netprice: item.netprice, grossprice: item.grossprice };
                        }));
                }
            });
        },
        minLength: 4,
        select: function (event, ui) {
            var $row = $input.closest("tr");
            $input.text(ui.item.label);
            $row.find(".productID").val(ui.item.id);
            $row.find(".netPrice").val(ui.item.netprice);
            $row.find(".grossPrice").val(ui.item.grossprice);
        }
    });
}

function cloneRow() {
    var $tr = $("#tableProducts tr:last");
    var $clone = $tr.clone();
    $clone.find(':text').val('');
    $clone.find(':input').val('');
    $tr.after($clone);

    autocompleteRow($clone.find(".product"));
}

function saveTransaction() {
    var tableData = new Array();  

    $("#tableProducts  tr").not(':first').each(function() {
        var tmpData =
        {
            "ID": $(this).find(".productID").val(),
            "NetPrice": $(this).find(".netPrice").val(),
            "GrossPrice": $(this).find(".grossPrice").val(),
            "Units": $(this).find(".units").val()
        }

        tableData.push(tmpData);
    });

    var transaction = { "Type": $("#type").val(), "Description": $("#descripion").val(), "Products": tableData}


    $.ajax({
        contentType: 'application/json; charset=utf-8',
        url: $("#tableProducts").data('request-url'),
        type: "POST",
        dataType: "json",
        data: JSON.stringify(transaction),
        success: function (data) {

        },
        error: function() {
            alert("Blad, sprobuj ponownie");
        }
    });


}