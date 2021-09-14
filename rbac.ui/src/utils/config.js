import router from '../router'
import axios from 'axios'
let baseUrl = "http://localhost:5000/api/";

axios.defaults.baseURL = baseUrl;
axios.defaults.headers.common['Authorization'] = `bearer ${localStorage.getItem("token")}`;

// 添加响应拦截器
axios.interceptors.response.use(function (response) {
    // 对响应数据做点什么
    debugger
    console.log(2);
    return response;
  }, function (error) {
    console.log(error.response);
    // 对响应错误做点什么
    if(error.response.status == 401){
      //跳转处理
      router.push("/");
    }
    return Promise.reject(error);
  });

export default {
    baseUrl,
    axios
}