<template>
     <ul class="nav nav-pills nav-fill">
          <li class="nav-item">
            <a
              class="nav-link"
              @click="alterarTab(false)"
              :class="{ active:!atividadeConcluida }"
              href="#"
            >Aberta</a>
          </li>
          <li class="nav-item">
            <a
              class="nav-link "
              @click="alterarTab(true)"
              :class="{ active:atividadeConcluida }"
              href="#"
            >Concluida</a>
          </li>
        </ul>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  data: function () {
    return {
      atividadeConcluida: false
    }
  },
  methods: {
    ...mapActions('Atividade', ['setAtividades']),

    alterarTab: function (atividadeConcluida) {
      this.atividadeConcluida = atividadeConcluida
      this.$emit('obter', atividadeConcluida)
    }
  }
}
</script>

<style>

</style>
