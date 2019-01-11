/* eslint-disable */

import { RequestMock, Selector } from 'testcafe'

fixture('Listagem Cards')
  .page('http://localhost:8080/#/')

const mock = RequestMock()
  .onRequestTo('http://external-service.com/api/')
  .respond({ data: { 'atividades': [{ 'id': 27, 'titulo': 'Atividade nova', 'descricao': 'descrição atividade', 'tipo': 'ManutencaoUrgente', 'concluida': false }] } })

test
  .requestHooks(mock)
  ('Deve listar um card de atividade aberto', async t => {
    await t
    .setTestSpeed(0.01)
    .expect(Selector(".card-title").value).eql('Atividade nova')
    .expect(Selector(".card-text").value).eql('descrição atividade')
    .expect(Selector(".card-footer").value).eql('Manutenção Urgente')
  })
