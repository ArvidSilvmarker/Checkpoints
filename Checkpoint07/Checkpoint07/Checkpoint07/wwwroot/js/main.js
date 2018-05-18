function onLoad() {
    newPerson();
}


function newPerson() {
    $.ajax({
            url: "/api/person/",
            method: "POST"
        })
        .done(function (result) {
            console.log(result);
            showPersons();
        })
        .fail(function (xhr, status, error) {
            alert(`Error! ${xhr.responseText}`);
            console.log("xhr", xhr);
            console.log("status", status);
            console.log("error", error);
        });
}

function showPersons() {

    $.ajax({
            url: "/api/person/",
            method: "GET"
        })
        .done(function (result) {
            console.log(result);
            $("#text").html(result);
        })
        .fail(function (xhr, status, error) {
            alert(`Error! ${xhr.responseText}`);
            console.log("xhr", xhr);
            console.log("status", status);
            console.log("error", error);
        });
}