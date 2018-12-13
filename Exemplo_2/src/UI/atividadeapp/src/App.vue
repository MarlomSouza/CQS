<template>
  <div id="app" class="container">
    <div class="col-md-12">
      <!-- colocar uma tab aqui -->
      <router-view/>
    </div>
  </div>
</template>

<script>
export default {
  name: 'App',
  created () {
    console.log('#################fui criado')
  }
}
</script>

<style lang="sass">
 @import '../node_modules/bootstrap/scss/bootstrap.scss'
</style>

