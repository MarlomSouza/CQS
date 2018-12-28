import Vuex from 'vuex'
import Vue from 'vue'
import Atividade from '@/features/Atividade/store'

Vue.use(Vuex)

const modules = {
  Atividade
}

export default new Vuex.Store({
  modules
})
