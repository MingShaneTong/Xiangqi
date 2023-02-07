function PieceComponent(props) {
    return (
        <>
            {props.isSelected ? <div className={"selected"} /> : null}
            {props.isMove ? <div className={"move"} /> : null}
            <div className={"tile " + props.tile}>
                <div className={"piece " + props.piece}></div>
            </div>
        </>
    );
}

function BlankComponent(props) {
    return (
        <>
            {props.isMove ? <div className={"move"} /> : null}
            <div className={"tile blank-tile"}>
                <div className={"piece blank-piece"}></div>
            </div>
        </>
    );
}