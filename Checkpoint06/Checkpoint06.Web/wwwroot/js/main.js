
//$(document).ready(function () {
    var myList;

    $("#addButton").click(function () {
        var time = $("#time").val();
        var species = $("#species").val();
        var location = $("#location").val();
        var notes = $("#notes").val();

        $.ajax({
            url: "/api/bird/addobservation",
            method: "POST",
            data: {
                time: time,
                species: species,
                location: location,
                notes: notes
            }
        })
        .done(function (result) {
            showSpecies();
            showObservations();
            console.log("Success", result);
        })
        .fail(function (xhr, status, error) {
            alert(`Error! ${xhr.responseText}`);
            console.log("xhr", xhr);
            console.log("status", status);
            console.log("error", error);
        });
    });

    function showSpecies () {

        $.ajax({
            url: "/api/bird/getallspecies",
            method: "GET"
        })
        .done(function (result) {
            myList = result;
            document.getElementById("allSpecies").innerHTML = result;
            console.log("Success", result);
        })
        .fail(function (xhr, status, error) {
            alert(`Error! ${xhr.responseText}`);
            console.log("xhr", xhr);
            console.log("status", status);
            console.log("error", error);
        });
    }

    function showObservations() {

        $.ajax({
                url: "/api/bird/getallobservations",
                method: "GET"
            })
            .done(function (result) {
                myList = result;
                buildHtmlTable("#observationsDataTable");
                console.log("Success", result);
            })
            .fail(function (xhr, status, error) {
                alert(`Error! ${xhr.responseText}`);
                console.log("xhr", xhr);
                console.log("status", status);
                console.log("error", error);
            });
    }



    // Builds the HTML Table out of myList.
    function buildHtmlTable(selector) {
        var columns = addAllColumnHeaders(myList, selector);

        for (var i = 0; i < myList.length; i++) {
            var row$ = $('<tr/>');
            for (var colIndex = 0; colIndex < columns.length; colIndex++) {
                var cellValue = myList[i][columns[colIndex]];
                if (cellValue == null) cellValue = "";
                row$.append($('<td/>').html(cellValue));
            }
            $(selector).append(row$);
        }
    }

    // Adds a header row to the table and returns the set of columns.
    // Need to do union of keys from all records as some records may not contain
    // all records.
    function addAllColumnHeaders(myList, selector) {
        var columnSet = [];
        var headerTr$ = $('<tr/>');

        for (var i = 0; i < myList.length; i++) {
            var rowHash = myList[i];
            for (var key in rowHash) {
                if ($.inArray(key, columnSet) == -1) {
                    columnSet.push(key);
                    headerTr$.append($('<th/>').html(key));
                }
            }
        }
        $(selector).append(headerTr$);

        return columnSet;
    }

//});

