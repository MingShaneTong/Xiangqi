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
			<table className="pieceContainer">
				<tbody>
					{boardComps.map(row =>
						<tr key={key++}>
							{row.map(cell =>
								<td key={key++}>{cell}</td>
							)}
						</tr>
					)}
				</tbody>
			</table>
		</div>
	);
}