<template>
  <div
    id="app"
    class="container"
  >
    <div class="row">
      <div class="col-md-9">
        <navbar @obter="obter"/>
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
                @remover="remover(atividade,index)"
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
import navbar from '@/components/Navbar'

export default {
  components: { criar, card, navbar },

  methods: {
    ...mapActions('Atividade',
      ['setAtividades',
        'removerAtividades',
        'setAtividade',
        'salvarAtividade',
        'concluirAtividade',
        'obterAtividade'
      ]),
    remover: function (atividade, index) {
      this.removerAtividades({ atividade, index })
    },
    editar: function (atividade) {
      this.setAtividade(atividade)
    },
    salvar: function (atividade) {
      this.salvarAtividade(atividade)
    },
    concluir: function (atividade, index) {
      this.concluirAtividade({ atividade, index })
    },
    obter: function (atividadeConcluida) {
      this.setAtividades(atividadeConcluida)
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
