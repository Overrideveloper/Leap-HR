$(function () {
    $('.delete').on('click', function (e) {
        
        var self = this;

        bootbox.confirm({
            className: 'modal-primary',
            message: "Are you sure to delete this?",
            buttons: {
                confirm: {
                    label: 'Delete',
                    className: 'btn-danger'
                },

                cancel: {
                    label: 'Close',
                    className: 'btn-outline pull-left' 
                }

            },
            callback: function () {
                console.log("User confirmed");
            }
        });
        e.preventDefault();
    });
});
