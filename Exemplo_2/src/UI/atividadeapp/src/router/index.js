import Vue from 'vue'
import Router from 'vue-router'
import Atividade from '@/components/Atividade'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Atividade',
      name: 'Atividade',
      component: Atividade
    }
  ]
})
