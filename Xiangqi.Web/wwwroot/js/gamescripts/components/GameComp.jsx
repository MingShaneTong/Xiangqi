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
				<div className="row">
					<div className="col">
						<BoardComponent game={game} />
					</div>
					<div className="col">
						<GameInfoComponent game={game} />
					</div>
				</div>
			</div>
		);
	}
}