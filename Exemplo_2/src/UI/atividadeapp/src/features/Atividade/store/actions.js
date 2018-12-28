import Axios from 'axios'

let axios = Axios.create({
  baseURL: 'https://localhost:5001/api/',
  timeout: 1000
})

const setAtividades = ({ commit }, obj) => {
  console.log('o valor eh =>', obj)
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
export default {
  setAtividades,
  setAtividade,
  removerAtividades
}
