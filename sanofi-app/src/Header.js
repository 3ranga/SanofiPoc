import React, { Component } from 'react';
import { Row, Col } from 'react-bootstrap';
import './App.css';

class Header extends Component {
  render() {
    return (
        <Row xs={12} md={8}>
          <Col><h1>Header</h1></Col>
        </Row>
    );
  }
}

export default Header;