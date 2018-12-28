
const SET_ATIVIDADES = (state, obj) => {
  state.atividades = obj.atividades
}

const REMOVER_ATIVIDADE = (state, index) => {
  state.atividades.splice(index, 1)
}

export default {
  SET_ATIVIDADES,
  REMOVER_ATIVIDADE
}
