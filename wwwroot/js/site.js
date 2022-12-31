// Oakville December 2022
// Author Hizir Ozcelik

var go = {}; // global object for variables

// document ready
$(document).ready(function () {

    go.mileageArr = []; // keep mileage values for table rows
    go.otherExpenseArr = []; // keep other expense values for table rows
    go.expenseArr = []; // keep expense values for table rows


}); //end of document ready


// checkbox handler for otherExpense table
$(function () {
    $('#otherExpenseCheck').change(function () {

        showOtherExpTable();
    });
});

function showOtherExpTable() {
    $('#toggleExpenseTable').toggle($('#otherExpenseCheck').is(':checked'));
    $('#toggleExpenseTable').removeClass('d-none');
}

// radio selection handlers
$('#mileage').change(function () {

    $('#expenseSelected').addClass("d-none");
    $('#mileageSelected').removeClass("d-none");
});

$('#expense').change(function () {

    $('#mileageSelected').addClass("d-none");
    $('#expenseSelected').removeClass("d-none");

});
