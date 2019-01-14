import Vue from 'vue'

const SET_ATIVIDADES = (state, obj) => {
  state.atividades = obj.atividades
}

const INCREMENTAR_ATIVIDADES = (state, atividade) => {
  state.atividades.push(atividade)
}

const REMOVER_ATIVIDADE = (state, index) => {
  state.atividades.splice(index, 1)
}

const SET_ATIVIDADE = (state, atividade) => {
  console.log('atividade mutation', { ...atividade })
  state.atividade = { ...atividade }
}

const CONCLUIR_ATIVIDADE = (state, { atividade, index }) => {
  atividade.concluida = true
  Vue.set(state.atividades, index, atividade)
}

const DESCONCLUIR_ATIVIDADE = (state, { atividade, index }) => {
  atividade.concluida = false
  Vue.set(state.atividades, index, atividade)
}

const ATUALIZAR_TAB = (state, atividadeConcluida) => {
  state.atividadeConcluida = atividadeConcluida
}

const ATUALIZAR_ATIVIDADES = (state, atividade) => {
  let index = state.atividades.findIndex(a => a.id === atividade.id)
  Vue.set(state.atividades, index, atividade)
}

export default {
  SET_ATIVIDADES,
  SET_ATIVIDADE,
  REMOVER_ATIVIDADE,
  INCREMENTAR_ATIVIDADES,
  ATUALIZAR_ATIVIDADES,
  CONCLUIR_ATIVIDADE,
  DESCONCLUIR_ATIVIDADE,
  ATUALIZAR_TAB
}
