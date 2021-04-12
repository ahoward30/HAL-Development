    $('#requestForm input[type=checkbox]').on('change', function () {
        var len = $('#requestForm input[type=checkbox]:checked').length;
        if (len > 0) {
            $("#submit").removeAttr('disabled');;
        } else if (len === 0) {
            $("#submit").attr('disabled', true);;
        }
    }).trigger('change');
