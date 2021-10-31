import logo from './logo.svg';
import './App.css';

import {
  BrowserRouter as Router,
  Route,
  Switch,
  Link,
  Redirect
} from 'react-router-dom';

import React from 'react';

import MainPage from './pages';
import RegisterPage from './pages/register';
import LogingPage from './pages/login';
import LogoutPage from './pages/logout';




class App extends React.Component {

  render() {
    return (
      <Router>
       {/*All our Routes goes here!*/}
       <Route exact path="/" component={MainPage} />
       <Route exact path="/register" component={RegisterPage} />
       <Route exact path="/login" component={LogingPage} />
       <Route exact path="/logout" component={LogoutPage} />
       

       {/*Admin pages*/}
       
      
      </Router>
    );
  }
}

export default App;
