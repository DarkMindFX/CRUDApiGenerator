

class HealthResponse {

    constructor() {
        this._message = null;
    }

    get message() { return this._message; }

    set message(val) { this._message = val; }
}

export default HealthResponse;