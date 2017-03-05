
dataUrl = function (mainPage, action, jobId) {
    $.ajax({
        url: '/' + mainPage + '/' + action,
        type: 'GET',
        data: { id: parseInt(jobId) },
        success: function (result) {
            doModal(result);
        }
    });
};

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

function exportCSV_JobDetails(json) {







    //var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(json));
    var dlAnchorElem = document.getElementById('downloadAnchorElem');
    dlAnchorElem.setAttribute("href", dataStr);
    dlAnchorElem.setAttribute("download", "scene.json");
    dlAnchorElem.click();

}



function JSONToCSVConvertor(JSONData, ReportTitle) {
    //If JSONData is not an object then JSON.parse will parse the JSON string in an Object
    //var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;

    var Purchases = JSONData.Purchases;
    var Job = JSONData.Job;
    var ActiveTasks = JSONData.ActiveTasks;
    var CompletedTasks = JSONData.CompletedTasks;

    var CSV = '';
    
    CSV += objectToString(Job, "Job Details");
    CSV += objectToString(ActiveTasks, "Active Tasks");
    CSV += objectToString(CompletedTasks, "Completed Tasks");
    CSV += objectToString(Purchases, "Purchases");

    if (CSV == '') {
        alert("Invalid data");
        return;
    }

    //Generate a file name
    var fileName = "ExportedJob_";
    //this will remove the blank-spaces from the title and replace it with an underscore
    fileName += ReportTitle.replace(/ /g, "_");

    //Initialize file format you want csv or xls
    var uri = 'data:text/csv;charset=utf-8,' + escape(CSV);   

    //this trick will generate a temp <a /> tag
    var link = document.createElement("a");
    link.href = uri;

    //set the visibility hidden so it will not effect on your web-layout
    link.style = "visibility:hidden";
    link.download = fileName + ".csv";

    //this part will append the anchor tag and remove it after automatic click
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function objectToString(JSONData, ReportTitle) {
    var arrData = [0];
    if(ReportTitle == "Job Details"){
        arrData[0] = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;;
    } else {
        arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;
    }
    var CSV = '';
    
    CSV += '\r\n\n' + ReportTitle + '\r\n\n';

    var row = "";

    //This loop will extract the label from 1st index of on array
    for (var index in arrData[0]) {

        //Now convert each value to string and comma-seprated
        row += index + ',';
    }

    row = row.slice(0, -1);

    //append Label row with line break
    CSV += row + '\r\n';

    //1st loop is to extract each row
    for (var i = 0; i < arrData.length; i++) {
        var row = "";

        //2nd loop will extract each column and convert it in string comma-seprated
        for (var index in arrData[i]) {
            row += '"' + arrData[i][index] + '",';
        }

        row.slice(0, row.length - 1);

        //add a line break after each row
        CSV += row + '\r\n';
    }

    return CSV;
}


// Renderer for descriptions
$.fn.dataTable.render.ellipsis = function () {
    return function (data, type, row) {
        return type === 'display' && data.length > 25 ?
            data.substr(0, 25) + '...' :
            data;
    }
};