<template>
  <div>
    <div
      class="tamanho card mb-3 card "
      :class="[estaConcluido? concluidoClasse: Classe]"
    >
      <div class="card-header">
        <h5 class="card-title">{{atividade.titulo}}</h5>

        <icon
          icon="edit"
          @click="editar"
        />
        <icon
          @click="remover"
          icon="trash"
        />

        <icon
          @click="concluir"
          icon="check"
        />

      </div>
      <div class="card-body">

        <p class="card-text">{{atividade.descricao}}</p>
      </div>
      <div class="card-footer bg-transparent">{{atividade.tipo}}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Card',
  props: {
    atividade: {
      type: Object,
      required: true
    }
  },
  data () {
    return {
      concluidoClasse: 'text-white bg-success',
      Classe: 'bg-light'
    }
  },
  methods: {
    editar: function () {
      this.$emit('editar', this.atividade)
    },
    remover: function () {
      this.$emit('remover')
    },
    concluir: function () {
      this.$emit('concluir', this.atividade)
    }
  },
  computed: {
    estaConcluido: function () {
      return this.atividade.concluida
    }
  }
}
</script>
<style lang="sass">
.tamanho  { max-width: 18rem }
</style>
