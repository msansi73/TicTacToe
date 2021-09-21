var connection;
var moveButtons = document.getElementsByClassName("move-button");
connect();

connection.start().then(() =>
{
    for (var i = 0; i < moveButtons.length; i++) moveButtons[i].disabled = false;
    join();
    onJoinMessage();
    onMove();
    onWin();
    onDraw();
}).catch(err => console.error(err.toString()));

function connect()
{
    connection = new signalR.HubConnectionBuilder().withUrl("/roomHub").build();
    for (var i = 0; i < moveButtons.length; i++) moveButtons[i].disabled = true;
    console.log("Connected");
}

function join() {
    connection.invoke("JoinMessage", username, playerNumber, roomId)
        .catch(err => console.error(err.toString()));
}

function onJoinMessage()
{
    connection.on("JoinMessage", (username, playerNumber, roomId) => {
        document.getElementById("player-name-" + playerNumber).innerText = username;
    });
}

function move(x, y)
{
    connection.invoke("Move", roomId, turnPiece, x, y)
        .catch(err => console.error(err.toString()));
}

function onMove()
{
    connection.on("Move", (roomId, turnPiece, x, y) => {
        console.log(`move-button-${x}-${y}`);
        document.getElementById(`move-button-${x}-${y}`).innerText = turnPiece == 1 ? 'X' : 'O';
        this.turnPiece = this.turnPiece == 1 ? 2 : 1;
        console.log(this.turnPiece);
    });
}

function onWin() {
    connection.on("Win", (playerNumber) => {
        var alertContainer = document.getElementById("alert-container");
        var alert = document.createElement("div");
        alert.classList.add("alert");
        alert.classList.add("alert-warning");
        alert.role = "alert";
        alertContainer.appendChild(alert);
        alert.innerText = `${document.getElementById("player-name-" + playerNumber).innerText} ha vinto!`;
    });
}

function onDraw() {
    connection.on("Draw", () => {
        var alertContainer = document.getElementById("alert-container");
        var alert = document.createElement("div");
        alert.classList.add("alert");
        alert.classList.add("alert-warning");
        alert.role = "alert";
        alertContainer.appendChild(alert);
        alert.innerText = "È un pareggio!";
    });
}