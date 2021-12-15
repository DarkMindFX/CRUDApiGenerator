
class LoginRequest {

    set login(val) { this.Login = val; }
    get login()    { return this.Login; }

    set password(val)   { this.Password = val; }
    get password()      { return this.Password; }

}

class LoginResponse {

    set user(val)  { this.User = val; }
    get user()     { return this.User; }

    set token(val)  { this.Token = val; }
    get token()     { return this.Token; }

    set expires(val){ this.Expires = val; }
    get expires()   { return this.Expires; }
}

export {
    LoginRequest,
    LoginResponse
}