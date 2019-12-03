function deleteSelected() {
    var confirmDelete = confirm("Are you sure?");
    if (confirmDelete) {
        var idsToDelete = [];
        var checkedCheckboxes = $(":checkbox:checked");
        for (var i = 0; i < checkedCheckboxes.length; i++) {
            idsToDelete.push($(checkedCheckboxes[i]).attr("data-id"));
        };
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "Relation/DeleteRange?ids=" + idsToDelete,
            success: function() {
                window.location.replace("/Relation");
            },
            error: function(data) {
                alert(data.x);
            }
        });
    }
};
