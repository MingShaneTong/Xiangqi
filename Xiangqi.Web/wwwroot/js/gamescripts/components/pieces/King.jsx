function King(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="king-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="king-black" />;
    }
}