import Vue from 'vue'
import NProgress from 'nprogress'
import Router from 'vue-router'
import Atividade from '@/features/Atividade'

Vue.use(Router)
NProgress.configure({ easing: 'ease', speed: 500 })
const router = new Router({
  routes: [{
    path: '/',
    name: 'Atividade',
    component: Atividade
  }]
})
router.beforeResolve((to, from, next) => {
  // If this isn't an initial page load.
  if (to.name) {
    // Start the route progress bar.
    NProgress.start()
  }
  next()
})

router.afterEach((to, from) => NProgress.done())

export default router
