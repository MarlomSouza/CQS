<template>
  <form
    action="POST"
    id="atividade"
    @submit.prevent="salvar"
  >
    <div class="form-group">
      <label for="titulo">Título</label>
      <input
        id="titulo"
        type="text"
        v-model="atividade.titulo"
        class="form-control"
      />
    </div>
    <div class="form-group">
      <label for="descricao">Descrição</label>
      <textarea
        name="descricao"
        v-model="atividade.descricao"
        class="form-control"
        id="descricao"
        rows="3"
      />
      </div>
        <div class="form-group">
            <label for="tipo">Selecione o tipo de atividade</label>
            <select  class="form-control" v-model="atividade.tipo" name="Tipo" id="tipo">
                <option value="ManutencaoUrgente" selected>Manutencao urgente</option>
                <option value="Manutencao">Manutencao</option>
                <option value="Atendimento">Atendimento</option>
                <option value="Desenvolvimento">Desenvolvimento</option>
            </select>
        </div>
        <button class="btn btn-primary center-block" type="submit" >SALVAR</button>
    </form>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  name: 'Criar',
  data () {
    let atividade = {}
    return atividade
  },
  methods: {
  },
  computed: {
    ...mapGetters('Atividade', ['atividade'])
  }
}
</script>
<style lang="sass">
</style>
