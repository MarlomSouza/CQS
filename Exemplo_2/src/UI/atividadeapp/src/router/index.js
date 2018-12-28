import Vue from 'vue'
import Router from 'vue-router'
import Atividade from '@/features/Atividade'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Atividade',
      component: Atividade
    }
  ]
})
