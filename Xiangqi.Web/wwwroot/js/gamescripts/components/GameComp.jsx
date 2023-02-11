let updateGame;

class GameComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			game: props.game
		};
		updateGame = updateGameState.bind(this); 
	}

	render() {
		let game = this.state.game;
		return (
			<div className="game">
				<div className="gameInfo">
					<div className="playerColor">
						Player: <b>{game.playerColor}</b>
					</div>
					<div className="turn">
						Turn: <b>{game.turn}</b>
					</div>
					<div className="status">
						Status: <b>{game.status}</b>
					</div>
				</div>
				<BoardComponent game={game} />
			</div>
		);
	}
}