<template>
  <div id="app">
    <img src="./assets/logo.png">
    <router-view/>
    <button type="button" class="" @click="printarLog()">Printar log</button>

    <input type="text" v-model="this.nome">
    <label>{{nome}}</label>

  </div>
</template>

<script>
export default {
  name: 'App',
  created() {
    console.log('#################fui criado')
  },
  methods: {
    printarLog() {
       setTimeout(() => { this.nome = "alterado depois de 2 segundos!" }, 2000)
       this.nome = "marlim"
    }
  },
  data() {
      return { nome: "Marlom"}
  },
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
