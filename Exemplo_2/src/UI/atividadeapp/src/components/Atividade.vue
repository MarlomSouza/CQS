<template>
    <form action="POST" id="atividade" v-on:submit="salvar">
        <div class="form-group">
            <label for="titulo">Titulo</label>
            <input id="titulo" type="text" v-model="titulo" class="form-control"/>
        </div>
        <div class="form-group">
            <label for="descricao">Descricao</label>
            <textarea name="descricao" v-model="descricao" class="form-control" id="descricao" rows="3"/>
        </div>
        <div class="form-group">
            <label for="tipo">Selecione o tipo de atividade</label>
            <select  class="form-control" v-model="tipo" name="Tipo" id="tipo">
                <option value="ManutencaoUrgente" selected>Manutencao urgente</option>
                <option value="Manutencao">Manutencao</option>
                <option value="Atendimento">Atendimento</option>
                <option value="Desenvolvimento">Desenvolvimento</option>
            </select>
        </div>
        <button class="btn btn-primary center-block" type="submit" >SALVAR</button>
    </form>
</template>

<script>
export default {
  name: 'Atividade',
  data () {
    let atividade = {
      titulo: '',
      descricao: '',
      tipo: ''
    }
    return atividade
  },
  created () {
    console.log('#################fui criado')
    this.axios
      .get('https://api.coindesk.com/v1/bpi/currentprice.json')
      .then(response => console.log('ola', response.data))
  },
  methods: {
    salvar () {
      event.preventDefault()
      let atividade = {Titulo: this.titulo, Descricao: this.descricao, Tipo: this.tipo}
      console.log('Clicou em salvar', atividade)
    }
  }
}
</script>
<style lang="sass">
</style>
