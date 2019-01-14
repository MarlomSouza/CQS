/* eslint-disable */
import { RequestMock,  Selector} from 'testcafe'

const mock = RequestMock()
  .onRequestTo('https://localhost:5001/api/atividades/abertas')
  .respond({
    'atividades': [{
      'id': 27,
      'titulo': 'Atividade nova',
      'descricao': 'descrição atividade',
      'tipo': 'ManutencaoUrgente',
      'concluida': false
    }]
  }, 200, {
    'access-control-allow-credentials': true,
    'access-control-allow-origin': '*'
  });

fixture('Listagem Cards')
  .after(async ctx => {
    console.log('After a fixture');
  }).page('http://localhost:8080').requestHooks(mock)



test
  ('Deve listar um card de atividade aberto', async t => {
    const container = Selector(".card-title").exists;
    await t.expect(Selector(".card-title").value).eql('Atividade nova')
      .debug().expect(container).ok();
  })
