import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { Nav, Navbar, NavItem, NavDropdown, MenuItem } from "react-bootstrap";

class Menubar extends Component {
  render() {
    return (
        <Navbar>
          <Navbar.Header>
            <Navbar.Brand>
            <Link to="/">Home</Link>
            </Navbar.Brand>
          </Navbar.Header>
          <Nav>
            <NavItem href="/Dashboard">
            Dashboard
            </NavItem>
            <NavItem href="/NewRequest">
            New Request
            </NavItem>
            <NavDropdown eventKey={3} title="All Requests" id="basic-nav-dropdown">
              <MenuItem eventKey={3.1}>Pending</MenuItem>
              <MenuItem eventKey={3.2}>Approved</MenuItem>
              <MenuItem eventKey={3.3}>Draft</MenuItem>
            </NavDropdown>
          </Nav>
        </Navbar> 
    );
  }
}

export default Menubar;