function Rook(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="rook-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="rook-black" />;
    }
}