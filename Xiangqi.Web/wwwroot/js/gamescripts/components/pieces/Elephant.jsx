function Elephant(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="elephant-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="elephant-black" />;
    }
}