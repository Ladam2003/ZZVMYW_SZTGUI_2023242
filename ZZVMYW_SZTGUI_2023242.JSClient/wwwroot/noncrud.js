document.addEventListener('DOMContentLoaded', function () {
    const submitAvgAge = document.getElementById('submitAvgAge');
    const submitOldestPlayer = document.getElementById('submitOldestPlayer');
    const submitCoachByTeamNationality = document.getElementById('submitCoachByTeamNationality');
    const submitPlayerCount = document.getElementById('submitPlayerCount');
    const submitYoungestPlayer = document.getElementById('submitYoungestPlayer');

    submitAvgAge.addEventListener('click', function () {
        const teamId = document.getElementById('inputAvgAge').value;
        getResult('/NonCrud/getAvgPlayersAgeByTeamId?teamId=' + teamId, 'resultAvgAge');
    });

    submitOldestPlayer.addEventListener('click', function () {
        const teamId = document.getElementById('inputOldestPlayer').value;
        getResult('/NonCrud/getTheOldestPlayerByTeamId?teamId=' + teamId, 'resultOldestPlayer');
    });

    submitCoachByTeamNationality.addEventListener('click', function () {
        const nationality = document.getElementById('inputTeamNationalityForCoach').value;
        getResult('/NonCrud/GetCoachsByTeamNationality?nationality=' + nationality, 'resultCoachNationality');
    });

    submitPlayerCount.addEventListener('click', function () {
        const teamId = document.getElementById('inputPlayerCount').value;
        getResult('/NonCrud/GetPlayersCountByTeamId?teamId=' + teamId, 'resultPlayerCount');
    });

    submitYoungestPlayer.addEventListener('click', function () {
        const teamId = document.getElementById('inputYoungestPlayer').value;
        getResult('/NonCrud/getTheYoungestPlayerByTeamId?teamId=' + teamId, 'resultYoungestPlayer');
    });

    function getResult(url, resultId) {
        fetch('http://localhost:57195' + url)
            .then(response => response.text())
            .then(data => {
                const resultDiv = document.getElementById(resultId);
                resultDiv.innerHTML = `<p>${data}</p>`;
            })
            .catch(error => {
                console.error('Error:', error);
                const resultDiv = document.getElementById(resultId);
                resultDiv.innerHTML = '<p>An error occurred while fetching data</p>';
            });
    }
});
