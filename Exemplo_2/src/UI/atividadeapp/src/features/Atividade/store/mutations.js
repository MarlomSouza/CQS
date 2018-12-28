
const SET_ATIVIDADES = (state, obj) => {
  state.atividades = obj.atividades
}

const INCREMENTAR_ATIVIDADES = (state, obj) => {
  state.atividades.push(obj)
}

const REMOVER_ATIVIDADE = (state, index) => {
  state.atividades.splice(index, 1)
}

const SET_ATIVIDADE = (state, atividade) => {
  state.atividade = { ...atividade }
  console.log('state.atividade', state.atividade)
}

export default {
  SET_ATIVIDADES,
  SET_ATIVIDADE,
  REMOVER_ATIVIDADE,
  INCREMENTAR_ATIVIDADES
}
