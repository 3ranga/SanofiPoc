import React, { Component } from 'react';
import { Grid } from 'react-bootstrap';
import './App.css';
import Header from './Header';
import Footer from './Footer';
import Menubar from './Menubar';


class App extends Component {
  render() {
    return (
      <Grid>
        <Header/>
        <Menubar/>
        <p>Home</p>
        <Footer/>
      </Grid>
    );
  }
}

export default App;
