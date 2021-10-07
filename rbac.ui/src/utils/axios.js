import config from './config'

export default (url = '',  data = {}, method = 'get', params={} )=>{
    return config.axios.request({
        url:url,
        method:method,
        params:params,
        data:data
    });
};