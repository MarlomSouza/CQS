import Vue from 'vue'
import Router from 'vue-router'
import Criar from '@/components/Criar'
import Listar from '@/components/Listar'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Criar',
      name: 'Criar',
      component: Criar
    },
    {
      path: '/Listar',
      name: 'Listar',
      component: Listar
    }
  ]
})
