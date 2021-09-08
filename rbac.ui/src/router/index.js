import Vue from 'vue'
import Router from 'vue-router'
import login from '../page/login'
import test from '../page/test'


Vue.use(Router)


export default new Router({
  routes: [
    {
      path: '/',
      name: 'login',
      component: login
    },
    {
      path: '/test',
      name: 'test',
      component: test
    }
  ]
})
