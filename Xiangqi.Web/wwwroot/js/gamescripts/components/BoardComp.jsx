let updateGame;

function isAvailableMove(availableMoves, row, col) {
	let moves = availableMoves.filter(m =>
		m["Row"] == row && m["Col"] == col
	);
	let isMove = moves.length > 0;
	return isMove;
}

class BoardComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			board: props.board,
			selected: {
				row: null,
				col: null,
				piece: null
			},
			moves: [],
			turn: props.turn,
			playerColor: props.playerColor,
			gameId: props.gameId
		};
		updateGame = updateGameState.bind(this);
	}

	onCellClick(row, col) {
		let clicked = {
			row: row,
			col: col,
			piece: this.state.board[row][col]
		};

		let selectedPiece = this.state.selected.piece;
		let clickedPiece = clicked.piece;

		if (selectedPiece != null && selectedPiece.color == this.state.playerColor) {
			// check if can move
			if (clickedPiece == null || clickedPiece.color != this.state.playerColor) {
				// check if in valid moves
				let isMove = isAvailableMove(this.state.moves, row, col);
				if (isMove) {
					console.log("Moving Piece");
					let move = {
						GameId: this.state.gameId,
						OldPosition: {
							Row: this.state.selected.row,
							Col: this.state.selected.col
						},
						NewPosition: {
							Row: row,
							Col: col
						}
					};
					movePiece(move);
				}
			}
		}
		this.setState({
			selected: clicked,
			moves: clickedPiece ? clickedPiece["availableMoves"] : []
		});
	}

	renderCell(row, col) {
		let piece = this.state.board[row][col];
		let isMove = isAvailableMove(this.state.moves, row, col);
		if (piece == null) {
			return (<BlankComponent isMove={isMove} />);
		} else {
			let isSelected = this.state.selected.piece == piece;
			return (<PieceComponent
				tile={piece.tileClass()}
				piece={piece.pieceClass()}
				isSelected={isSelected}
				isMove={isMove}
			/>);
		}
	}

	renderTable() {
		return (
			<table className="pieceContainer">
				<tbody>
					{this.state.board.map((rowPieces, row) =>
						<tr key={row}>
							{rowPieces.map((piece, col) =>
								<td key={col} data-row={row} data-col={col}
									onClick={() => this.onCellClick(row, col)}>
									{this.renderCell(row, col)}
								</td>
							)}
						</tr>
					)}
				</tbody>
			</table>
		);
	}

	render() {
		return (
			<div className="board">
				<div className="boardBackground" />
				{ this.renderTable() }
			</div>
		);
	}
}