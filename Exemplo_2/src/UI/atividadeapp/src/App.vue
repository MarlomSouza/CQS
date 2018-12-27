<template>
  <div
    id="app"
    class="container"
  >
    <div class="row">
      <div class="col-md-9">
        <div class="row">
          <template v-for="atividade in atividades">
            <div class="col-md-4" :key="atividade.id">
              <listar :atividade="atividade" ></listar>
            </div>
          </template>
        </div>
      </div>
      <div class="col-md-3">
        <criar></criar>
      </div>
    </div>
  </div>
</template>

<script>
import criar from '@/components/Criar'
import listar from '@/components/Listar'

export default {
  components: { criar, listar },
  name: 'App',
  data: function () {
    return { atividades: {} }
  },
  created () {
    this.axios.get('/atividades/abertas').then(response => {
      this.atividades = response.data.atividades
    })
  }
}
</script>

<style lang="sass">
  @import '../node_modules/bootstrap/scss/bootstrap.scss'
</style>
