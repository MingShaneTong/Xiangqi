function Pawn(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="pawn-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="pawn-black" />;
    }
}