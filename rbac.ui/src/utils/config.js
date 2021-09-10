import axios from 'axios'
let baseUrl = "http://localhost:5000";

axios.defaults.baseURL = baseUrl;

// 添加响应拦截器
axios.interceptors.response.use(function (response) {
    // 对响应数据做点什么
    debugger;
    return response;
  }, function (error) {
    // 对响应错误做点什么
    debugger;
    return Promise.reject(error);
  });

export default {
    baseUrl,
    axios
}