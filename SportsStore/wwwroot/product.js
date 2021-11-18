var dataTables = $("#dataTable");

$(document).ready(function () {
    dataTables.DataTable();
    console.log("Into product.js...");

    var toastElement = document.querySelectorAll('.toast');
    for (let i = 0; i < toastElement.length; i++) {
        new bootstrap.Toast(toastElement[i]).show();
        console.log(i);
    }
    console.log("Javascript for Bootstrap not logged...");
})
