class GameComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			game = props.gameState
		};
		updateGame = updateGameState.bind(this);
	}

	render() {
		return (
			<div className="game">
				<div className="boardBackground" />
				<BoardComponent gameState={this.state.game} />
			</div>
		);
	}
}