/* eslint-disable */

import {  Selector} from 'testcafe'

fixture `Getting Started`
  .page `http://localhost:8080/#/`

test('Deve salvar uma atividade', async t => {
  await t
  .setTestSpeed(0.01)
    .click("#formularioToggle")
    .typeText('#titulo', 'Nova Atividade Test')
    .typeText('#descricao', 'Descricao da atividade test')
    .click(Selector('option', { value: 'Atendimento' }))
    .click('#Salvar')
    .expect(Selector(".card-title").value).eql('Nova Atividade Test')

})