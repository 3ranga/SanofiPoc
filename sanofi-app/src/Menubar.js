import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './App.css';

class Menubar extends Component {
  render() {
    return (
      <div>
<ul>
        <li>
          <Link to="/Dashboard">Dashboard</Link>
        </li>
        <li>
          <Link to="/NewRequest">New Request</Link>
        </li>
      </ul>
      </div>
    );
  }
}

export default Menubar;