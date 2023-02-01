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
	updateBoard(parseBoard(msg));
});

connection.on("GameWait", (msg) => {
	updateBoard(parseBoard(msg));
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}