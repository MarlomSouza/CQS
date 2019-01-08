<template>
  <div>
    <nav class="navbar navbar-expand-md navbar-dark bg-dark">
      <div class="container container-without-margin">
        <button
          type="button"
          @click="toogleFormulario"
        >
          <icon
            class="ponteiro"
            icon="bars"
          />
        </button>
        <div
          class="collapse navbar-collapse"
          id="navbarsExampleDefault"
        >
        </div>
      </div>
    </nav>

    <div class="row">
      <div
        class="col-md-9"
        :class="[estaVisivel ? comFomulario: semFormulario]"
      >
        <navbar @obter="obter" /> {{quantidade}}
        <div
          class="row"
          style="overflow-y: auto; height:500px; "
        >
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
                @desconcluir="desconcluir(atividade, index)"
              ></card>
            </div>
          </template>
        </div>
      </div>
      <div
        class="col-md-3 service-form"
        v-show="estaVisivel"
      >
        <formulario @salvar-atividade="salvar" />
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import formulario from '@/components/Formulario'
import card from '@/components/Card'
import navbar from '@/components/Navbar'

export default {
  components: { formulario, card, navbar },
  data: function () {
    return {
      visible: false,
      comFomulario: 'col-md-9',
      semFormulario: 'col-md-12'
    }
  },
  methods: {
    ...mapActions('Atividade',
      ['setAtividades',
        'removerAtividades',
        'setAtividade',
        'salvarAtividade',
        'concluirAtividade',
        'desconcluirAtividade',
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
    desconcluir: function (atividade, index) {
      this.desconcluirAtividade({ atividade, index })
    },
    obter: function () {
      this.setAtividades()
    },
    toogleFormulario: function () {
      this.visible = !this.visible
    }
  },
  mounted () {
    this.setAtividades()
  },
  computed: {
    ...mapGetters('Atividade', ['quantidade', 'atividades']),
    estaVisivel: function () {
      return this.visible
    }
  }
}
</script>

<style lang="scss">
.container-without-margin {
  padding: 0;
  margin: 0;
}
</style>
