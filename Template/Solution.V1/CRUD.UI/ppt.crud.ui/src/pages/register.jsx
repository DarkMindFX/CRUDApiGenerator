import React from 'react';
import { Link, withRouter } from 'react-router-dom'
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import Alert from '@material-ui/lab/Alert';
import constants from '../constants';

const PageHelper = require("../helpers/PageHelper");
const UsersDal = require('../dal/UsersDal');
const ContactsDal = require('../dal/ContactsDal');
const UserContactsDal = require('../dal/UserContactsDal');

const { UserDto, ContactDto, UserContactDto } = require('ppt.photoprint.dto')

class RegisterPage extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            user: this._createEmptyUserObj(),
            contact: this._createEmptyUserContact(),
            error: null,
            showError: false,
            showSuccess: false
        }

        this.onLoginChanged = this.onLoginChanged.bind(this);
        this.onPasswordChanged = this.onPasswordChanged.bind(this);
        this.onFirstNameChanged = this.onFirstNameChanged.bind(this);
        this.onMiddleNameChanged = this.onMiddleNameChanged.bind(this);
        this.onLastNameChanged = this.onLastNameChanged.bind(this);
        this.onFriendlyNameChanged = this.onFriendlyNameChanged.bind(this);
        this.onEmailValueChanged = this.onEmailValueChanged.bind(this);

        this.onRegisterClicked = this.onRegisterClicked.bind(this);

    }

    onLoginChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.user.Login = newVal;

        this.setState(updatedState);
    }

    onPasswordChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.user.Password = newVal;

        this.setState(updatedState);
    }

    onFirstNameChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.user.FirstName = newVal;

        this.setState(updatedState);
    }

    onMiddleNameChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.user.MiddleName = newVal;

        this.setState(updatedState);
    }

    onLastNameChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.user.LastName = newVal;

        this.setState(updatedState);
    }

    onFriendlyNameChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.user.FriendlyName = newVal;

        this.setState(updatedState);
    }

    onEmailValueChanged(event) {

        let updatedState = this.state;
        let newVal = null;
        newVal = event.target.value
        updatedState.contact.Value = newVal;

        this.setState(updatedState);
    }

    onRegisterClicked() {
        console.log('Registering user: ', this.state.user);
        console.log('User\'s contact: ', this.state.contact);

        const dalUsers = new UsersDal();
        const dalContacts = new ContactsDal();
        const dalUserContacts = new UserContactsDal();

        dalUsers.insertUser(this.state.user)
        .then( (res) => {

            let updatedState = this.state;
            if(res.status == constants.HTTP_Created) {

                updatedState.user.ID = res.data.ID;
                this.state.contact.CreatedByID = updatedState.user.ID;
                
                dalContacts.insertContact(this.state.contact)
                .then( (res) => {

                    if(res.status == constants.HTTP_Created) {
                        updatedState.contact.ID = res.data.ID
                        
                        let userContactDto = new UserContactDto();
                        userContactDto.ContactID = updatedState.contact.ID;
                        userContactDto.UserID = updatedState.user.ID;
                        userContactDto.IsPrimary = true;

                        dalUserContacts.insertUserContact(userContactDto)
                        .then( (res) => {
                            if(res.status == constants.HTTP_Created) {
                                updatedState.showSuccess = true;
                                updatedState.showError = false;
                                updatedState.error = null;
                            }
                            else {                
                                updatedState.showSuccess = false;
                                updatedState.showError = true;
                                updatedState.error = res.data.Message;  
                                             
                            } 
                            this.setState(updatedState);
                        });
                         
                    }
                    else {                
                        updatedState.showSuccess = false;
                        updatedState.showError = true;
                        updatedState.error = res.data.Message;  
                        this.setState(updatedState);              
                    }

                });
            }
            else {                
                updatedState.showSuccess = false;
                updatedState.showError = true;
                updatedState.error = res.data.Message;
                this.setState(updatedState);                
            }
            

        })
        .catch( (err) => {

        });
    }

    render() {

        const styleSuccess = {
            display: this.state.showSuccess ? "block" : "none"
        }

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
                                <Alert severity="success" style={styleSuccess}>
                                    New user with login {this.state.user.Login} successfully created.
                                    You can now login - <Button variant="contained" component={Link} color="primary" size="small" to="/login" >Login</Button> 
                                </Alert>
                            </td>
                        </tr>
                        <tr>
                            <td colSpan={2}>
                                <TextField  id="Login" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="Login" 
                                            value={this.state.user.Login}
                                            onChange={ (event) => { this.onLoginChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 

                        <tr>
                            <td colSpan={2}>
                                <TextField  id="Email" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="Email" 
                                            value={this.state.contact.Value}
                                            onChange={ (event) => { this.onEmailValueChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 
   
                        <tr>
                            <td colSpan={2}>
                                <TextField  id="Password" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="Password" 
                                            value={this.state.user.Password}
                                            onChange={ (event) => { this.onPasswordChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 
   
                        <tr>
                            <td colSpan={2}>
                                <TextField  id="FirstName" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="FirstName" 
                                            value={this.state.user.FirstName}
                                            onChange={ (event) => { this.onFirstNameChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 
   
                        <tr>
                            <td colSpan={2}>
                                <TextField  id="MiddleName" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="MiddleName" 
                                            value={this.state.user.MiddleName}
                                            onChange={ (event) => { this.onMiddleNameChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 
   
                        <tr>
                            <td colSpan={2}>
                                <TextField  id="LastName" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="LastName" 
                                            value={this.state.user.LastName}
                                            onChange={ (event) => { this.onLastNameChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 
   
                        <tr>
                            <td colSpan={2}>
                                <TextField  id="FriendlyName" 
                                            fullWidth
                                            type="text" 
                                            variant="filled" 
                                            label="FriendlyName" 
                                            value={this.state.user.FriendlyName}
                                            onChange={ (event) => { this.onFriendlyNameChanged(event) } }
                                            />
                                
                            </td>
                        </tr> 
                        <tr>
                            <td>
                                <Button variant="contained" 
                                        color="primary"
                                        onClick = { this.onRegisterClicked }>
                                    Register
                                </Button>
                                <Button variant="contained" component={Link} to="/" >Cancel</Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }

    _createEmptyUserObj() {

        let user = new UserDto();
        user.Login = null;
        user.FriendlyName = null;
        user.Password = null;
        user.FirstName = null;
        user.MiddleName = null;
        user.LastName = null;
        user.UserStatusID = constants.DEFAULT_USER_STATUS;
        user.UserTypeID = constants.DEFAULT_USER_TYPE;

        return user;
    }

    _createEmptyUserContact() {
        let contact = new ContactDto();
        contact.ContactTypeID = constants.DEFAULT_CONTACT_TYPE;
        contact.Title = constants.DEFAULT_CONTACT_TITLE;
        contact.Value = null;
        contact.IsDeleted = false;
        contact.Comment = null;

        return contact;
    }

}

export default withRouter(RegisterPage);