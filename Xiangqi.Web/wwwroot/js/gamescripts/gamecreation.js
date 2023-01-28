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
	console.log("GamePlay");
	console.log(msg);
});

connection.on("GameWait", (msg) => {
	console.log("GameWait");
	console.log(msg);
});

connection.start();

function joinGame() {
	connection.invoke("JoinGame");
}