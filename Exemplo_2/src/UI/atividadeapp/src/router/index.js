import Vue from 'vue'
import Router from 'vue-router'
import Atividade from '@/components/Atividade'
import Listar from '@/components/Listar'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Atividade',
      name: 'Atividade',
      component: Atividade
    },
    {
      path: '/',
      name: 'Listar',
      component: Listar
    }
  ]
})
