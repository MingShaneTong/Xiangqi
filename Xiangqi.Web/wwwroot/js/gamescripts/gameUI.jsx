const domContainer = document.querySelector('#boardContainer');
const root = ReactDOM.createRoot(domContainer);

let gameState = new GameState();
let gameRef = React.createRef();

function updateGameState(gameData) {
	let gameId = gameData["GameId"];
	let turn = gameData["Turn"];
	let playerColor = gameData["Player"];
	let status = gameData["Status"];

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

	gameState.gameId = gameId;
	gameState.turn = turn;
	gameState.playerColor = playerColor;
	gameState.board = board;
	gameState.status = status;
	gameRef.current.updateState(gameState);
}

function endGameState(status) {
	gameState.status = status;
	gameRef.current.updateState(gameState);
}

root.render(<GameComponent ref={gameRef} game={gameState} />);