import React, { Component } from 'react';
import './App.css';
import TicketListComponent from './components/TicketListComponent/TicketListComponent';
import ITicketAPI, { ICreateNewTicketRequest } from './types/ticket/Ticket';
import TicketService from './services/ticket/TicketService';
import TicketCreateNewFormComponent from './components/TicketCreateNewFormComponent/TicketCreateNewFormComponent';


interface AppState {
  isLoaded: boolean,
  items: Array<ITicketAPI>
}

class App extends Component<{}, AppState> {

  state: AppState = {
    items: [],
    isLoaded: false
  }

  componentDidMount(): void {
    TicketService.getAll().then(result => {
      this.setState({ items: result.data })
    })
  }

  handleSubmit(data: ICreateNewTicketRequest) {
    TicketService.create(data).then(result => {
      let ticket = result.data
      this.state.items.push(ticket)
      this.setState({ ...this.state, items: this.state.items })
    })
  }

  handleSolve(id: number) {
    TicketService.solve({ ticketId: id }).then(result => {
      let ticket = result.data
      this.state.items = this.state.items.filter(x => x.id != id)
      this.setState({ ...this.state, items: this.state.items })
    })
  }

  render(): React.ReactNode {
    return (
      <div className="App" >
        <h1 className="Title"> Ticket solver </h1>
        <TicketCreateNewFormComponent handleSubmit={this.handleSubmit.bind(this)} />
        <TicketListComponent items={this.state.items} onHandleSolve={this.handleSolve.bind(this)} />
      </div>
    );
  }
}

export default App;
