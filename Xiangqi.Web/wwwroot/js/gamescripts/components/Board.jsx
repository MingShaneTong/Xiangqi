function Board() {
	return (
		<div className="board">
			<div className="boardBackground" />
			<table className="pieceContainer">
				<tr>
					<td><Advisor color="red" /></td>
					<td><Advisor color="black" /></td>
				</tr>
				<tr>
					<td><Cannon color="red" /></td>
					<td><Cannon color="black" /></td>
				</tr>
				<tr>
					<td><Elephant color="red" /></td>
					<td><Elephant color="black" /></td>
				</tr>
				<tr>
					<td><Horse color="red" /></td>
					<td><Horse color="black" /></td>
				</tr>
				<tr>
					<td><King color="red" /></td>
					<td><King color="black" /></td>
				</tr>
				<tr>
					<td><Pawn color="red" /></td>
					<td><Pawn color="black" /></td>
				</tr>
				<tr>
					<td><Rook color="red" /></td>
					<td><Rook color="black" /></td>
				</tr>
			</table>
		</div>
	);
}