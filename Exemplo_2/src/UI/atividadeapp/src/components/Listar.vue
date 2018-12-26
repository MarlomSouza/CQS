<template>
  <div>
    <template v-for="atividade in atividades">
      <div class="tamanho card bg-light mb-3" :key="atividade.Id">
        <div class="card-header">{{atividade.Tipo}}</div>
        <div class="card-body">
          <h5 class="card-title">{{atividade.Titulo}}</h5>
          <p class="card-text">{{atividade.Descricao}}</p>
        </div>
      </div>
    </template>
  </div>
</template>

<script>
export default {
  name: 'Listar',
  data () {
    return {
      atividades: [
        {
          'Id': 1,
          Titulo: 'Primeiro Card',
          Descricao: 'Descricao do meu treco',
          Tipo: 'Manutencao'
        },
        {
          'Id': 2,
          Titulo: 'Primeiro Card',
          Descricao: 'Descricao do meu treco',
          Tipo: 'Manutencao'
        },
        {
          'Id': 3,
          Titulo: 'Primeiro Card',
          Descricao: 'Descricao do meu treco',
          Tipo: 'Manutencao'
        }
      ]
    }
  },
  created () { },
  methods: {
    salvar () { }
  }
}
</script>
<style lang="sass">
.tamanho  {max-width: 18rem }
</style>
