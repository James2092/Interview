$(document).on("click", "#submit", function () {
    var file = $("#fileUpload")[0].files[0];

    var formData = new FormData();

    formData.append("file", file);

    $.ajax({
        type: 'post',
        url: 'https://localhost:44390/Employees',
        data: formData,
        processData: false,
        contentType: false,
        success: function () {
            $("#message").text("Employees successfully uploaded") 
        },
        error: function () {
            $("#message").text("Error uploading employees")
        }
    });
});