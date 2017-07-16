$(document).ready(function () {
    $('#grid').DataTable({
        columnDefs: [
            {
                targets: [0, 1, 2, 3, 4, 5, 6, 7, 8],
                className: 'dataTable'
            }
        ]
    });
});
