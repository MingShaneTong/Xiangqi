const endStatuses = ['Checkmate', 'Stalemate'];

class GameInfoComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			game: props.game,
			hideJoin: false
		};
	}

	isPlayerTurn() {
		return this.state.game.playerColor == this.state.game.turn;
	}

	gameHasEnded() {
		return endStatuses.includes(this.state.game.status); 
	}

	onJoinGameButton = () => {
		joinGame();
		this.setState({
			hideJoin: true
		});
	}

	render() {
		let yourTurn = this.isPlayerTurn();
		let gameEnded = this.gameHasEnded();

		let turnAlert = yourTurn ?
			<div className="alert alert-success" role="alert">
				Your Turn
			</div> :
			<div className="alert alert-warning" role="alert">
				Opponent's Turn
			</div>;

		let inCheckAlert = this.state.game.status == 'Check' ?
			(
				yourTurn ?
					<div className="alert alert-danger" role="alert">
						Your King is in check
					</div> :
					<div className="alert alert-info" role="alert">
						Opponent's king is in check
					</div>
			) : <></>;

		let gameEndAlert = gameEnded ?
			(
				yourTurn ?
					<div className="alert alert-danger" role="alert">
						You have lost by {this.state.game.status}
					</div> :
					<div className="alert alert-success" role="alert">
						You won by {this.state.game.status}
					</div>
			) : 
			<></>

		let hasFooter = !this.state.hideJoin || gameEnded;
		let joinButton = !this.state.hideJoin ?
			<button className="card-link btn btn-primary" onClick={this.onJoinGameButton}>
				Join Game
			</button> : <></>;
		let newGameButton = gameEnded ? 
			<button className="card-link btn btn-primary" onClick={() => window.location.reload(false)}>
				New Game
			</button> : <></>


		return (
			<div className="card gameInfo my-3">
				<div className={"card-header playerColor" + this.state.game.playerColor}>
					You are Player {this.state.game.playerColor}
				</div>
				<div className="card-body">
					{turnAlert}
					{gameEndAlert}
					{inCheckAlert}
				</div>
				<ul className="list-group list-group-flush">
					<li className="list-group-item">An item</li>
					<li className="list-group-item">A second item</li>
					<li className="list-group-item">A third item</li>
				</ul>
				{hasFooter ?
					<div className="card-body">
						{joinButton}
						{newGameButton}
					</div> : <></>
				}
			</div>
		);
	}
}