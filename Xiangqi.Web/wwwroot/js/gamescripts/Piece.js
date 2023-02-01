class Piece {
	constructor(piece, color) {
		this.piece = piece;
		this.color = color;
	}

	tileClass() {
		return "tile-" + this.color;
	}

	pieceClass() {
		return this.piece.toLowerCase() + "-" + this.color;
	}
}