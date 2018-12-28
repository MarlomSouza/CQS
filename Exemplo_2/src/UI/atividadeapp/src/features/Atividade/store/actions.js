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
  if (!obj.id) {
    commit('INCREMENTAR_ATIVIDADES', obj)
  } else {
    commit('ATUALIZAR_ATIVIDADES', obj)
  }
  commit('SET_ATIVIDADE', {})
}

export default {
  setAtividades,
  setAtividade,
  salvarAtividade,
  removerAtividades
}
