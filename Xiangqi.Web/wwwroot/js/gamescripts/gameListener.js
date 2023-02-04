"use script";

let connection = new signalR.HubConnectionBuilder().withUrl("/chessGameHub").build();

connection.on("AwaitingOpponent", (msg) => {
	console.log("AwaitingOpponent");
});

connection.on("GameCreatedSyn", (msg) => {
	console.log("GameCreatedSyn");
	let gameId = msg;
	connection.invoke("GameCreatedAck", gameId);
});

connection.on("GamePlay", (msg) => {
	console.log("GamePlay");
	let gameData = JSON.parse(msg);
	updateGame(gameData);
});

connection.on("GameWait", (msg) => {
	console.log("GameWait");
	let gameData = JSON.parse(msg);
	updateGame(gameData);
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}

function movePiece(move) {
	connection.invoke("GameMove", move);
}