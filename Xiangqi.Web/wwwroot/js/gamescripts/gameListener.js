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

connection.on("GameState", (msg) => {
	console.log("GameState");
	let gameData = JSON.parse(msg);
	updateGameState(gameData);
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}

function movePiece(move) {
	let moveData = JSON.stringify(move);
	connection.invoke("GameMove", moveData);
}