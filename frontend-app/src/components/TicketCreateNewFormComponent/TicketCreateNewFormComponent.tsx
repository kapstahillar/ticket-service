import { Component, FormEvent } from "react";
import { ICreateNewTicketRequest } from "../../types/ticket/Ticket";
import FormErrorsComponent from "../../common/components/FormErrors";
import moment from 'moment';

interface ITicketCreateNewFormComponentProps {
    handleSubmit: (data: ICreateNewTicketRequest) => void
}

interface ITicketCreateNewFormComponentState {
    description: string,
    deadLineAt: string,
    errors: Array<string>
}

class TicketCreateNewFormComponent extends Component<ITicketCreateNewFormComponentProps, ITicketCreateNewFormComponentState> {

    state = {
        description: "Enter description",
        deadLineAt: moment(new Date()).format("YYYY-MM-DDTHH:mm:ss"),
        errors: []
    }

    handleSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        if (this.validateFields()) {
            this.props.handleSubmit(this.state)
        }
    }

    handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        this.setState({ ...this.state, [name]: value })
    }

    validateFields(): boolean {
        let errors: Array<string> = []
        if (!this.isIsoDate(this.state.deadLineAt)) {
            errors.push("Deadline date is in wrong format: use YYYY-MM-DDTHH:MM:SS")
        }
        if (this.state.description == "") {
            errors.push("Your description is empty")
        }
        if (errors.length > 0) {
            this.setState({ ...this.state, errors: errors })
            return false;
        }
        this.setState({ ...this.state, errors: [] })
        return true;
    }

    private isIsoDate(str: string): boolean {
        if (!/\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/.test(str)) return false;
        const d = new Date(str);
        return d instanceof Date && !isNaN(d.getTime());
    }

    render() {
        return (
            <>
                <h3> Add new Ticket </h3>
                <form className="ticket-create-form" onSubmit={this.handleSubmit.bind(this)}>
                    <FormErrorsComponent errors={this.state.errors} />
                    <label>
                        Description:
                        <input type="text" name="description" value={this.state.description} onChange={this.handleInputChange.bind(this)} />
                    </label>
                    <label>
                        Deadline (YYYY-MM-DDTHH:MM:SS):
                        <input type="text" name="deadLineAt" value={this.state.deadLineAt} onChange={this.handleInputChange.bind(this)} />
                    </label>
                    <button type="submit">Submit</button>
                </form>
            </>
        )
    }
}

export default TicketCreateNewFormComponent;