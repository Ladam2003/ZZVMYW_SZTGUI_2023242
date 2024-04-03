let coaches = [];
let connection = null;
let coachIdToUpdate = -1;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:57195/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CoachCreated", (user, message) => {
        getdata();
    });

    connection.on("CoachDeleted", (user, message) => {
        getdata();
    });
    connection.on("CoachUpdated", (user, message) => {
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
    await fetch('http://localhost:57195/Coach')
        .then(x => x.json())
        .then(y => {
            coaches = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    coaches.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.coachId + "</td><td>"
        + t.coachName + "</td><td>" +
        `<button type="button" onclick="remove(${t.coachId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.coachId})">Update</button>`
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('coachnametoupdate').value = coaches.find(t => t['coachId'] == id)['coachName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    coachIdToUpdate = id;
}
function remove(id) {
    fetch('http://localhost:57195/Coach/' + id, {
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
    let name = document.getElementById('coachname').value;
    fetch('http://localhost:57195/Coach/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { coachName: name })
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
    let name = document.getElementById('coachnametoupdate').value;
    fetch('http://localhost:57195/Coach/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { coachName: name, coachId: coachIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}