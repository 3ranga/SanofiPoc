import React, { Component } from "react";
import { Grid } from "react-bootstrap";
import Menubar from "./Menubar";
import RequestList from "./RequestList";
import Header from "./Header";
import Footer from "./Footer";

class Dashboard extends Component {
  render() {
    return (
      <Grid>
        <Header />
        <Menubar />
        <RequestList />
        <Footer />
      </Grid>
    );
  }
}

export default Dashboard;
