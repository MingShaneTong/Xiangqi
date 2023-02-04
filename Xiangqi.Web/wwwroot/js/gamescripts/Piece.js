class Piece {
	constructor(piece, color) {
		this.piece = piece;
		this.color = color;
	}

	tileClass() {
		return "tile-" + this.color.toLowerCase();
	}

	pieceClass() {
		return this.piece.toLowerCase() + "-" + this.color.toLowerCase();
	}
}