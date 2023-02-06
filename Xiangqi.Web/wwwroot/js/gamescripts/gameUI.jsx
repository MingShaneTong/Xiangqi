const domContainer = document.querySelector('#boardContainer');
const root = ReactDOM.createRoot(domContainer);

let selected = {
	row: null,
	col: null,
	piece: null
};
let turn = null;
let playerColor = null;
let gameId = null;
let board = null;

function pieceInCell(td) {
	return td.querySelector(".blank-piece") == null;
}

function onBoardClick(table) {
	let td = table.target.closest("td");
	if (td == null) { return; }

	let row = Number(td.getAttribute("data-row"));
	let col = Number(td.getAttribute("data-col"));

	let clicked = {
		row: row,
		col: col,
		piece: board[row][col]
	};

	console.log(selected);
	console.log(clicked);

	if (selected.piece != null && selected.piece.color == playerColor) {
		// check if can move
		if (clicked.piece == null || clicked.piece.color != playerColor) {
			// TODO check if in valid moves
			let move = {
				GameId: gameId,
				OldPosition: {
					Row: selected.row,
					Col: selected.col
				},
				NewPosition: {
					Row: clicked.row,
					Col: clicked.col
				}
			};
			movePiece(move);
		}
	}
	selected = clicked;
}

function updateGame(gameData) {
	gameId = gameData["GameId"];
	turn = gameData["Turn"];
	playerColor = gameData["Player"];

	let b = [];
	for (let r = 0; r < 10; r++) {
		let row = [];
		for (let c = 0; c < 9; c++) {
			row.push(null);
		}
		b.push(row);
	}

	gameData["Board"].forEach(p => {
		let row = p["Position"]["Row"];
		let col = p["Position"]["Col"];

		b[row][col] = new Piece(p["Piece"], p["Color"], p["Moves"]);
	})

	board = b;

	root.render(<BoardComponent board={board} />);
}

function updateSelected(row, col) {

}