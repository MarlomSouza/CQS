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
        <select class="form-control" v-model="selected" @change="select" name="Tipo" id="tipo">
          <option v-for="option in options" :value="option.value" :key="option.value">
            {{ option.text }}
          </option>
        </select>
    </div>
    <div class="form-group">
      <button class="btn btn-primary btn-m btn-block" type="submit"  id="Salvar">Salvar</button>
    </div>
    </form>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'Formulario',
  data: function () {
    return {
      selected: 'Atendimento',
      options: [
        { text: 'Manutenção Urgente', value: 'ManutencaoUrgente' },
        { text: 'Manutenção', value: 'Manutencao' },
        { text: 'Atendimento', value: 'Atendimento' },
        { text: 'Desenvolvimento', value: 'Desenvolvimento' }
      ]
    }
  },
  methods: {
    salvar: function (atividade) {
      this.$emit('salvar-atividade', atividade)
    },
    select: function () {
      this.atividade.tipo = this.selected
    }
  },
  computed: {
    ...mapGetters('Atividade', ['atividade'])
  }
}
</script>
<style lang="scss">
</style>
