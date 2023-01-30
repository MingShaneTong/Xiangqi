function King(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="king-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="king-black" />;
    }
}