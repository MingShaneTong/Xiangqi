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
			<div className="gameInfo">
				{turnAlert}
				{inCheckAlert}
				<div className="playerColor">
					Player: <b>{this.state.game.playerColor}</b>
				</div>
			</div>
		);
	}
}