let updateGame;

class GameInfoComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			game: props.game
		};
	}

	isPlayerTurn() {
		return this.state.game.playerColor == this.state.game.turn;
	}

	render() {
		let turnAlert;
		if (this.isPlayerTurn()) {
			turnAlert = (
				<div className="alert alert-success" role="alert">
					Your Turn
				</div>
			);
		} else {
			turnAlert = (
				<div className="alert alert-warning" role="alert">
					Opponent's Turn
				</div>
			);
		}

		let inCheckAlert;
		if (this.state.game.status == 'Check') {
			if (this.isPlayerTurn()) {
				inCheckAlert = (
					<div className="alert alert-danger" role="alert">
						Your King is in check
					</div>
				);
			} else {
				inCheckAlert = (
					<div className="alert alert-info" role="alert">
						Opponent's king is in check
					</div>
				);
			}
		}

		return (
			<div className="card gameInfo my-3">
				<div className={"card-header playerColor" + this.state.game.playerColor}>
					You are Player {this.state.game.playerColor}
				</div>
				<div className="card-body">
					{turnAlert}
					{inCheckAlert}
				</div>
				<ul className="list-group list-group-flush">
					<li className="list-group-item">An item</li>
					<li className="list-group-item">A second item</li>
					<li className="list-group-item">A third item</li>
				</ul>
				<div className="card-body">
					<button className="card-link btn btn-primary" onClick={joinGame}>Join Game</button>
				</div>

			</div>
		);
	}
}