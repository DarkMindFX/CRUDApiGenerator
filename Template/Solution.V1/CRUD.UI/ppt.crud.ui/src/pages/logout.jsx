
import React from 'react';
import { Link, withRouter } from 'react-router-dom'
const constants = require('../constants')

class LogoutPage extends React.Component {

    constructor(props) {
        super(props);
    }

    componentDidMount() {
        localStorage.clear();

        this.props.history.push("/");
    }

    render() {
        return (
            <div>
                Logged Out. Redirecting...
            </div>
        )
    }

}

export default withRouter(LogoutPage); 