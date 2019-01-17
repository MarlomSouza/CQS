/* eslint-disable */

import {  Selector} from 'testcafe'

fixture `Getting Started`
  .page `http://localhost:8080/#/`

  const tipoSelect = Selector('#tipo');
  const tipoOpcoes = tipoSelect.find('option');
  const submitButton = Selector('button[type="submit"]')

test('Deve salvar uma atividade', async t => {
  const titulo = 'Nova Atividade Test'
  await t
    .click("#formularioToggle")

    .typeText('#titulo', titulo)
    .typeText('#descricao', 'Descricao da atividade test')
    .click(tipoSelect)
    .click(tipoOpcoes.withText('Atendimento'))
    .click(submitButton)
    .expect(Selector(".card-title").count).gte(1)
    .expect(Selector(".card-title").withText(titulo))
    .Selector(".card-title").find('#remover')
    .click("#remover")
})

test('Deve editar uma atividade', async t => {
  const macOSRadioButton = Selector('#editar').parent(0).withText("Aba")

  
  await t
    .click('#editar')
    expect(Selector("#titulo").textContent).eql('Aba')

})