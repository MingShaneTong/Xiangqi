function PieceComponent(props) {
    return (
        <div className={"tile " + props.tile}>
            <div className={"piece " + props.piece}></div>
        </div>
    );
}