let teames = [];
let connection = null;
let teamIdToUpdate = -1;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:57195/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamCreated", (user, message) => {
        getdata();
    });

    connection.on("TeamDeleted", (user, message) => {
        getdata();
    });
    connection.on("TeamUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:57195/Team')
        .then(x => x.json())
        .then(y => {
            teames = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    teames.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.teamId + "</td><td>"
            + t.teamName + "</td><td>" +
            `<button type="button" onclick="remove(${t.teamId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.teamId})">Update</button>`
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('teamnametoupdate').value = teames.find(t => t['teamId'] == id)['teamName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    teamIdToUpdate = id;
}
function remove(id) {
    fetch('http://localhost:57195/Team/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('teamname').value;
    fetch('http://localhost:57195/Team/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { teamName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('teamnametoupdate').value;
    fetch('http://localhost:57195/Team/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { teamName: name, teamId: teamIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}