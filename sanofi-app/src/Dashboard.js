import React, { Component } from 'react';
import './App.css';
import Menubar from './Menubar';
import RequestList from './RequestList';
import Header from './Header';
import Footer from './Footer';

class Dashboard extends Component {
  render() {
    return (
        <div className="App">
        <Header/>
        <Menubar/>
        <RequestList/>
        <Footer/>
      </div>
    );
  }
}

export default Dashboard;