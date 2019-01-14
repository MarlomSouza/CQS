import http from '../../../http'
import Vue from 'vue'

const setAtividades = ({ commit, state }) => {
  let url = state.atividadeConcluida ? '/concluidas' : '/abertas'

  http.get(url).then(response => {
    commit('SET_ATIVIDADES', { ...response.data })
  })
}

const setAtividade = ({ commit }, atividade) => {
  commit('SET_ATIVIDADE', atividade)
}

const removerAtividades = ({ commit }, { atividade, index }) => {
  http
    .delete(`${atividade.id}`)
    .then(() => commit('REMOVER_ATIVIDADE', index))
    .then(() => Vue.toasted.show('Atividade removida'))
    .catch(erro => Vue.toasted.show(erro.response.data))
}

const concluirAtividade = ({ commit }, { atividade, index }) => {
  http
    .put(`${atividade.id}/concluir`)
    .then(() => commit('CONCLUIR_ATIVIDADE', { atividade, index }))
    .then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
    .catch(erro => Vue.toasted.show(erro.response.data))
}

const desconcluirAtividade = ({ commit }, { atividade, index }) => {
  http
    .put(`${atividade.id}/desconcluir`)
    .then(() => commit('DESCONCLUIR_ATIVIDADE', { atividade, index }))
    .then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
    .catch(erro => Vue.toasted.show(erro.response.data))
}

const salvarAtividade = ({ commit }, atividade) => {
  let atividadeSalva = {}
  if (!atividade.id) {
    atividadeSalva = http.post('', atividade).then(() => commit('INCREMENTAR_ATIVIDADES', atividade))
  } else {
    atividadeSalva = http.put(`${atividade.id}`, atividade).then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
  }
  atividadeSalva
    .then(() => commit('SET_ATIVIDADE', {}))
    .then(() => Vue.toasted.show('Atividade salva'))
    .catch(erro => Vue.toasted.show(erro.response.data))
}

export default {
  setAtividades,
  setAtividade,
  salvarAtividade,
  removerAtividades,
  concluirAtividade,
  desconcluirAtividade
}
