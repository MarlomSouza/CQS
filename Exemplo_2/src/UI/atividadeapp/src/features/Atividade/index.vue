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
              <card
                :atividade="atividade"
                @editar="editar"
                @remover="remover(index)"
                @concluir="concluir(atividade, index)"
              ></card>
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
import card from '@/components/Card'

export default {
  components: { criar, card },
  methods: {
    ...mapActions('Atividade',
      ['setAtividades',
        'removerAtividades',
        'setAtividade',
        'salvarAtividade',
        'concluirAtividade'
      ]),
    remover: function (index) {
      this.removerAtividades(index)
    },
    editar: function (atividade) {
      this.setAtividade(atividade)
    },
    salvar: function (atividade) {
      this.salvarAtividade(atividade)
    },
    concluir: function (atividade, index) {
      this.concluirAtividade({ atividade, index })
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
