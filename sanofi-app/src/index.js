import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router } from 'react-router-dom'
import './index.css';
import App from './App';
import Dashboard from './Dashboard';
import NewRequest from './NewRequest';
import ViewRequest from './ViewRequest';
import * as serviceWorker from './serviceWorker';

const routing = (
    <Router>
      <div>
        <Route exact path="/" component={App} />
        <Route path="/Dashboard" component={Dashboard} />
        <Route path="/NewRequest" component={NewRequest} />
        <Route path="/Requests/:id" component={ViewRequest} />
      </div>
    </Router>
  )
  
ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
