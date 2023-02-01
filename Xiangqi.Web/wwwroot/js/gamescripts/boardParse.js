function parsePieceString(pieceString) {
	let color, piece, rest;
	[color, piece, ...rest] = pieceString.split(" ");

	return new Piece(piece.trim(), color.trim());
}

function parsePositionString(positionString) {
	let row = parseInt(positionString.charAt(1));
	let col = parseInt(positionString.charAt(3));
	return [row, col];
}

function parseBoard(boardString) {
	let board = [];
	for (let r = 0; r < 10; r++) {
		let row = [];
		for (let c = 0; c < 9; c++) {
			row.push(null);
		}
		board.push(row);
	}

	let lineNum = 0;
	let lines = boardString.split("\n").filter(i => i != "");
	while (lines.length > lineNum) {
		let piece = parsePieceString(lines[lineNum++]);
		let [row, col] = parsePositionString(lines[lineNum++]);
		board[row][col] = piece;
		lineNum++;
	}
	return board;
}