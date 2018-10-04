

$(window).load(function () {
    app.ui.ResetReadOnlyControlBackgroundColor();
});


function grid_cell_prepared(e) {
    //if (e.rowType === "data" && e.column.command === "edit") {
    //    var isEditing = e.row.isEditing,
    //        $links = e.cellElement.find(".dx-link");

    //    $links.text("");

    //    if (isEditing) {
    //        $links.filter(".dx-link-save").addClass("dx-icon-save");
    //        $links.filter(".dx-link-cancel").addClass("dx-icon-revert");
    //    } else {
    //        $links.filter(".dx-link-edit").addClass("dx-icon-edit");
    //        $links.filter(".dx-link-delete").addClass("dx-icon-trash");
    //    }
    //}
}

var app = {
    ui: {
        handleAjaxSuccess: function (data, status, xhr) {
                var message = data.message !== undefined ? data.message : "Data request is successfully.";
                return message;
        },
        handleAjaxError: function (xhr, status, error) {
                var message = xhr.responseJSON !== undefined && xhr.responseJSON.message !== undefined ? xhr.responseJSON.message : "Internal Server Error";
                return message;
        },
        showErrorMessagePanel: function (message) {
            $("#page-validation-summary").show().html(message);
        },
        hideMessagePanel: function () {
            $("#page-validation-summary").hide();
            $("#page-success-summary").hide();
        },
        showSuccessMessagePanel: function (message) {
            $("#page-success-summary").show().html(message);
        },
        clearValidateIcon: function()
        {
            $('.dx-invalid').each(function (idx) {
                $(this).removeClass('dx-invalid');
            });
        },
        ResetReadOnlyControlBackgroundColor: function()
        {
            $(".readonly-background-color").removeClass("readonly-background-color");
            $(".dx-state-readonly .dx-texteditor-container .dx-texteditor-input").addClass("readonly-background-color");

            $(".dx-fileuploader-input-wrapper .dx-fileuploader-button").removeClass("dx-button-normal");
            $(".dx-fileuploader-input-wrapper .dx-fileuploader-button").addClass("dx-button-success");
        },
        getLoadPanelInstance: function() {
            return $("#load-panel-global").dxLoadPanel("instance");
        },
        showNotifyMessage: function (type, message) {
            var toastmessage = $("#toastmessage_" + type.toLowerCase()).dxToast("instance");
            if (toastmessage != null) {
                toastmessage._options.message = message;
                toastmessage.show();
            }
        },
        detectIE: function() {
            var ua = window.navigator.userAgent;

            // Test values; Uncomment to check result …

            // IE 10
            // ua = 'Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)';
  
            // IE 11
            // ua = 'Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko';
  
            // Edge 12 (Spartan)
            // ua = 'Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36 Edge/12.0';
  
            // Edge 13
            // ua = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586';

            var msie = ua.indexOf('MSIE ');
            if (msie > 0) {
                // IE 10 or older => return version number
                return parseInt(ua.substring(msie + 5, ua.indexOf('.', msie)), 10);
            }

            var trident = ua.indexOf('Trident/');
            if (trident > 0) {
                // IE 11 => return version number
                var rv = ua.indexOf('rv:');
                return parseInt(ua.substring(rv + 3, ua.indexOf('.', rv)), 10);
            }

            var edge = ua.indexOf('Edge/');
            if (edge > 0) {
                // Edge (IE 12+) => return version number
                return parseInt(ua.substring(edge + 5, ua.indexOf('.', edge)), 10);
            }

            // other browser
            return false;
        },
        AddBackgroundColorPopupButton: function(){
            $('.dx-button-normal:contains("Save")').addClass('dx-button-success');
            $('.dx-button-normal:contains("Cancel")').addClass('dx-button-danger')
        }
    },
    addAntiForgeryToken: function (data) {
        //if the object is undefined, create a new one.
        if (!data) {
            data = {};
        }
        //add token
        var tokenInput = $('input[name=__RequestVerificationToken]');
        if (tokenInput.length) {
            data.__RequestVerificationToken = tokenInput.val();
        }
        return data;
    }
}