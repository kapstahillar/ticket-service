export default interface ITicketAPI {
    id: number,
    description: string,
    createdAt: string,
    deadLineAt: string,
    solvedAt: string | null,
}

export interface ICreateNewTicketRequest {
    description: string,
    deadLineAt: string,
}

export interface ISolveTicketRequest {
    ticketId: number,
}