<template>
    <form action="POST" id="atividade">
        <div class="form-group">
            <label for="titulo">Titulo</label>
            <input id="titulo" type="text" class="form-control"/>
        </div>
        <div class="form-group">
            <label for="descricao">Descricao</label>
            <textarea name="descricao" class="form-control" id="descricao" rows="3"/>
        </div>
        <div class="form-group">
            <label for="tipo">Selecione o tipo de atividade</label>
            <select  class="form-control" name="Tipo" id="tipo">
                <option value="ManutencaoUrgente" selected>Manutencao urgente</option>
                <option value="Manutencao">Manutencao</option>
                <option value="Atendimento">Atendimento</option>
                <option value="Desenvolvimento">Desenvolvimento</option>
            </select>
        </div>

        <button  class="btn btn-primary center-block" type="submit" @submit="salvar()" >SALVAR</button>
    </form>
</template>

<script>
export default {
  name: 'Atividade',
  created () {
    console.log('#################fui criado')
  },
  methods: {
    salvar () {
      console.log('Clicou em salvar')
    }
  }
}
</script>

<style lang="sass">
 
</style>
