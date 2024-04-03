let roles = [];
let connection = null;
let roleIdToUpdate = -1;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:57195/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RoleCreated", (user, message) => {
        getdata();
    });

    connection.on("RoleDeleted", (user, message) => {
        getdata();
    });
    connection.on("RoleUpdated", (user, message) => {
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
    await fetch('http://localhost:57195/Role')
        .then(x => x.json())
        .then(y => {
            roles = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    roles.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.roleId + "</td><td>"
        + t.roleName + "</td><td>" +
        `<button type="button" onclick="remove(${t.roleId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.roleId})">Update</button>`
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('rolenametoupdate').value = roles.find(t => t['roleId'] == id)['roleName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    roleIdToUpdate = id;
}
function remove(id) {
    fetch('http://localhost:57195/Role/' + id, {
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
    let name = document.getElementById('rolename').value;
    fetch('http://localhost:57195/Role/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { roleName: name })
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
    let name = document.getElementById('rolenametoupdate').value;
    fetch('http://localhost:57195/Role/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { roleName: name, roleId: roleIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}