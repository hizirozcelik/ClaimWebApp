// Oakville Jan 2023
// Claim request web app v2
// Author Hizir Ozcelik

var go = {}; // global object for variables

// document ready
$(document).ready(function () {

    go.mileageArr = []; // keep mileage values for table rows
    go.otherExpenseArr = []; // keep other expense values for table rows
    go.expenseArr = []; // keep expense values for table rows

    // Updating arrays and values from view
    getMileageDataFromTable(); // this function working properly
    console.log("new mileageArr document ready", go.mileageArr);

    getOtherExpenseDataFromTable(); // this function working properly
    console.log("new mileageArr document ready", go.otherExpenseArr);

    getExpenseDataFromTable(); // DEBUG this function is not working after saved or submit.
    console.log("new mileageArr document ready", go.expenseArr);


}); //end of document ready

// get values from data table if availble on the page. Refresh the expenseArr and TotalAmount value.
function getExpenseDataFromTable() {
    var rowNum = $('#BodyExpenseRowEntry tr').length;

    console.log("Expense table rows = ", rowNum);

    if (rowNum != undefined) {
        for (let i = 0; i < rowNum; i++) {

            var expenseData = $(setIdStr("idAmount", i)).val();
            go.expenseArr.push(expenseData);
        }
        console.log("new expenseArr ", go.expenseArr);
        go.expenseTotal = Number($("#idTotalExpenses").val());
    }
    formatCell('#idTotalExpenses', go.expenseTotal);
}


// get values from data table if available on the page. Refresh the mileageArr and totalMileage value.
function getMileageDataFromTable() {
    var rowNum = $('#BodyMileageRowEntry tr').length;

    console.log("Mileage table rows = ", rowNum);

    if (rowNum != undefined) { // 
        for (let i = 0; i < rowNum; i++) {

            var mileageData = $(setIdStr("idDistance", i)).val();
            go.mileageArr.push(mileageData);
        }
        console.log("new mileageArr ", go.mileageArr);
        go.totalMileage = Number($("#idTotalMileage").val());
    }
    formatCell("#idTotalMileage", go.totalMileage);
}

//get values from data table if availble on the page. Refresh the otherExpArr and totalOtherExpense value.
function getOtherExpenseDataFromTable() {
    var rowNum = $('#BodyOtherExpRowEntry tr').length;

    console.log("Other Expense table rows = ", rowNum);

    if (rowNum != undefined) {
        for (let i = 0; i < rowNum; i++) {

            var otherExpenseData = $(setIdStr("idCost", i)).val();
            go.otherExpenseArr.push(otherExpenseData);
        }
        
        go.otherExpenseTotal = Number($("#idTotalOtherExpenses").val());
    }
    formatCell('#idTotalOtherExpenses', go.otherExpenseTotal);
}

function setIdStr(id, row) {
    return "#" + id + row;
}

// common function for all table total amount calculation and formatting
function formatCell(id, cellValue) {
    const format = (num, decimals) => num.toLocaleString('en-US', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
    });
    $(id).val(format(cellValue).toString());
}

function setRowVal(iRow, objName) {
    var rowValCell = setIdStr(objName, iRow);
    var temp = $(rowValCell).val();

    if (objName == "idDistance") {
        console.log("setting row value for ", objName);

        if (Number(temp) != Number(go.mileageArr[iRow])) {
            // re-calculate total mileage
            go.totalMileage = go.totalMileage - Number(go.mileageArr[iRow]) + Number(temp);
            // update mileage array
            go.mileageArr[iRow] = temp;
            // update TotalMileage field
            formatCell("#idTotalMileage", go.totalMileage);
        }
    }

    if (objName == "idCost") {

        console.log("setting row value for and value", objName);

        if (Number(temp) != Number(go.otherExpenseArr[iRow])) {
            // re-calculate other expenses total
            go.otherExpenseTotal = go.otherExpenseTotal - Number(go.otherExpenseArr[iRow]) + Number(temp);
            // update other expense array
            go.otherExpenseArr[iRow] = temp;
            // update TotalOtherExpenses field
            formatCell('#idTotalOtherExpenses', go.otherExpenseTotal);
        }
    }

    if (objName == "idAmount") {

        console.log("setting row value for ", objName);
        if (Number(temp) != Number(go.expenseArr[iRow])) {
            // re-calculate total expense
            go.expenseTotal = go.expenseTotal - Number(go.expenseArr[iRow]) + Number(temp);
            // update expense array
            go.expenseArr[iRow] = temp;
            // update totalamount field
            formatCell('#idTotalExpenses', go.expenseTotal);
        }
    }
}//end setRowVal

// add row function for Expense data table
$('#add-row-expense').click(() => {

    var rowIndex = $('#BodyExpenseRowEntry tr').length;

    var newRow = "<tr id='trExpense##PlaceHolder##'>";
    newRow = newRow + "<td hidden><input name='ExpenseClaims[##PlaceHolder##].Id'  class='form-control form-control-sm border-secondary' /></td>";
    newRow = newRow + "<td hidden><input name='ExpenseClaims[##PlaceHolder##].ClaimRequestId'  class='form-control form-control-sm border-secondary' /></td>";
    newRow = newRow + "<td><input id='idExpenseDescription##PlaceHolder##' name='ExpenseClaims[##PlaceHolder##].ExpenseDescription'  class='form-control form-control-sm border-secondary' type='text' data-val='true' data-val-required='The From Where field is required.' value='' required/></td >";
    newRow = newRow + "<td><input id='AccountNumber##PlaceHolder##' name='ExpenseClaims[##PlaceHolder##].AccountNumber'  class='form-control form-control-sm border-secondary' type='text' data-val='true' data-val-required='The From Where field is required.' value='' required /></td >";
    newRow = newRow + "<td><input id='idAmount##PlaceHolder##' name = 'ExpenseClaims[##PlaceHolder##].Amount'  class='form-control form-control-sm text-end border-secondary currency amount' onchange=\"setRowVal(##PlaceHolder##, 'idAmount'); \"  data-format-auto-parse='true' data-format-max-decimal='2' data-format='Currency' type='text' data-val='true' data-val-number='The field Distance must be a number.' data-val-required='The Distance field is required.' value='0.00' required/></td>";
    newRow = newRow + "<td colspan='2'></td>";
    newRow = newRow + "</tr>";
    //
    var strRow = newRow.replace(/##PlaceHolder##/g, rowIndex);

    var amountVal = $(setIdStr("idAmount", (rowIndex - 1).toString())).val();

    console.log("Before add row ", go.expenseArr);

    // don't add new row if mileage value is zero. Need notification to the user
    if (amountVal != 0) {
        // clicking the add button while cell value changed and still onfocus state
        // update required fields and variables before add new row 
        if (go.expenseArr[rowIndex - 1] != amountVal) {

            console.log("cell val changed before add ", go.expenseArr);

            // re-calculate total mileage
            go.expenseTotal = go.expenseTotal - Number(go.expenseArr[rowIndex - 1]) + Number(amountVal);
            // update mileage array
            go.expenseArr.push(amountVal);

        }
        // add new row and update fields and values

        $("#BodyExpenseRowEntry").append(strRow);
        // add new element to mileage array
        go.expenseArr.push(0);

        console.log("after add row ", go.expenseArr);

    }
});
// remove last row from mileage data table
$('#remove-row-expense').click(() => {

    var rowIndex = $('#BodyExpenseRowEntry tr').length;

    // remove last row | update expense array
    if (rowIndex > 1) {
        rowIndex = rowIndex - 1;

        console.log("before remove row ", go.expenseArr);

        // remove last item from mileage array and re calculate TotalMileage
        var cellVal = go.expenseArr.pop();
        go.expenseTotal = go.expenseTotal - Number(cellVal);
        var thisRow = setIdStr("trExpense", rowIndex);
        $(thisRow).remove();

        console.log("after remove row", go.expenseArr);

        formatCell('#idTotalExpenses', go.expenseTotal);
    }
});// end removeRowFromMileage


// add row function for other expense data table
$('#add-row-otherExpense').click(() => {

    var rowIndex = $('#BodyOtherExpRowEntry tr').length;

    var newRow = "<tr id='trOtherExp##PlaceHolder##'>";
    newRow = newRow + "<td hidden><input name='OtherExpenseClaims[##PlaceHolder##].Id'  class='form-control form-control-sm border-secondary' /></td>";
    newRow = newRow + "<td hidden><input name='OtherExpenseClaims[##PlaceHolder##].ClaimRequestId'  class='form-control form-control-sm border-secondary' /></td>";    
    newRow = newRow + "<td><input id='idType##PlaceHolder##' name='OtherExpenseClaims[##PlaceHolder##].Type'  class='form-control form-control-sm border-secondary' type='text' data-val='true' data-val-required='The From Where field is required.' value='' required/></td >";
    newRow = newRow + "<td><input id ='idCost##PlaceHolder##' name = 'OtherExpenseClaims[##PlaceHolder##].Cost'  class='form-control form-control-sm text-end border-secondary currency cost' onchange=\"setRowVal(##PlaceHolder##, 'idCost'); \"  data-format-auto-parse='true' data-format-max-decimal='2' data-format='Currency' type='text' data-val='true' data-val-number='The field Distance must be a number.' data-val-required='The Distance field is required.' value='0.00' required/></td>";
    newRow = newRow + "<td colspan='2'></td>";
    newRow = newRow + "</tr>";
    //
    var strRow = newRow.replace(/##PlaceHolder##/g, rowIndex);

    var costVal = $(setIdStr("idCost", (rowIndex - 1).toString())).val();

    console.log("Before add row ", go.otherExpenseArr);

    // don't add new row if other expense value is zero.
    if (costVal != 0) {
        // clicking the add button while cell value changed and still onfocus state
        // update required fields and variables before add new row 
        if (go.otherExpenseArr[rowIndex - 1] != costVal) {

            console.log("cell val changed before add ", go.otherExpenseArr);

            // re-calculate total mileage
            go.otherExpenseTotal = go.otherExpenseTotal - Number(go.otherExpenseArr[rowIndex - 1]) + Number(costVal);
            // update mileage array
            go.otherExpenseArr.push(costVal);

        }
        // add new row and update fields and values

        $("#BodyOtherExpRowEntry").append(strRow);
        // add new element to mileage array
        go.otherExpenseArr.push(0);

        console.log("after add row ", go.otherExpenseArr);

    }
});

// remove last row from mileage data table
$('#remove-row-otherExpense').click(() => {

    var rowIndex = $('#BodyOtherExpRowEntry tr').length;

    // remove last row | update mileage array
    if (rowIndex > 1) {
        rowIndex = rowIndex - 1;

        console.log("before remove row ", go.otherExpenseArr);

        // remove last item from mileage array and re calculate TotalMileage
        var cellVal = go.otherExpenseArr.pop();
        go.otherExpenseTotal = go.otherExpenseTotal - Number(cellVal);
        var thisRow = setIdStr("trOtherExp", rowIndex);
        $(thisRow).remove();

        console.log("after remove row", go.otherExpenseArr);

        formatCell('#idTotalOtherExpenses', go.otherExpenseTotal);

    }

});// end removeRowFromMileage


// add row function for mileage data table
$('#add-row-mileage').click(() => {

    var rowIndex = $('#BodyMileageRowEntry tr').length;

    var newRow = "<tr id='trMileage##PlaceHolder##'>";
    newRow = newRow + "<td hidden><input name='MileageClaims[##PlaceHolder##].Id'  class='form-control form-control-sm border-secondary' /></td>";
    newRow = newRow + "<td hidden><input name='MileageClaims[##PlaceHolder##].ClaimRequestId'  class='form-control form-control-sm border-secondary' /></td>";
    newRow = newRow + "<td><input id='idTripDate##PlaceHolder##' name='MileageClaims[##PlaceHolder##].TripDate'  class='form-control form-control-sm border-secondary' type='date' data-val='true' data-val-required='The Trip Date field is required.' required/></td>";
    newRow = newRow + "<td><input id='idFromWhere##PlaceHolder##' name='MileageClaims[##PlaceHolder##].FromWhere'  class='form-control form-control-sm border-secondary' type='text' data-val='true' data-val-required='The From Where field is required.' value='' required/></td >";
    newRow = newRow + "<td><input id='idDestination##PlaceHolder##' name='MileageClaims[##PlaceHolder##].Destination'  class='form-control form-control-sm border-secondary' type='text' data-val='true' data-val-required='The From Where field is required.' value='' required/></td >";
    newRow = newRow + "<td><input id ='idDistance##PlaceHolder##' name = 'MileageClaims[##PlaceHolder##].Distance'  class='form-control form-control-sm text-end border-secondary currency distance' onchange=\"setRowVal(##PlaceHolder##, 'idDistance'); \"  data-format-auto-parse='true' data-format-max-decimal='2' data-format='Currency' type='text' data-val='true' data-val-number='The field Distance must be a number.' data-val-required='The Distance field is required.' value='0.00' required/></td>";
    newRow = newRow + "<td colspan='2'></td>";
    newRow = newRow + "</tr>";
    //
    var strRow = newRow.replace(/##PlaceHolder##/g, rowIndex);

    var distanceVal = $(setIdStr("idDistance", (rowIndex - 1).toString())).val();

    console.log("Before add row ", go.mileageArr);

    // don't add new row if mileage value is zero. Need notification to the user
    if (distanceVal != 0) {
        // clicking the add button while cell value changed and still onfocus state
        // update required fields and variables before add new row 
        if (go.mileageArr[rowIndex - 1] != distanceVal) {

            console.log("cell val changed before add ", go.mileageArr);

            // re-calculate total mileage
            go.totalMileage = go.totalMileage - Number(go.mileageArr[rowIndex - 1]) + Number(distanceVal);
            // update mileage array
            go.mileageArr.push(distanceVal);

        }
        // add new row and update fields and values

        $("#BodyMileageRowEntry").append(strRow);
        // add new element to mileage array
        go.mileageArr.push(0);

        console.log("after add row ", go.mileageArr);

    }
});

// remove last row from mileage data table
$('#remove-row-mileage').click(() => {

    var rowIndex = $('#BodyMileageRowEntry tr').length;

    // remove last row | update mileage array
    if (rowIndex > 1) {
        rowIndex = rowIndex - 1;

        console.log("before remove row ", go.mileageArr);

        // remove last item from mileage array and re calculate TotalMileage
        var cellVal = go.mileageArr.pop();
        go.totalMileage = go.totalMileage - Number(cellVal);
        var thisRow = setIdStr("trMileage", rowIndex);
        $(thisRow).remove();

        console.log("after remove row", go.mileageArr);

        formatCell('#idTotalMileage', go.totalMileage);

    }

});// end removeRowFromMileage


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
