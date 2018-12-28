const quantidade = state => state.atividades.length

const atividades = state => state.atividades

const atividade = state => {
  let atividade = {
    id: state.atividade.id,
    titulo: state.atividade.titulo,
    descricao: state.atividade.descricao,
    tipo: state.atividade.tipo
  }
  return atividade
}

export default {
  quantidade,
  atividade,
  atividades
}
