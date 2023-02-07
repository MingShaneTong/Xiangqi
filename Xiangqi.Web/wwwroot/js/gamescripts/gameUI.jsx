const domContainer = document.querySelector('#boardContainer');
const root = ReactDOM.createRoot(domContainer);

root.render(<BoardComponent board={[]} />);

function updateGameState(gameData) {
	let gameId = gameData["GameId"];
	let turn = gameData["Turn"];
	let playerColor = gameData["Player"];

	let board = [];
	for (let r = 0; r < 10; r++) {
		let row = [];
		for (let c = 0; c < 9; c++) {
			row.push(null);
		}
		board.push(row);
	}

	gameData["Board"].forEach(p => {
		let row = p["Position"]["Row"];
		let col = p["Position"]["Col"];

		board[row][col] = new Piece(p["Piece"], p["Color"], p["Moves"]);
	});

	this.setState({
		gameId: gameId,
		turn: turn,
		playerColor: playerColor,
		board: board
	});
}