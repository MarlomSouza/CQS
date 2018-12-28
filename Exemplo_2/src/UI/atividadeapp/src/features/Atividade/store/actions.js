import Axios from 'axios'

let axios = Axios.create({
  baseURL: 'https://localhost:5001/api/',
  timeout: 1000
})

const setAtividades = ({ commit }, obj) => {
  axios.get('/atividades/abertas').then(response => {
    const atividades = response.data.atividades
    commit('SET_ATIVIDADES', { atividades })
  })
}
const removerAtividades = ({ commit }, atividade) => {
  commit('REMOVER_ATIVIDADE', atividade)
}
const setAtividade = ({ commit }, obj) => {
  commit('SET_ATIVIDADE', obj)
}
const salvarAtividade = ({ commit }, obj) => {
  commit('SET_ATIVIDADE', {})
  commit('INCREMENTAR_ATIVIDADES', obj)
}

export default {
  setAtividades,
  setAtividade,
  salvarAtividade,
  removerAtividades
}
