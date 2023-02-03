"use script";

let connection = new signalR.HubConnectionBuilder().withUrl("/chessGameHub").build();

connection.on("AwaitingOpponent", (msg) => {
	console.log("AwaitingOpponent");
});

connection.on("GameCreatedSyn", (msg) => {
	let gameId = msg;
	connection.invoke("GameCreatedAck", gameId);
});

connection.on("GamePlay", (msg) => {
	let gameData = JSON.parse(msg);
	updateGame(gameData);
});

connection.on("GameWait", (msg) => {
	let gameData = JSON.parse(msg);
	updateGame(gameData);
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}