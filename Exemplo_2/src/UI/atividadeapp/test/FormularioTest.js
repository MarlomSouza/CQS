/* eslint-disable */

import {  Selector} from 'testcafe'

fixture `Getting Started`
  .page `http://localhost:8080/#/`

  const tipoSelect = Selector('#tipo');
  const tipoOpcoes = tipoSelect.find('option');

test('Deve salvar uma atividade', async t => {
  await t
    .click("#formularioToggle")
    .typeText('#titulo', 'Nova Atividade Test')
    .typeText('#descricao', 'Descricao da atividade test')
    .click(tipoSelect)
    .click(tipoOpcoes.withText('Atendimento'))
    .click('#Salvar')
    .expect(Selector(".card-title").value).eql('Nova Atividade Test')

})
