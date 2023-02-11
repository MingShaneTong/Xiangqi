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
		console.log("Game");
		console.log(this.state.game);
		return (
			<div className="game">
				<div className="boardBackground" />
				<BoardComponent game={this.state.game} />
			</div>
		);
	}
}