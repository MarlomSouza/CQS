const quantidade = state => state.atividades.length

const atividade = state => {
  return { titulo: state.atividade.titulo, descricao: state.atividade.descricao, tipo: state.atividade.tipo }
}

export default {
  quantidade,
  atividade
}
