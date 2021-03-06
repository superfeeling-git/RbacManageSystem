import Vue from 'vue'
import Router from 'vue-router'
import login from '../page/login'
import home from '../page/home'
import create from '../page/SysMenu/create'
import rootmenu from '../page/SysMenu/rootmenu'

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
          path:'/sysmenu/create',
          name:'create',
          component:create
        },
        {
          path:'/sysmenu/rootmenu',
          name:'rootmenu',
          component:rootmenu
        }
      ]
    }
  ]
})
