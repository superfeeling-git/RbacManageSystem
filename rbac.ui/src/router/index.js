import Vue from 'vue'
import Router from 'vue-router'
import login from '../page/login'
import home from '../page/home'
import sysmenuCreate from '../page/SysMenu/create'
import sysmenuIndex from '../page/SysMenu/index'
import roleIndex from '../page/Role/index'
import adminIndex from '../page/Admin/index'

Vue.use(Router)

console.log('----');

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
          path:'/sysmenu/index',
          name:'sysmenuIndex',
          component:sysmenuIndex
        },
        {
          path:'/role/index',
          name:'roleIndex',
          component:roleIndex
        },
        {
          path:'/admin/index',
          name:'adminIndex',
          component:adminIndex
        }
      ]
    }
  ]
})
