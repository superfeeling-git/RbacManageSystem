import router from '../router'
import axios from 'axios'
let baseUrl = "http://localhost:5000/api";

axios.defaults.baseURL = baseUrl;
axios.defaults.headers.common['Authorization'] = `bearer ${localStorage.getItem('token')}`;

// 添加响应拦截器
axios.interceptors.response.use(function (response) {
    // 对响应数据做点什么
    return response;
  }, function (error) {
    router.push("/");
    return Promise.reject(error);
  });

export default {
    baseUrl,
    axios
}