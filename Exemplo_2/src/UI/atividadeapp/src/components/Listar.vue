<template>
  <div>
    <div class="tamanho card bg-light mb-3">
      <div class="card-header">
        {{atividade.tipo}}
        <i @click="editar(atividade)">
          <font-awesome-icon icon="edit" />
        </i>
         <i @click="remover">
          <font-awesome-icon icon="trash" />
        </i>

      </div>
      <div class="card-body">
        <h5 class="card-title">{{atividade.titulo}}</h5>
        <p class="card-text">{{atividade.descricao}}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Listar',
  props: {
    atividade: {
      type: Object,
      required: true
    }
  },
  methods: {
    editar: function (atividade) {
      this.$emit('editar-atividade', atividade)
    },
    remover: function () {
      this.$emit('remover-atividade')
    }
  }
}
</script>
<style lang="sass">
.tamanho  {  max-width: 18rem  }
</style>
