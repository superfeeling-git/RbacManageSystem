import Vue from 'vue'
import Router from 'vue-router'
import login from '../page/login'
import home from '../page/home'
import create from '../page/SysMenu/create'


Vue.use(Router)


export default new Router({
  routes: [
    {
      path: '/',
      name: 'login',
      component: login
    },
    {
      path: '/home',
      name: 'home',
      component: home,
      children:[
        {
          path:'/sysmenu/create',
          name:'create',
          component:create
        }
      ]
    }
  ]
})
