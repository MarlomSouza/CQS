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
        <criar></criar>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions, mapGetters } from 'vuex'
import criar from '@/components/Criar'
import listar from '@/components/Listar'

export default {
  components: { criar, listar },
  methods: {
    ...mapActions('Atividade', ['setAtividades', 'removerAtividades']),
    remover: function (index) {
      this.removerAtividades(index)
    },
    editar: atividade => {
      console.log(atividade)
    }
  },
  mounted () {
    this.setAtividades()
  },
  computed: {
    ...mapState('Atividade', ['atividades', 'atividades']),
    ...mapGetters('Atividade', ['quantidade'])
  }
}
</script>

<style>
</style>
