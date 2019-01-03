const quantidade = state => state.atividades.length

const atividades = state => state.atividades.filter(atividade => atividade.concluida === state.atividadeConcluida)

const atividade = state => {
  let atividade = {
    id: state.atividade.id,
    titulo: state.atividade.titulo,
    descricao: state.atividade.descricao,
    tipo: state.atividade.tipo,
    concluida: state.atividadeConcluida
  }
  return atividade
}

export default {
  quantidade,
  atividade,
  atividades
}
