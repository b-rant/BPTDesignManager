
dataUrl = function (mainPage, action, jobId) {
    $.ajax({
        url: '/' + mainPage + '/' + action,
        type: 'GET',
        data: { id: parseInt(jobId) },
        success: function (result) {
            doModal(result);
        }
    });
}

function doModal(result) {
    html = '<div id="dynamicModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="confirm-modal" aria-hidden="true">';
    html += '<div class="modal-dialog">';
    html += '<div class="modal-content">';
    html += '<div class="modal-body">';
    html += '<div id = "modal-container">';
    html += '</div>'; //container
    html += '<span style="float: left; margin-bottom: 10px;" class="btn btn-primary" data-dismiss="modal">Close</span>';
    html += '</div>'; //body
    html += '</div>'; //content
    html += '</div>'; //dialog
    html += '</div>'; //modalWindow
    $('body').append(html);
    $("#dynamicModal").modal();
    $('#modal-container').html(result);
    $('#dynamicModal').modal('show');
    $('#dynamicModal').on('hidden.bs.modal', function (e) {
        $(this).remove();
    });

}