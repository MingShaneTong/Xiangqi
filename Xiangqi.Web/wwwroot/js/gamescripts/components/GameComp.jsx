class GameComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			game: props.game
		};
	}

	updateState(gameState) {
		this.setState(gameState);
	}

	render() {
		let game = this.state.game;
		return (
			<div className="game container-fluid">
				<div className="col-lg-9">
					<BoardComponent game={game} />
				</div>
				<div className="col-sm-3">
					<GameInfoComponent game={game} />
				</div>
			</div>
		);
	}
}