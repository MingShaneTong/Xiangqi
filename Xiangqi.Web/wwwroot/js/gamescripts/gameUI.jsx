const domContainer = document.querySelector('#boardContainer');
const root = ReactDOM.createRoot(domContainer);

let selectedCell = null;

function pieceInCell(td) {
	return td.querySelector(".blank-piece") == null;
}

function onBoardClick(table) {
	let td = table.target.closest("td");
	if (td != null) {
		let row = Number(td.getAttribute("data-row"));
		let col = Number(td.getAttribute("data-col"));
		if (pieceInCell(td))
	}
}

function updateBoard(board) {
	root.render(<BoardComponent board={board} />);
}
