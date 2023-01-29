function Rook(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="rook-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="rook-black" />;
    }
}