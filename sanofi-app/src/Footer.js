import React, { Component } from 'react';
import { Row, Col } from 'react-bootstrap';
import './App.css';

class Footer extends Component {
  render() {
    return (
      <Row xs={12} md={8}>
        <Col><h4>Footer</h4></Col>
      </Row>
  );
  }
}

export default Footer;