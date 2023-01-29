function Cannon(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="cannon-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="cannon-black" />;
    }
}