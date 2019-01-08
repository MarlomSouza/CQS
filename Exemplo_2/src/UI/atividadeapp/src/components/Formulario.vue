<template>

  <form
    action="POST"
    id="atividade"
    @submit.prevent="salvar(atividade)"
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
        <div class="col-md-12">
          <button class="btn btn-primary btn-lg btn-block" type="submit" >SALVAR</button>
        </div>
    </form>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'Formulario',
  data () {
    return {}
  },
  methods: {
    salvar: function (atividade) {
      this.$emit('salvar-atividade', atividade)
    }
  },
  computed: {
    ...mapGetters('Atividade', ['atividade'])
  }
}
</script>
<style lang="sass">
.service-form { background-color: #fafbfb; border: 1px solid #e4e8ea; padding: 40px 40px 20px 40px;}
</style>
