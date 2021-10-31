
class HateosDto {

    constructor() {
        this.links = new Array();
    }

    get links() { return this._links; }
    set links(val) { this._links = val; }

}

module.exports = HateosDto;