import { useEffect, useState } from 'react';
import './TicketItemComponent.css';
import moment from 'moment';

interface TicketItemComponentProps {
    id: number;
    description: string;
    createdAt: string;
    deadLineAt: string;
    solvedAt: string | null;
    onSolved: (id: number) => void;
}

function TicketItemComponent({
    id,
    description,
    createdAt,
    deadLineAt,
    onSolved
}: TicketItemComponentProps) {

    const [isNearDeadline, setIsNearDeadline] = useState<boolean>(false);

    useEffect(() => {
        const checkIfUnderHourRemainingOnDeadline = () => {
            if (/\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/.test(deadLineAt)) {
                const d1 = new Date(deadLineAt)
                const currDate = moment()
                let date = moment(d1)
                date = date.subtract(1, 'h')
                if (currDate > date) {
                    setIsNearDeadline(true);
                }
            }
        }

        checkIfUnderHourRemainingOnDeadline()
    }, [deadLineAt])

    return (
        <div className={`ticket-list-item ${isNearDeadline ? 'near-deadline' : ''}`}>
            <div>{id}</div>
            <div>{description}</div>
            <div>{moment.utc(createdAt).local().format("YYYY-MM-DDTHH:mm:ss")}</div>
            <div>{moment.utc(deadLineAt).local().format("YYYY-MM-DDTHH:mm:ss")}</div>
            <button onClick={() => onSolved(id)}>Solve</button>
        </div>
    );
}

export default TicketItemComponent;