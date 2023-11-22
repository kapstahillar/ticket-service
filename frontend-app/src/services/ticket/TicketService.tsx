import httpclient from "../../common/httpclient";
import ITicketAPI, { ICreateNewTicketRequest, ISolveTicketRequest } from "../../types/ticket/Ticket";
import moment from 'moment';

class TicketService {
    getAll() {
        return httpclient.get<Array<ITicketAPI>>("/ticket");
    }
    create(data: ICreateNewTicketRequest) {
        data.deadLineAt = moment(data.deadLineAt).utc().format("YYYY-MM-DDTHH:mm:ss")
        return httpclient.post<ITicketAPI>("/ticket", data);
    }
    solve(data: ISolveTicketRequest) {
        return httpclient.put<ITicketAPI>("/ticket", data);
    }
}

export default new TicketService();
