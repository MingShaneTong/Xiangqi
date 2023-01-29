function Advisor(props) {
    switch (props.color) {
        case 'red':
            return <PieceComponent tile="tile-red" piece="advisor-red" />;
        case 'black':
            return <PieceComponent tile="tile-black" piece="advisor-black" />;
    }
}