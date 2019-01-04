import { ALERTS_DISPLAY, ALERTS_CHANGE_MESSAGE } from './mutation-types'

const createOne = ({ commit, state }, alert) => {
  console.log(alert)
  commit(ALERTS_CHANGE_MESSAGE, alert)
  commit(ALERTS_DISPLAY)
}

export default{
  createOne
}
