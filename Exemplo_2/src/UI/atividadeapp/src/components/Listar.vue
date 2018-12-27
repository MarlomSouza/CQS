<template>
  <div>
    <div class="tamanho card bg-light mb-3">
      <div class="card-header">{{atividade.tipo}}</div>
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
      required: true,
      default: function () {
        return { message: 'hello' }
      }
    }
  },
  created () {
  }
}
</script>
<style lang="sass">
.tamanho  {  max-width: 18rem  }
</style>
