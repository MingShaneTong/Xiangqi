const domContainer = document.querySelector('#board');
const root = ReactDOM.createRoot(domContainer);

function updateBoard(board) {
	root.render(<BoardComponent board={board} />);
}
