let players = [];
let connection = null;
let playerIdToUpdate = -1;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:57195/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });

    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });
    connection.on("PlayerUpdated", (user, message) => {
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
    await fetch('http://localhost:57195/Player')
        .then(x => x.json())
        .then(y => {
            players = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    players.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.playerId + "</td><td>"
            + t.playerName + "</td><td>" +
            `<button type="button" onclick="remove(${t.playerId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.playerId})">Update</button>`
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('playernametoupdate').value = players.find(t => t['playerId'] == id)['playerName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    playerIdToUpdate = id;
}
function remove(id) {
    fetch('http://localhost:57195/Player/' + id, {
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
    let name = document.getElementById('playername').value;
    fetch('http://localhost:57195/Player/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { playerName: name })
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
    let name = document.getElementById('playernametoupdate').value;
    fetch('http://localhost:57195/Player/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { playerName: name, playerId: playerIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}