import Vue from 'vue'
import Router from 'vue-router'
import Atividade from '@/features/Atividade'

Vue.use(Router)

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'Atividade',
      component: Atividade
    }
  ]
})
router.beforeResolve((to, from, next) => {
  // If this isn't an initial page load.
  if (to.name) {
    // Start the route progress bar.
    console.log('E PRA COMEÇAR A APARECER UM LOADING')
  }
  next()
})

router.afterEach((to, from) => {
  // Complete the animation of the route progress bar.
  console.log('E PRA FINALIZAR UM LOADING')
})

export default router
