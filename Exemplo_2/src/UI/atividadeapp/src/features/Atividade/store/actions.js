import http from '../../../http'
import Vue from 'vue'

const setAtividades = ({ commit, state }) => {
  let url = '/abertas'
  if (state.atividadeConcluida) {
    url = '/concluidas'
  }

  http.get(url).then(response => {
    const atividades = response.data.atividades
    commit('SET_ATIVIDADES', { atividades })
    Vue.toasted.show('Atividade Obtida')
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

const salvarAtividade = ({ commit }, atividade) => {
  // eslint-disable-next-line no-debugger
  debugger
  if (!atividade.id) {
    http
      .post('', atividade)
      .then(() => commit('INCREMENTAR_ATIVIDADES', atividade))
      .then(() => Vue.toasted.show('Atividade salva'))
      .catch(erro => Vue.toasted.show(erro.response.data))
  } else {
    http
      .put(`${atividade.id}`, atividade)
      .then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
      .then(() => Vue.toasted.show('Atividade salva'))
      .catch(erro => Vue.toasted.show(erro.response.data))
  }

  commit('SET_ATIVIDADE', {})
}

export default {
  setAtividades,
  setAtividade,
  salvarAtividade,
  removerAtividades,
  concluirAtividade
}
