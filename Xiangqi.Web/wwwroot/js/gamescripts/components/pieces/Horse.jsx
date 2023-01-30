function Horse(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="horse-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="horse-black" />;
    }
}