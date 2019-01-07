// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faEdit, faTrash, faCheck } from '@fortawesome/free-solid-svg-icons'
import { library } from '@fortawesome/fontawesome-svg-core'
import Toasted from 'vue-toasted'

import '../node_modules/nprogress/nprogress.css'

Vue.use(Toasted, {
  theme: 'outline',
  iconPack: FontAwesomeIcon,
  position: 'bottom-right',
  duration: 5000
})

library.add(faEdit, faTrash, faCheck)
Vue.component('icon', FontAwesomeIcon)

Vue.config.productionTip = true

// eslint-disable-next-line no-new
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
})
