import TicketItemComponent from "../TicketItemComponent/TicketItemComponent";
import ITicketAPI from "../../types/ticket/Ticket";
import "./TicketListComponent.css"

interface TicketListComponentProps {
    items: Array<ITicketAPI>
    onHandleSolve: (id: number) => void
}

function TicketListComponent({
    items,
    onHandleSolve
}: TicketListComponentProps) {
    return (
        <div className="ticket-list">
            <div className="ticket-list-header">
                <div>ID</div>
                <div>Description</div>
                <div>Created</div>
                <div>Deadline</div>
                <div></div>
            </div>
            {items.map((item, key) => {
                return <TicketItemComponent
                    key={"ticket-list-item-" + key}
                    createdAt={item.createdAt}
                    deadLineAt={item.deadLineAt}
                    description={item.description}
                    id={item.id}
                    solvedAt={item.solvedAt}
                    onSolved={() => onHandleSolve(item.id)}
                />
            })}
        </div>
    );
}

export default TicketListComponent;