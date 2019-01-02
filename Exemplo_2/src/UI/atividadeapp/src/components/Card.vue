<template>
  <div>
    <div class="tamanho card mb-3 card ">
      <div
        class="card-header"
        :class="[estaConcluido? concluidoClasse: Classe]"
      >
        <h5 class="card-title">{{atividade.titulo}}</h5>
        <icon
          class="ponteiro"
          icon="edit"
          @click="editar"
        />
        <icon
          class="ponteiro"
          @click="remover"
          icon="trash"
        />
        <icon
          class="ponteiro"
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
      concluidoClasse: 'text-white teal',
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
<style lang="sass" scoped>
.tamanho  { max-width: 18rem }
.ponteiro { cursor: pointer; }
.teal { background: #20c997  }
</style>
