function Delete(url,id) {
    $.ajax({
        url: url + id,
        //data:id,
        type: "POST",
        success: function (data) {
            $("#a_" + id).fadeOut();
        }
    });
}