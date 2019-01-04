import { ALERTS_CHANGE_MESSAGE, ALERTS_DISPLAY } from './mutation-types'

const mutations = {
  [ALERTS_CHANGE_MESSAGE] (state, message) {
    state.message = message
  },
  [ALERTS_DISPLAY] (state) {
    setTimeout(() => {
      alert(state.message)
    }, state.delay)
  }
}

export default{
  ...mutations
}
