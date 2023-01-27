"use script";

let connection = new signalR.HubConnectionBuilder().withUrl("/chessGameHub").build();

connection.on("AwaitingOpponent", (msg) => {
	console.log("AwaitingOpponent");
});

connection.on("GameCreatedSyn", (msg) => {
	console.log("GameCreatedSyn");
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}