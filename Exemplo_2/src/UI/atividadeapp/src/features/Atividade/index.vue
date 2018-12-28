<template>
  <div
    id="app"
    class="container"
  >
    <div class="row">
      <div class="col-md-9">
        {{quantidade}}
        <div class="row">
          <template v-for="(atividade, index) in atividades">
            <div
              class="col-md-4"
              :key="atividade.id"
            >
              <listar
                :atividade="atividade"
                @editar-atividade="editar"
                @remover-atividade="remover(index)"
              ></listar>
            </div>
          </template>
        </div>
      </div>
      <div class="col-md-3">
        <criar @salvar-atividade="salvar"></criar>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import criar from '@/components/Criar'
import listar from '@/components/Listar'

export default {
  components: { criar, listar },
  methods: {
    ...mapActions('Atividade', ['setAtividades', 'removerAtividades', 'setAtividade', 'salvarAtividade']),
    remover: function (index) {
      this.removerAtividades(index)
    },
    editar: function (atividade) {
      this.setAtividade(atividade)
    },
    salvar: function (atividade) {
      this.salvarAtividade(atividade)
    }
  },
  mounted () {
    this.setAtividades()
  },
  computed: {
    ...mapGetters('Atividade', ['quantidade', 'atividades'])
  }
}
</script>

<style>
</style>
