import Axios from 'axios'

let axios = Axios.create({
  baseURL: 'https://localhost:5001/api/atividades',
  timeout: 1000
})

const setAtividades = ({ commit }, atividadeConcluida) => {
  let url = '/abertas'
  if (atividadeConcluida) { url = '/concluidas' }
  axios.get(url).then(response => {
    const atividades = response.data.atividades

    commit('SET_ATIVIDADES', { atividades })
  })
}

const setAtividade = ({ commit }, atividade) => {
  commit('SET_ATIVIDADE', atividade)
}

const removerAtividades = ({ commit }, atividade) => {
  commit('REMOVER_ATIVIDADE', atividade)
}

const concluirAtividade = ({ commit }, { atividade, index }) => {
  atividade.concluida = true
  commit('CONCLUIR_ATIVIDADE', { atividade, index })
}

const salvarAtividade = ({ commit }, atividade) => {
  if (!atividade.id) {
    axios.post('', atividade).then(() => commit('INCREMENTAR_ATIVIDADES', atividade))
  } else {
    axios.put(`${atividade.id}`, atividade).then(() => commit('ATUALIZAR_ATIVIDADES', atividade))
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
