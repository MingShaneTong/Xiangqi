function Horse(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="horse-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="horse-black" />;
    }
}