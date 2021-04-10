
$('#formSubmitButton').prop("disabled", true);
$('input:checkbox').click(function () {
    if ($(this).is(':checked')) {
        $('#formSubmitButton').prop("disabled", false);
    } else {
        if ($('.cbox').filter(':checked').length < 1) {
            $('#formSubmitButton').attr('disabled', true);
        }
    }
});