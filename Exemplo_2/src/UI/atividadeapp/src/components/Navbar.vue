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
import { mapState, mapMutations } from 'vuex'

export default {
  methods: {
    ...mapMutations('Atividade', ['ATUALIZAR_TAB']),
    alterarTab: function (atividadeConcluida) {
      this.ATUALIZAR_TAB(atividadeConcluida)
    }
  },
  computed: {
    ...mapState('Atividade', ['atividadeConcluida'])
  }
}
</script>

<style>

</style>
