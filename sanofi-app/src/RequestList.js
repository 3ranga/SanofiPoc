import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Row, Table } from "react-bootstrap";
import RequestService from "./Services/RequestService";
import "./App.css";

class RequestList extends Component {
  constructor(props) {
    super(props);
    this.state = { requests: null };
    this.requestService = new RequestService();
  }

  componentDidMount() {
    this.requestService.getRequests().then(d => this.setState({ requests: d }));
  }

  render() {
    const { requests } = this.state;
    if (requests) {
      return (
        <Row>
          <Table striped bordered condensed hover>
            <thead>
              <tr>
                <th>Id</th>
                <th>Requester</th>
                <th>Message</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {requests.map(request => (
                <tr key={request.Id}>
                  <td>
                    <Link to={`/Requests/${request.Id}`}>{request.Id}</Link>
                  </td>
                  <td>{request.Requester}</td>
                  <td>{request.Message}</td>
                  <td>{request.Status}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Row>
      );
    }

    return <div>No Requests</div>;
  }
}

export default RequestList;
