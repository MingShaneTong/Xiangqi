"use script";

let connection = new signalR.HubConnectionBuilder().withUrl("/chessGameHub").build();
let gameContinue = true;

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

connection.on("PlayerDisconnected", (msg) => {
	console.log("PlayerDisconnected");
	gameContinue = false;
	endGameState("PlayerDisconnected");
});

connection.on("OpponentDisconnected", (msg) => {
	console.log("OpponentDisconnected");
	gameContinue = false;
	endGameState("OpponentDisconnected");
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}

function movePiece(move) {
	if (!gameContinue) {
		return;
	}
	let moveData = JSON.stringify(move);
	connection.invoke("GameMove", moveData);
}