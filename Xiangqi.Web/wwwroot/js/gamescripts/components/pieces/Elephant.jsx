function Elephant(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="elephant-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="elephant-black" />;
    }
}