import React, { Component } from 'react';
import RequestService from './Services/RequestService';
import './App.css';
import Menubar from './Menubar';
import Header from './Header';
import Footer from './Footer';

class NewRequest extends Component {
  constructor(props) {
    super(props);
    this.state = {requester: '', message: ''};
    this.requestService = new RequestService();

    this.handleRequesterChange = this.handleRequesterChange.bind(this);
    this.handleMessageChange = this.handleMessageChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleRequesterChange(event) {
    this.setState({requester: event.target.value});
  }

  handleMessageChange(event) {
    this.setState({message: event.target.value});
  }

  handleSubmit(event) {
    this.requestService.draft({requester: this.state.requester, message: this.state.message})
    .then(alert('Request Created'));
    event.preventDefault();
  }

  render() {
    return (
        <div className="App">
        <Header/>
        <Menubar/>
        <form onSubmit={this.handleSubmit}>
        <label>
          Requester:
          <input type="text" value={this.state.requester} onChange={this.handleRequesterChange} />
        </label>                
        <label>
          Message:
          <input type="text" value={this.state.message} onChange={this.handleMessageChange} />
        </label>        
        <input type="submit" value="Submit" />
      </form>
        <Footer/>
      </div>
    );
  }
}

export default NewRequest;