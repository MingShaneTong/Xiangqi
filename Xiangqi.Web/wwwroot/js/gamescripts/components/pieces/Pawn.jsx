function Pawn(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="pawn-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="pawn-black" />;
    }
}