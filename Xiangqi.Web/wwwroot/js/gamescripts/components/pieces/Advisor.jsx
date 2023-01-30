function Advisor(props) {
    switch (props.color) {
        case 'red':
            return <Piece tile="tile-red" piece="advisor-red" />;
        case 'black':
            return <Piece tile="tile-black" piece="advisor-black" />;
    }
}