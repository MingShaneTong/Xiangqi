function BoardComponent(props) {
	let board = props.board;

	let boardComps = [];

	for (let r = 0; r < 10; r++) {
		let row = [];
		for (let c = 0; c < 9; c++) {
			let piece = board[r][c];
			if (piece == null) {
				row.push(<BlankComponent />)
			} else {
				row.push(<PieceComponent tile={piece.tileClass()} piece={piece.pieceClass()} />);
			}
		}
		boardComps.push(row);
	}

	let key = 1;

	return (
		<div className="board">
			<div className="boardBackground" />
			<table className="pieceContainer" onClick={onBoardClick}>
				<tbody>
					{boardComps.map((rowCells, row) =>
						<tr key={key++}>
							{rowCells.map((cell, col) =>
								<td key={key++} data-row={row} data-col={col}>{cell}</td>
							)}
						</tr>
					)}
				</tbody>
			</table>
		</div>
	);
}