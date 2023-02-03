const domContainer = document.querySelector('#boardContainer');
const root = ReactDOM.createRoot(domContainer);

let selectedCell = null;
let turn = null;
let playerColor = null;
let gameId = null;

function pieceInCell(td) {
	return td.querySelector(".blank-piece") == null;
}

function onBoardClick(table) {
	let td = table.target.closest("td");
	if (td != null) {
		let row = Number(td.getAttribute("data-row"));
		let col = Number(td.getAttribute("data-col"));

		if (selectedCell == null) {
			// select piece to move
			if (pieceInCell(td)) {
				selectedCell = td;
			}
		} else {
			if (pieceInCell(td)) {
				// captured a piece
				if (td != selectedCell) {
					
				}
			} else {
				// move piece
			}
		}
	}
}

function updateGame(gameData) {
	gameId = gameData["GameId"];
	turn = gameData["Turn"];
	playerColor = gameData["Player"];

	let board = [];
	for (let r = 0; r < 10; r++) {
		let row = [];
		for (let c = 0; c < 9; c++) {
			row.push(null);
		}
		board.push(row);
	}

	gameData["Board"].forEach(p => {
		board[p["Row"]][p["Col"]] = new Piece(p["Piece"], p["Color"]);
	})

	root.render(<BoardComponent board={board} />);
}
