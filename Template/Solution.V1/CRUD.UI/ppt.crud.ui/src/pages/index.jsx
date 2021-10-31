
import React from "react";
import { Link } from "react-router-dom"
//Functional Component 
class MainPage extends React.Component {

  render() {
    return (
      <div>

        <h3>Welcome To PhotoPrint!</h3>
        <div>
          <Link to="/login">Login</Link>
        </div>
        <div>
          <Link to="/register">Register User</Link>
        </div>
      </div>
    );
  }
};

export default MainPage;