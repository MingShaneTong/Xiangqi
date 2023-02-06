class Piece {
	constructor(piece, color, availableMoves) {
		this.piece = piece;
		this.color = color;
		this.availableMoves = availableMoves;
	}

	tileClass() {
		return "tile-" + this.color.toLowerCase();
	}

	pieceClass() {
		return this.piece.toLowerCase() + "-" + this.color.toLowerCase();
	}
}