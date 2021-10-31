
class Error 
{
    constructor() {
        this._code = 0;
        this._message = null;
    }

    get message() { return this._message; }

    set message(msg) { this._message = msg; }

    get code() { return this._code; }

    set code(val) { this._code = val; } 
}

module.exports = Error;
