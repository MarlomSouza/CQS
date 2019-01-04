import Vuex from 'vuex'
import Vue from 'vue'
import Atividade from '@/features/Atividade/store'
import Alerta from '@/features/Alerta/store'

Vue.use(Vuex)

const modules = {
  Atividade,
  Alerta
}

export default new Vuex.Store({
  modules
})
