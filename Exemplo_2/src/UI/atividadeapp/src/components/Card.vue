<template>
  <div>
    <div class="tamanho card mb-3 card ">
      <div
        class="card-header"
        :class="[estaConcluido? atividadeConcluida: atividadeAberta]"
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
          v-if="!estaConcluido"
          class="ponteiro"
          @click="concluir"
          icon="check"
        />

        <icon
          v-else
          class="ponteiro"
          @click="desconcluir"
          icon="undo"
        />

      </div>
      <div class="card-body">
        <p class="card-text">{{atividade.descricao}}</p>
      </div>
      <div class="card-footer bg-transparent">{{tipoAtividade}}</div>
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
      atividadeConcluida: 'text-white teal',
      atividadeAberta: 'bg-light',
      descricaoAtividade: {
        ManutencaoUrgente: 'Manutenção Urgente',
        Manutencao: 'Manutenção',
        Atendimento: 'Atendimento',
        Desenvolvimento: 'Desenvolvimento'
      }
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
    },
    desconcluir: function () {
      this.$emit('desconcluir')
    }
  },
  computed: {
    estaConcluido: function () {
      return this.atividade.concluida
    },
    tipoAtividade: function () {
      return this.descricaoAtividade[this.atividade.tipo]
    }
  }
}
</script>
<style lang="sass" scoped>
.tamanho  { max-width: 18rem }
.teal { background: #20c997  }
</style>
