

class PageHelper
{
    _props = null;
    constructor(props)
    {
        this._props = props;
    }

    redirectToLogin(retUrl)
    {
        this._props.history.push(`/login?ret=${retUrl}`);     
    }    
}

export default PageHelper;