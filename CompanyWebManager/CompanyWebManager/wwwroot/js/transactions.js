$(document).ready(function() {
    autocompleteRow($(".product"));
    $(".units").on("change keyup", function () {
        checkAvailability($(this));
        calculatePrices($(this));
    }); 
});

var autocompleteRow = function(input) {
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
                            return {
                                label: item.label,
                                value: item.label,
                                id: item.id,
                                netprice: item.netprice,
                                grossprice: item.grossprice
                            };
                        }));
                }
            });
        },
        minLength: 4,
        select: function(event, ui) {
            var $row = $input.closest("tr");
            $input.text(ui.item.label);
            $row.find(".productID").val(ui.item.id);
            $row.find(".unitNetPrice").val(ui.item.netprice);
            $row.find(".unitGrossPrice").val(ui.item.grossprice);
        }
    });
};

function cloneRow() {
    var $tr = $("#tableProducts tr:last");
    var $clone = $tr.clone();
    $clone.find(':text').val('');
    $clone.find(':input').val('');
    $tr.after($clone);

    autocompleteRow($clone.find(".product"));

    $clone.find(".units").on("change keyup", function () {
        checkAvailability($(this));
        calculatePrices($(this));
    });
}

function saveTransaction() {
    var tableData = new Array();  

    $("#tableProducts  tr").not(':first').each(function() {
        var tmpData =
        {
            "ID": $(this).find(".productID").val(),
            "NetPrice": $(this).find(".unitNetPrice").val(),
            "GrossPrice": $(this).find(".unitGrossPrice").val(),
            "Units": $(this).find(".units").val()
        };

        tableData.push(tmpData);
    });

    var transaction = { "Type": $("#type").val(), "Description": $("#descripion").val(), "Products": tableData };

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

function calculatePrices($input) {
    var units = $input.val();
    var $row = $input.closest("tr");
    var netPrice = $row.find(".unitNetPrice").val();
    var grossPrice = $row.find(".unitGrossPrice").val();

    $row.find(".netPrice").val(units * netPrice);
    $row.find(".grossPrice").val(units * grossPrice);
}

function checkAvailability($input) {
    if ($("#type").val() !== "2") {
        return false;
    }

    var units = $input.val();
    var $row = $input.closest("tr");
    var productID = $row.find(".productID").val();

    var data = { "productId": productID, "units": units };

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        url: $input.data('request-url'),
        type: "POST",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (data) {
            console.log(data);
            console.log(data.message + " =message");

            if (data.message !== "available") {
                alert("nie ma tyle produktow! mozesz uzyc tylko " + data.maxAvaiability);
                $input.val(data.maxAvaiability);
                calculatePrices($input);
            }
        },
        error: function () {
            alert("Blad, sprobuj ponownie");
        }
    });
}