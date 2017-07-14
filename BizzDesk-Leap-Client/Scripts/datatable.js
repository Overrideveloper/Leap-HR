$(document).ready(function () {
    $('#grid').DataTable({
        columnDefs: [
            {
                targets: [0, 1, 2],
                className: 'dataTable'
            }
        ]
    });
});
