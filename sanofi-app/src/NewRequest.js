import React, { Component } from 'react';
import { Grid, FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';
import RequestService from './Services/RequestService';
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
        <Grid>
        <Header/>
        <Menubar/>
        <form onSubmit={this.handleSubmit}>
        <FormGroup>
          <ControlLabel>Requester</ControlLabel>
          <FormControl
            type="text"
            value={this.state.requester}
            placeholder="Enter text"
            onChange={this.handleRequesterChange}
          />
          <FormControl.Feedback />
        </FormGroup>
        <FormGroup>
          <ControlLabel>Message</ControlLabel>
          <FormControl
            type="text"
            value={this.state.message}
            placeholder="Enter text"
            onChange={this.handleMessageChange}
          />
          <FormControl.Feedback />
        </FormGroup>                       
        <Button type="submit">Submit</Button>
      </form>
        <Footer/>
      </Grid>
    );
  }
}

export default NewRequest;