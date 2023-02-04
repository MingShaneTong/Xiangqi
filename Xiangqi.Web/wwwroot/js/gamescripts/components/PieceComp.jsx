function PieceComponent(props) {
    return (
        <div className={"tile " + props.tile}>
            <div className={"piece " + props.piece}></div>
        </div>
    );
}

function BlankComponent() {
    return (
        <div className={"tile blank-tile"}>
            <div className={"piece blank-piece"}></div>
        </div>
    );
}