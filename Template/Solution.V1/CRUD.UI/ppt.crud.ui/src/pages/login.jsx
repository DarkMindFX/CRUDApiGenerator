import React from 'react';
import { TextField } from '@material-ui/core';
import { Link, withRouter  } from 'react-router-dom'
import { Button } from '@material-ui/core';
import Alert from '@material-ui/lab/Alert';
import constants from '../constants';
import queryString from 'query-string'
const UsersDal = require('../dal/UsersDal')

class LoginPage extends React.Component {

    constructor(props) {
        super(props);

        const query = queryString.parse(this.props.location.search);
        const retUri = query.ret;

        this.state = {
            login: null,
            password: null,
            showError: false,
            error: null,
            ret: retUri ? retUri : "/"
        }

        this.onLoginChanged = this.onLoginChanged.bind(this);
        this.onPasswordChanged = this.onPasswordChanged.bind(this);
        this.onLoginClicked = this.onLoginClicked.bind(this);
    }

    onLoginChanged(event) {
        let login = event.target.value;

        let updatedState = this.state;
        updatedState.login = login;

        this.setState(updatedState);
    }

    onPasswordChanged(event) {
        let pwd = event.target.value;

        let updatedState = this.state;
        updatedState.password = pwd;

        this.setState(updatedState);
    }

    onLoginClicked() {

        let obj = this;

        console.log(`Logging in as ${this.state.login} / ${this.state.password}`)

        const dal = new UsersDal();
        dal.login(this.state.login, this.state.password).then( (res) => {

            console.log(res);
            let updatedState = this.state;
            if(res.status == constants.HTTP_OK) {
                console.log('Login SUCCESS', res.data.Token)
                updatedState.showError = false;
                updatedState.error = null;

                localStorage.clear();
                localStorage.setItem(constants.SESSION_TOKEN_KEY, res.data.Token);

                obj.props.history.push(this.state.ret);

            }
            else if(res.status == constants.HTTP_NotFound) {
                updatedState.showError = true;
                updatedState.error = "User with given login not found";
            }
            else if(res.status == constants.HTTP_Forbidden) {
                updatedState.showError = true;
                updatedState.error = "Invalid login/password combination";
            }
            else {
                updatedState.showError = true;
                updatedState.error = "Error occured when trying to login";
            }

            this.setState(updatedState);

        });

    }

    render() {

        const styleError = {
            display: this.state.showError ? "block" : "none"
        }

        return (
            <div>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <Alert severity="error" style={styleError}>Error: {this.state.error}</Alert>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <TextField  id="login" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="Login" 
                                            defaultValue={this.state.login}
                                            onChange={ (event) => { this.onLoginChanged(event) } }
                                            />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <TextField  id="password" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="Password" 
                                            defaultValue={this.state.password}
                                            onChange={ (event) => { this.onPasswordChanged(event) } }
                                            />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <Button variant="contained" 
                                        color="primary"
                                        onClick = { this.onLoginClicked }>
                                    Login
                                </Button>
                                <Button variant="contained" component={Link} to="/" >Cancel</Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}

export default withRouter(LoginPage); 