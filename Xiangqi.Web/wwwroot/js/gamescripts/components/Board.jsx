function Board() {
	return (
		<div className="board">
			<div className="boardBackground" />
			<table className="pieceContainer">
				<tr>
					<td><Pawn color="red" /></td>
					<td><Pawn color="black" /></td>
				</tr>
			</table>
		</div>
	);
}