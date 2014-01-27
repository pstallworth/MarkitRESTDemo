$(function() {

    var ajaxListRefresh = function () {
        console.log("inside ajaxListRefres");
        var $input = $(this);       
        var options = {
            url: $input.attr("data-submit-url"),
            type: $input.attr("data-submit-method"),
            data: $input.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($input.attr("data-stock-target"));

            $(".data-row").each(function (index, elem) {
                $el = $(this);
                $el.remove();
            })

            $target.append(data);
            //formatChange();
        });

        return false;
    }

    var ajaxAddFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (response_data) {
            var $target = $($form.attr("data-stock-target"));
            //this line below is where we need to insert the row into the table
            //table selector, add row
            
            $target.append(response_data);
            //formatChange();
                        
        });

        return false;
    }

    var ajaxListClear = function () {
        var $input = $(this);
        var options = {
            url: $input.attr("data-submit-url"),
            type: $input.attr("data-submit-method"),
            data: $input.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($input.attr("data-stock-target"));
            $target.replaceWith(data);
        });

        return false;
    }

    var ajaxRemoveRow = function (e) {

        var $span = $(e.target);
        var $col = $span.parent();
        var $row = $col.parent();
        var sym = $col.siblings('.stock-symbol').html();
        var options = {
            url: $span.attr("data-action"),
            type: $span.attr("data-stock-method"),
            data: { "symbol": sym }
        };

        $.ajax(options).done(function (data) {
            if (data === "ok")
                $row.remove();
        });

        return false;

    }

    function formatChange() {
        $(".change").each(function (index, elem) {
            $el = $(this);
            val = $el.text();

            if (isNaN(val))
                return true;

            if (val > 0.0) {
                $el.addClass("num-pos");
            }
            else if (val < 0.0) {
                $el.addClass("num-neg");
            }
            else
                $el.addClass("num-zero");
        });
    }

    $("input[data-submit-action='refresh']").click(ajaxListRefresh);
    /*$("#controls").on("click", "input[data-submit-action='refresh']", ajaxListRefresh);*/
    $("input[data-submit-action='reset']").click(ajaxListClear);
    $("form[data-add-ajax='true']").submit(ajaxAddFormSubmit);
    $("#stockTable").on("click", ".delete-me", ajaxRemoveRow);



 

    
});