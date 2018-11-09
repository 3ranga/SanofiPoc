import React, { Component } from 'react';
import RequestService from './Services/RequestService';
import './App.css';
import Menubar from './Menubar';
import Header from './Header';
import Footer from './Footer';

class ViewRequest extends Component {
  constructor(props){
    super(props);
    const { params } = this.props.match;
    this.state = { requestId: params.id, request: null };
    this.requestService = new RequestService();

    this.handleRequestApprovalClick = this.handleRequestApprovalClick.bind(this);
    this.handleApproveClick = this.handleApproveClick.bind(this);
    this.handleRejectClick = this.handleRejectClick.bind(this);
  }

  handleRequestApprovalClick(event) {
    const { requestId } = this.state;
    this.requestService.requestApproval(requestId)
    .then(d => this.setState({ request: d }));
  }

  handleApproveClick(event) {
    const { requestId } = this.state;
    this.requestService.approve(requestId)
    .then(d => this.setState({ request: d }));
  }
  
  handleRejectClick(event) {
    const { requestId } = this.state;
    this.requestService.reject(requestId)
    .then(d => this.setState({ request: d }));
  }  

  componentDidMount() {
    const { requestId } = this.state;
    this.requestService.getRequest(requestId)
    .then(d => this.setState({ request: d }));
  }

  render() {
    const { request } = this.state;
    if (request) {
      return (
        <div className="App">
        <Header/>
        <Menubar/>
        <div>Requester: {request.Requester}</div>
        <div>Message: {request.Message}</div>
        <div>Status: {request.Status}</div>
        <input type="button" value="Request Approval" onClick={this.handleRequestApprovalClick}/>
        <input type="button" value="Approve" onClick={this.handleApproveClick}/>
        <input type="button" value="Reject" onClick={this.handleRejectClick}/>
        <Footer/>        
        </div>
      );
    }

    return (
        <div className="App">
        <Header/>
        <Menubar/>
        <p>Invalid Request</p>
        <Footer/>
      </div>
    );
  }
}

export default ViewRequest;