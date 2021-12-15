
import constants from '../constants';
import axios from 'axios';

class DalBase {

    get ApiUrl() {
        const url = `${constants.PPT_API_HOST}/api/${constants.PPT_API_VERSION}`;
        
        return url;
    }

    get Instance() {
        const url = this.ApiUrl;

        let inst = axios.create({
            baseURL: url
        })

        inst.interceptors.request.use( function(config) {
            const token = localStorage.getItem(constants.SESSION_TOKEN_KEY);

            if(token) {
                config.headers.Authorization = `Bearer ${token}`;
            }
            return config;
        });

        return inst;
    }

}

export default DalBase;