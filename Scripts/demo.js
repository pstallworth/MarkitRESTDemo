$(function() {

    var ajaxListRefresh = function() {
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

    $("input[data-submit-action='refresh']").click(ajaxListRefresh);
    $("input[data-submit-action='reset']").click(ajaxListClear);
    $("form[data-add-ajax='true']").submit(ajaxAddFormSubmit);

    

    
});