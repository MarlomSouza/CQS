import Axios from 'axios'
import Vue from 'vue'

let axios = Axios.create({
  baseURL: 'https://localhost:5001/api/atividades',
  timeout: 1000
})

const setAtividades = ({ commit, state }) => {
  let url = '/abertas'
  if (state.atividadeConcluida) { url = '/concluidas' }
  axios.get(url).then(response => {
    const atividades = response.data.atividades
    commit('SET_ATIVIDADES', { atividades })
    Vue.toasted.show('Atividade Obtida')
  })
}

const setAtividade = ({ commit }, atividade) => {
  commit('SET_ATIVIDADE', atividade)
}

const removerAtividades = ({ commit }, { atividade, index }) => {
  axios.delete(`${atividade.id}`)
    .then(() => commit('REMOVER_ATIVIDADE', index))
    .then(() => Vue.toasted.show('Atividade removida'))
    .catch(erro => Vue.toasted.show(erro.response))
}

const concluirAtividade = ({ commit }, { atividade, index }) => {
  axios.put(`${atividade.id}/concluir`)
    .then(() => commit('CONCLUIR_ATIVIDADE', { atividade, index }))
    .then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
    .catch(erro => Vue.toasted.show(erro.response, {
      icon: {
        name: 'fal fa-check fa-spin fa-fw'
      } }))
}

const salvarAtividade = ({ commit }, atividade) => {
  if (!atividade.id) {
    axios.post('', atividade).then(() => commit('INCREMENTAR_ATIVIDADES', atividade))
  } else {
    axios.put(`${atividade.id}`, atividade).then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
  }
  Vue.toasted.show('Atividade salva', { icon: {
    name: 'Check'
  } })
  commit('SET_ATIVIDADE', {})
}

export default {
  setAtividades,
  setAtividade,
  salvarAtividade,
  removerAtividades,
  concluirAtividade
}
