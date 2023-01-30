function Cannon(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="cannon-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="cannon-black" />;
    }
}